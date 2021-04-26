using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using APIGateway.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReducerAPI.Models;
using ReducerAPI.Services;


namespace ReducerAPI.Controllers
{
    public class HomeController : Controller
    {
        protected Reducer reducer;

        public HomeController(Reducer reducer)
        {
            this.reducer = reducer;
        }

        public string ReducePostfix([FromBody] Operand operand)
        {
            operand.Value = reducer.ReducePostfix(operand.Postfix).ToString();
            return JsonSerializer.Serialize(operand);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
