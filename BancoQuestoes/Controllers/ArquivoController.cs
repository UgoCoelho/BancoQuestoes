using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BancoQuestoes.Models;
using BancoQuestoes.Data;

public class ArquivoController : Controller
{
    private readonly AppDbContext _context;

    public ArquivoController(AppDbContext context)
    {
        _context = context;
    }

    // INDEX
    public async Task<IActionResult> Index()
    {
        var dados = await _context.Arquivo
            .Include(a => a.Curso)
            .Include(a => a.Materia)
            .Include(a => a.TipoArquivo)
            .ToListAsync();

        return View(dados);
    }

    // CREATE GET
    public IActionResult Create()
    {
        CarregarCombos();
        return View();
    }

    // CREATE POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Arquivo arquivo)
    {
        // 🔥 SEM ISSO você perde debug de erro
        if (!ModelState.IsValid)
        {
            CarregarCombos(arquivo);
            return View(arquivo);
        }

        try
        {
            _context.Arquivo.Add(arquivo);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Erro ao salvar: " + ex.Message);
            CarregarCombos(arquivo);
            return View(arquivo);
        }

        return RedirectToAction(nameof(Index));
    }

    // EDIT GET
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var arquivo = await _context.Arquivo.FindAsync(id);
        if (arquivo == null) return NotFound();

        CarregarCombos(arquivo);
        return View(arquivo);
    }

    // EDIT POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Arquivo arquivo)
    {
        if (id != arquivo.Id)
            return NotFound();

        if (!ModelState.IsValid)
        {
            CarregarCombos(arquivo);
            return View(arquivo);
        }

        try
        {
            _context.Update(arquivo);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Arquivo.Any(e => e.Id == arquivo.Id))
                return NotFound();

            throw;
        }

        return RedirectToAction(nameof(Index));
    }

    // DETAILS
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var arquivo = await _context.Arquivo
            .Include(a => a.Curso)
            .Include(a => a.Materia)
            .Include(a => a.TipoArquivo)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (arquivo == null) return NotFound();

        return View(arquivo);
    }

    // DELETE GET
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var arquivo = await _context.Arquivo
            .Include(a => a.Curso)
            .Include(a => a.Materia)
            .Include(a => a.TipoArquivo)
            .FirstOrDefaultAsync(m => m.Id == id);

        if (arquivo == null) return NotFound();

        return View(arquivo);
    }

    // DELETE POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var arquivo = await _context.Arquivo.FindAsync(id);

        if (arquivo != null)
        {
            _context.Arquivo.Remove(arquivo);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    // COMBOS
    private void CarregarCombos(Arquivo arquivo = null)
    {
        ViewBag.CursoId = new SelectList(_context.Curso, "CursoId", "Nome", arquivo?.CursoId);
        ViewBag.MateriaId = new SelectList(_context.Materias, "MateriaId", "Nome", arquivo?.MateriaId);
        ViewBag.TipoArquivoId = new SelectList(_context.TipoArquivo, "TipoArquivoId", "Nome", arquivo?.TipoArquivoId);
    }
}