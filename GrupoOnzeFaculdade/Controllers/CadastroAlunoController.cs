using GrupoOnzeFaculdade.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Xml;

public class CadastroAlunoController : Controller
{
    private readonly ApplicationDbContext _context;

    public CadastroAlunoController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: CadastroAlunos
    public async Task<IActionResult> Index()
    {
        return View(await _context.cadastro_aluno.ToListAsync());
    }

    // GET: CadastroAlunos/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cadastroAluno = await _context.cadastro_aluno
            .FirstOrDefaultAsync(c => c.id == id);
        if (cadastroAluno == null)
        {
            return NotFound();
        }

        return View(cadastroAluno);
    }

    // GET: CadastroAlunos/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: CadastroAlunos/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("id,nome,sobrenome,matricula,endereco,telefone")] CadastroAluno cadastroAluno)
    {
        if (ModelState.IsValid)
        {
            _context.Add(cadastroAluno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(cadastroAluno);
    }

    // GET: CadastroAlunos/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cadastroAluno = await _context.cadastro_aluno.FindAsync(id);
        if (cadastroAluno == null)
        {
            return NotFound();
        }
        return View(cadastroAluno);
    }

    // POST: CadastroAlunos/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("id,nome,sobrenome,matricula,endereco,telefone")] CadastroAluno cadastroAluno)
    {
        if (id != cadastroAluno.id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(cadastroAluno);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!cadastroAlunoExists(cadastroAluno.id))
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
        return View(cadastroAluno);
    }

    // GET: CadastroAlunos/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cadastroAluno = await _context.cadastro_aluno
            .FirstOrDefaultAsync(c => c.id == id);
        if (cadastroAluno == null)
        {
            return NotFound();
        }

        return View(cadastroAluno);
    }



    // POST: CadastroAlunos/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var cadastroAluno = await _context.cadastro_aluno.FindAsync(id);
        _context.cadastro_aluno.Remove(cadastroAluno);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool cadastroAlunoExists(int id)
    {
        return _context.cadastro_aluno.Any(e => e.id == id);
    }
}
