using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BancoQuestoes.Data;
using BancoQuestoes.Models;

namespace BancoQuestoes.Controllers
{
    public class TipoArquivoeController : Controller
    {
        private readonly AppDbContext _context;

        public TipoArquivoeController(AppDbContext context)
        {
            _context = context;
        }

        // GET: TipoArquivoe
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoArquivo.ToListAsync());
        }

        // GET: TipoArquivoe/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoArquivo = await _context.TipoArquivo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoArquivo == null)
            {
                return NotFound();
            }

            return View(tipoArquivo);
        }

        // GET: TipoArquivoe/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoArquivoe/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] TipoArquivo tipoArquivo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoArquivo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoArquivo);
        }

        // GET: TipoArquivoe/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoArquivo = await _context.TipoArquivo.FindAsync(id);
            if (tipoArquivo == null)
            {
                return NotFound();
            }
            return View(tipoArquivo);
        }

        // POST: TipoArquivoe/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] TipoArquivo tipoArquivo)
        {
            if (id != tipoArquivo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoArquivo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoArquivoExists(tipoArquivo.Id))
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
            return View(tipoArquivo);
        }

        // GET: TipoArquivoe/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoArquivo = await _context.TipoArquivo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoArquivo == null)
            {
                return NotFound();
            }

            return View(tipoArquivo);
        }

        // POST: TipoArquivoe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoArquivo = await _context.TipoArquivo.FindAsync(id);
            if (tipoArquivo != null)
            {
                _context.TipoArquivo.Remove(tipoArquivo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoArquivoExists(int id)
        {
            return _context.TipoArquivo.Any(e => e.Id == id);
        }
    }
}
