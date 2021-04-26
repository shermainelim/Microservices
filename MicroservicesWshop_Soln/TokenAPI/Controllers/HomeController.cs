using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TokenAPI.Models;
using TokenAPI.Services;
using System.Text.Json;
using APIGateway.Models;


namespace TokenAPI.Controllers
{
    public class HomeController : Controller
    {
        private Tokenizer tokenizer;

        public HomeController(Tokenizer tokenizer)
        {
            this.tokenizer = tokenizer;
        }

        public IActionResult Index()
        {
            return View();
        }

        public string Tokenize([FromBody] Operand operand)
        {
            operand.Infix = tokenizer.Tokenize(operand.Value);
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
