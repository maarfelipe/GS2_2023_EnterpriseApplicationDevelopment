using DermaHelp.Entities;
using DermaHelp.Persistense;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DermaHelp.Controllers
{
    public class ConsultaController : Controller
    {
        private readonly PostgreDbContext _context;

        public ConsultaController(PostgreDbContext context)
        {
            _context = context;
        }

        // GET: Consulta
        public async Task<IActionResult> Index()
        {
            var postgreDbContext = _context.Consulta.Include(c => c.Consultorio).Include(c => c.Medico).Include(c => c.Usuario);
            return View(await postgreDbContext.ToListAsync());
        }

        // GET: Consulta/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta
                .Include(c => c.Consultorio)
                .Include(c => c.Medico)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consulta/Create
        public IActionResult Create()
        {
            ViewData["ConsultorioId"] = new SelectList(_context.Consultorio, "Id", "Id");
            ViewData["MedicoId"] = new SelectList(_context.Medico, "Id", "Id");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id");
            return View();
        }

        // POST: Consulta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataHora,UsuarioId,MedicoId,ConsultorioId")] Consulta consulta)
        {
            //if (ModelState.IsValid)
            {
                consulta.DataHora = DateTime.UtcNow;
                _context.Add(consulta);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Consulta registrada com sucesso.";
                return RedirectToAction(nameof(Index));
            }

            //ViewData["ConsultorioId"] = new SelectList(_context.Consultorio, "Id", "Id", consulta.ConsultorioId);
            //ViewData["MedicoId"] = new SelectList(_context.Medico, "Id", "Id", consulta.MedicoId);
            //ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", consulta.UsuarioId);
            //return View(consulta);
        }

        // GET: Consulta/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta == null)
            {
                return NotFound();
            }
            ViewData["ConsultorioId"] = new SelectList(_context.Consultorio, "Id", "Id", consulta.ConsultorioId);
            ViewData["MedicoId"] = new SelectList(_context.Medico, "Id", "Id", consulta.MedicoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", consulta.UsuarioId);
            return View(consulta);
        }

        // POST: Consulta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,DataHora,UsuarioId,MedicoId,ConsultorioId")] Consulta consulta)
        {
            if (id != consulta.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);

                    TempData["SuccessMessage"] = "Dados da consulta alterados com sucesso.";
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.Id))
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
            //ViewData["ConsultorioId"] = new SelectList(_context.Consultorio, "Id", "Id", consulta.ConsultorioId);
            //ViewData["MedicoId"] = new SelectList(_context.Medico, "Id", "Id", consulta.MedicoId);
            //ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", consulta.UsuarioId);
            //return View(consulta);
        }

        // GET: Consulta/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consulta
                .Include(c => c.Consultorio)
                .Include(c => c.Medico)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Consulta == null)
            {
                return Problem("Entity set 'PostgreDbContext.Consulta'  is null.");
            }
            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta != null)
            {
                _context.Consulta.Remove(consulta);
            }
            
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Consulta excluída com sucesso.";
            return RedirectToAction(nameof(Index));
        }

        private bool ConsultaExists(long id)
        {
          return (_context.Consulta?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
