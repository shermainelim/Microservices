using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using APIGateway.Models;
using System.Text;


namespace APIGateway.Services
{
    public class DataFetcher
    {
        public Operand GetData(HttpClient httpClient, string url, Operand operand)
        {
            Task.Run(async () =>
            {
                HttpContent data = new StringContent(
                    JsonSerializer.Serialize(operand),
                    Encoding.UTF8,
                    "application/json"
                );

                HttpResponseMessage response = await httpClient.PostAsync(
                    url, data
                );
                if (response.StatusCode.GetHashCode() == 200)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    operand = JsonSerializer.Deserialize<Operand>(content);
                }
            }).Wait();

            return operand;
        }
    }
}
