using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TransformAPI.Models;
using TransformAPI.Services;
using System.Text.Json;
using APIGateway.Models;

namespace TransformAPI.Controllers
{
    public class HomeController : Controller
    {
        private Transformer transformer;

        public HomeController(Transformer transformer)
        {
            this.transformer = transformer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string InfixToPostfix([FromBody] Operand operand)
        {
            operand.Postfix = transformer.InfixToPostfix(operand.Infix);
            return JsonSerializer.Serialize(operand);
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
