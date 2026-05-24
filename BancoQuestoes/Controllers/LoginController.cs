using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BancoQuestoes.Data;
using BancoQuestoes.Models;

namespace BancoQuestoes.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult Index()
        {
            // Se já estiver logado, redireciona para Home
            if (HttpContext.Session.GetString("UsuarioNome") != null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        // POST: Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var usuario = await _context.Usuario
                .Include(u => u.Curso)
                .FirstOrDefaultAsync(u => u.Matricula == model.Matricula);

            if (usuario == null)
            {
                ModelState.AddModelError("Matricula", "Matrícula não encontrada.");
                return View(model);
            }

            // Salva dados na sessão
            HttpContext.Session.SetInt32("UsuarioId", usuario.UsuarioId);
            HttpContext.Session.SetString("UsuarioNome", usuario.Nome);
            HttpContext.Session.SetString("UsuarioCurso", usuario.Curso?.Nome ?? "");
            HttpContext.Session.SetInt32("UsuarioPeriodo", usuario.Periodo);

            return RedirectToAction("Index", "Home");
        }

        // GET: Login/Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
