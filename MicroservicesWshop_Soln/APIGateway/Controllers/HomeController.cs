using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MicroSoln1.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using APIGateway.Models;
using System.Text;
using System.Web;
using APIGateway.Services;


namespace APIGateway.Controllers
{
    public class HomeController : Controller
    {
        protected HttpClient httpClient;
        protected IConfiguration cfg;
        protected DataFetcher dataFetcher;

        public HomeController(HttpClient httpClient, IConfiguration cfg, 
             DataFetcher dataFetcher)
        {
            this.httpClient = httpClient;
            this.cfg = cfg;
            this.dataFetcher = dataFetcher;
        }

        public string Compute([FromBody] Operand operand)
        {
            string url;

            url = cfg.GetValue<string>("Hosts:TokenAPI") + "/Home/Tokenize";
            operand = dataFetcher.GetData(httpClient, url, operand);

            url = cfg.GetValue<string>("Hosts:TransformAPI") + "/Home/InfixToPostfix";
            operand = dataFetcher.GetData(httpClient, url, operand);

            url = cfg.GetValue<string>("Hosts:ReducerAPI") + "/Home/ReducePostfix";
            operand = dataFetcher.GetData(httpClient, url, operand);

            return JsonSerializer.Serialize(new
            {
                result = operand.Value
            });
        }

        public IActionResult Index()
        {
            return View();
        }

        /*
         * Please ignore this method. Not used in our workshop.
         */
        [HttpPut]
        public string PutTest([FromBody] Operand operand)
        {
            string content = "";

            Task nullTask = Task.Run(async () =>
            {
                string host = cfg.GetValue<string>("Hosts:EchoAPI");

                HttpRequestMessage request = new HttpRequestMessage()
                {
                    Method = HttpMethod.Put,
                    RequestUri = new Uri(host + "/Home/PutTest"),
                    Content = new StringContent(
                        JsonSerializer.Serialize(operand), 
                        Encoding.UTF8, 
                        "application/json"
                    )
                };

                HttpResponseMessage response = await httpClient.SendAsync(request);
                content = await response.Content.ReadAsStringAsync();
                
                operand = JsonSerializer.Deserialize<Operand>(content);
            });

            nullTask.Wait();

            return JsonSerializer.Serialize(new
            {
                result = operand.Value
            });
        }
    }
}
