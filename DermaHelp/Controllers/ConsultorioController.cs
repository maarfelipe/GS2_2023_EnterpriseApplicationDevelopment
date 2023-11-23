using DermaHelp.Entities;
using DermaHelp.Persistense;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DermaHelp.Controllers
{
    public class ConsultorioController : Controller
    {
        private readonly PostgreDbContext _context;

        public ConsultorioController(PostgreDbContext context)
        {
            _context = context;
        }

        // GET: Consultorio
        public async Task<IActionResult> Index()
        {
            var postgreDbContext = _context.Consultorio.Include(c => c.Endereco);
            return View(await postgreDbContext.ToListAsync());
        }

        // GET: Consultorio/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Consultorio == null)
            {
                return NotFound();
            }

            var consultorio = await _context.Consultorio
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultorio == null)
            {
                return NotFound();
            }

            return View(consultorio);
        }

        // GET: Consultorio/Create
        public IActionResult Create()
        {
            // Get the list of available Enderecos (those not associated with any Consultorio)
            var availableEnderecos = _context.Endereco
                .Where(e => !_context.Consultorio.Any(c => c.EnderecoId == e.Id))
                .Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Id.ToString() })
                .ToList();

            // Pass the list to the view
            ViewData["AvailableEnderecos"] = availableEnderecos;

            return View();
        }

        // POST: Consultorio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cnpj,EnderecoId")] Consultorio consultorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consultorio);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = $"Consultório {consultorio.Id} cadastrado com sucesso.";

                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Id", consultorio.EnderecoId);
            return View(consultorio);
        }

        // GET: Consultorio/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Consultorio == null)
            {
                return NotFound();
            }

            var consultorio = await _context.Consultorio
                .Include(c => c.Endereco) // Include the associated Endereco
                .FirstOrDefaultAsync(m => m.Id == id);

            if (consultorio == null)
            {
                return NotFound();
            }
            // Get the list of available Enderecos (those not associated with any Consultorio)
            var availableEnderecos = _context.Endereco
                .Where(e => !_context.Consultorio.Any(c => c.EnderecoId == e.Id))
                .Select(e => new SelectListItem { Value = e.Id.ToString(), Text = e.Id.ToString() })
                .ToList();

            // Pass the list to the view
            ViewData["AvailableEnderecos"] = availableEnderecos;
            return View(consultorio);
        }

        // POST: Consultorio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Nome,Cnpj,EnderecoId")] Consultorio consultorio)
        {
            if (id != consultorio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consultorio);
                    TempData["SuccessMessage"] = $"Consultório {consultorio.Id} atualizado com sucesso.";

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultorioExists(consultorio.Id))
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
            ViewData["EnderecoId"] = new SelectList(_context.Endereco, "Id", "Id", consultorio.EnderecoId);
            return View(consultorio);
        }

        // GET: Consultorio/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Consultorio == null)
            {
                return NotFound();
            }

            var consultorio = await _context.Consultorio
                .Include(c => c.Endereco)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consultorio == null)
            {
                return NotFound();
            }

            return View(consultorio);
        }

        // POST: Consultorio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Consultorio == null)
            {
                return Problem("Entity set 'PostgreDbContext.Consultorio'  is null.");
            }
            var consultorio = await _context.Consultorio.FindAsync(id);
            if (consultorio != null)
            {
                _context.Consultorio.Remove(consultorio);
            }
            
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Cadastro excluído com sucesso.";
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultorioExists(long id)
        {
          return (_context.Consultorio?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
