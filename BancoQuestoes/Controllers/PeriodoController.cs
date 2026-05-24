using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BancoQuestoes.Data;
using BancoQuestoes.Models;

public class PeriodoController : Controller
{
    private readonly AppDbContext _context;

    public PeriodoController(AppDbContext context)
    {
        _context = context;
    }

    // INDEX
    public async Task<IActionResult> Index()
    {
        var lista = await _context.Periodo
            .Include(p => p.Curso)
            .ToListAsync();

        return View(lista);
    }

    // CREATE GET
    public IActionResult Create()
    {
        CarregarCursos();
        return View();
    }

    // CREATE POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("PeriodoId,Numero,CursoId")] Periodo periodo)
    {
        if (ModelState.IsValid)
        {
            _context.Add(periodo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        CarregarCursos();
        return View(periodo);
    }

    // EDIT GET
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var periodo = await _context.Periodo.FindAsync(id);
        if (periodo == null) return NotFound();

        CarregarCursos(periodo.CursoId);
        return View(periodo);
    }

    // EDIT POST
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("PeriodoId,Numero,CursoId")] Periodo periodo)
    {
        if (id != periodo.PeriodoId)
            return NotFound();

        if (ModelState.IsValid)
        {
            _context.Update(periodo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        CarregarCursos(periodo.CursoId);
        return View(periodo);
    }

    // DELETE GET
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var periodo = await _context.Periodo
            .Include(p => p.Curso)
            .FirstOrDefaultAsync(p => p.PeriodoId == id);

        if (periodo == null) return NotFound();

        return View(periodo);
    }

    // DELETE POST
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var periodo = await _context.Periodo.FindAsync(id);

        if (periodo != null)
        {
            _context.Periodo.Remove(periodo);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    // CARREGA DROPDOWN (CORRETO)
    private void CarregarCursos(int? selectedId = null)
    {
        ViewBag.Cursos = new SelectList(
            _context.Curso
                .OrderBy(c => c.Nome)
                .ToList(),
            "CursoId",
            "Nome",
            selectedId
        );
    }
}