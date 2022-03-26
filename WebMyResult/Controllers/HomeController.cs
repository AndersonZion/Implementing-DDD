using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebMyResult.Models;

namespace WebMyResult.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly IPessoaApp _IPessoaApp;
        public HomeController(ILogger<HomeController> logger, IPessoaApp IPessoaApp)
        {
            _logger = logger;
            _IPessoaApp = IPessoaApp;
        }

        public IActionResult Index()
        {
        
            return View();
        }

        public async Task<IActionResult> Pessoa()
        {
            var pessoa = await _IPessoaApp.Obter();
            return View(pessoa);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
