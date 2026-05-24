using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BancoQuestoes.Models;
using BancoQuestoes.Data;

namespace BancoQuestoes.Controllers
{
    public class TipoArquivoController : Controller
    {
        private readonly AppDbContext _context;

        public TipoArquivoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TipoArquivo
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoArquivo.ToListAsync());
        }

        // GET: TipoArquivo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoarquivo = await _context.TipoArquivo
                .FirstOrDefaultAsync(m => m.TipoArquivoId == id);

            if (tipoarquivo == null)
            {
                return NotFound();
            }

            return View(tipoarquivo);
        }

        // GET: TipoArquivo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoArquivo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoArquivoId,Nome")] TipoArquivo tipoarquivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoarquivo);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(tipoarquivo);
        }

        // GET: TipoArquivo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoarquivo = await _context.TipoArquivo.FindAsync(id);

            if (tipoarquivo == null)
            {
                return NotFound();
            }

            return View(tipoarquivo);
        }

        // POST: TipoArquivo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoArquivoId,Nome")] TipoArquivo tipoarquivo)
        {
            if (id != tipoarquivo.TipoArquivoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoarquivo);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoArquivoExists(tipoarquivo.TipoArquivoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            return View(tipoarquivo);
        }

        // GET: TipoArquivo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoarquivo = await _context.TipoArquivo
                .FirstOrDefaultAsync(m => m.TipoArquivoId == id);

            if (tipoarquivo == null)
            {
                return NotFound();
            }

            return View(tipoarquivo);
        }

        // POST: TipoArquivo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoarquivo = await _context.TipoArquivo.FindAsync(id);

            if (tipoarquivo != null)
            {
                _context.TipoArquivo.Remove(tipoarquivo);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool TipoArquivoExists(int id)
        {
            return _context.TipoArquivo.Any(e => e.TipoArquivoId == id);
        }
    }
}