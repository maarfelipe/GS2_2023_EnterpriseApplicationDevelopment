using DermaHelp.Entities;
using DermaHelp.Persistense;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DermaHelp.Controllers
{
    public class ImagemController : Controller
    {
        private readonly PostgreDbContext _context;

        public ImagemController(PostgreDbContext context)
        {
            _context = context;
        }

        // GET: Imagem
        public async Task<IActionResult> Index()
        {
            var postgreDbContext = _context.Imagem.Include(i => i.Usuario);
            return View(await postgreDbContext.ToListAsync());
        }

        // GET: Imagem/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Imagem == null)
            {
                return NotFound();
            }

            var imagem = await _context.Imagem
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imagem == null)
            {
                return NotFound();
            }

            return View(imagem);
        }

        // GET: Imagem/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id");
            return View();
        }

        // POST: Imagem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataHora,ImageData,Resultado,UsuarioId")] Imagem imagem)
        {
            imagem.DataHora = DateTime.UtcNow;
            _context.Add(imagem);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Imagem {imagem.Id} cadastrada com sucesso.";

            return RedirectToAction(nameof(Index));
        }

        // GET: Imagem/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Imagem == null)
            {
                return NotFound();
            }

            var imagem = await _context.Imagem.FindAsync(id);
            if (imagem == null)
            {
                return NotFound();
            }
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "Id", "Id", imagem.UsuarioId);
            return View(imagem);
        }

        // POST: Imagem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,DataHora,ImageData,Resultado,UsuarioId")] Imagem imagem)
        {
            if (id != imagem.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(imagem);
                TempData["SuccessMessage"] = $"Imagem {imagem.Id} atualizada com sucesso.";

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImagemExists(imagem.Id))
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

        // GET: Imagem/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Imagem == null)
            {
                return NotFound();
            }

            var imagem = await _context.Imagem
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (imagem == null)
            {
                return NotFound();
            }

            return View(imagem);
        }

        // POST: Imagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            if (_context.Imagem == null)
            {
                return Problem("Entity set 'PostgreDbContext.Imagem'  is null.");
            }
            var imagem = await _context.Imagem.FindAsync(id);
            if (imagem != null)
            {
                _context.Imagem.Remove(imagem);
            }
            
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = $"Imagem excluída com sucesso.";

            return RedirectToAction(nameof(Index));
        }

        private bool ImagemExists(long id)
        {
          return (_context.Imagem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
