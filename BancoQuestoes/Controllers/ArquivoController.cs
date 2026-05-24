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

    public async Task<IActionResult> PorMateria(int materiaId, int periodo)
    {
        var arquivos = await _context.Arquivo
            .Include(a => a.Curso)
            .Include(a => a.Materia)
            .Include(a => a.TipoArquivo)
            .Where(a => a.MateriaId == materiaId)
            .ToListAsync();

        ViewBag.Periodo = periodo;

        return View(arquivos);
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
    public async Task<IActionResult> Create([Bind("Id,Titulo,Professor,Tag,Descricao,CursoId,MateriaId,TipoArquivoId,ArquivoNome,ArquivoUpload")] Arquivo arquivo)
    {
        if (arquivo.ArquivoUpload != null && arquivo.ArquivoUpload.Length > 0)
        {
            string pasta = Path.Combine(Directory.GetCurrentDirectory(), "Storage", "Arquivos");

            if (!Directory.Exists(pasta))
                Directory.CreateDirectory(pasta);

            string nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(arquivo.ArquivoUpload.FileName);
            string caminhoCompleto = Path.Combine(pasta, nomeArquivo);

            using (FileStream fs = new FileStream(caminhoCompleto, FileMode.Create))
            {
                await arquivo.ArquivoUpload.CopyToAsync(fs);
            }

            arquivo.ArquivoNome = nomeArquivo;
        }

        ModelState.Remove("Curso");
        ModelState.Remove("Materia");
        ModelState.Remove("TipoArquivo");

        if (ModelState.IsValid)
        {
            _context.Add(arquivo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        CarregarCombos(arquivo); 
        return View(arquivo);
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

    // DOWNLOAD
    public async Task<IActionResult> Download(int id)
    {
        var arquivo = await _context.Arquivo.FindAsync(id);

        if (arquivo == null)
            return NotFound();

        var caminho = Path.Combine(
            Directory.GetCurrentDirectory(),
            "Storage",
            "Arquivos",
            arquivo.ArquivoNome
        );

        if (!System.IO.File.Exists(caminho))
            return NotFound();

        var bytes = await System.IO.File.ReadAllBytesAsync(caminho);

        return File(
            bytes,
            "application/octet-stream",
            arquivo.ArquivoNome
        );
    }
}