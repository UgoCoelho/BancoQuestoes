using BancoQuestoes.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BancoQuestoes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Redireciona para login se não tiver sessão
            if (HttpContext.Session.GetString("UsuarioNome") == null)
                return RedirectToAction("Index", "Login");

            // Pega os dados do usuário logado
            var usuarioId = HttpContext.Session.GetInt32("UsuarioId");
            var nome = HttpContext.Session.GetString("UsuarioNome");
            var curso = HttpContext.Session.GetString("UsuarioCurso");
            var periodo = HttpContext.Session.GetInt32("UsuarioPeriodo");

            // Passa para a View
            ViewBag.UsuarioNome = nome;
            ViewBag.UsuarioCurso = curso;
            ViewBag.UsuarioPeriodo = periodo;


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //fazendo testes
        public IActionResult Periodos()
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
