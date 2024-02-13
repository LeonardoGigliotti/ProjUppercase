using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoUppercase.Models;

namespace ProjetoUppercase.Controllers
{
    public class CarrosController : Controller
    {
        private readonly Context _context;

        public CarrosController(Context context)
        {
            _context = context;
        }

        // GET: Carros
        public async Task<IActionResult> Index(int pg = 1)
        {
            List<Carro> carro = _context.Carro.ToList();

            const int pageSize = 6;
            if (pg < 1)
                pg = 1;

            int recsCount = carro.Count();

            var pager = new Pager(recsCount, pg, pageSize);

            int recSkip = (pg - 1) * pageSize;

            var data = carro.Skip(recSkip).Take(pager.PageSize).ToList();

            this.ViewBag.Pager = pager;

            /* return _context.Carro != null ?
                    View(await _context.Carro.ToListAsync()) :
                    Problem("Entity set 'Context.Carro' is null"); */

            return View(data);
        }

        // GET: Carros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Carro == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carro == null)
            {
                return NotFound();
            }

            if (carro.Foto is not null)
                carro.ImagemCarroBase64 = Convert.ToBase64String(carro.Foto);

            return View(carro);
        }

        // GET: Carros/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Carros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Foto,Nome,Marca,Modelo,Ano,Cor,Preco,ImagemCarro")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                if(carro.ImagemCarro is not null)
                {
                    using (var ms = new MemoryStream())
                    {
                        await carro.ImagemCarro.CopyToAsync(ms);
                        carro.Foto = ms.ToArray();
                    }
                }        
                _context.Add(carro);
                await _context.SaveChangesAsync();
                TempData["Mensagem"] = "Carro Criado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(carro);
        }

        // GET: Carros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Carro == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro.FindAsync(id);
            if (carro == null)
            {
                return NotFound();
            }

            if (carro.Foto is not null)

                using (MemoryStream memoryStream = new MemoryStream(carro.Foto))
            {
                carro.ImagemCarro = new FormFile(memoryStream, 0, carro.Foto.Length, null, carro.Nome);
            }

            if (carro.ImagemCarro is not null)
                carro.ImagemCarroBase64 = Convert.ToBase64String(carro.Foto);

            return View(carro);
        }

        // POST: Carros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Foto,Nome,Marca,Modelo,Ano,Cor,Preco,ImagemCarro")] Carro carro)
        {
            if (id != carro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (carro.ImagemCarro is null)
                    {
                        var carroDb = _context.Carro.AsNoTracking().FirstOrDefault(c => c.Id == carro.Id);
                        carro.Foto = carroDb.Foto;
                    }
                    else
                    {
                        using (var ms = new MemoryStream())
                        {
                            await carro.ImagemCarro.CopyToAsync(ms);
                            carro.Foto = ms.ToArray();
                        }
                    }

                    var entry = _context.Entry(carro);
                    entry.State = EntityState.Modified;

                    _context.Update(carro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarroExists(carro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["Mensagem"] = "Carro Editado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(carro);
        }

        // GET: Carros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Carro == null)
            {
                return NotFound();
            }

            var carro = await _context.Carro
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        // POST: Carros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Carro == null)
            {
                return Problem("Entity set 'Context.Carro'  is null.");
            }
            var carro = await _context.Carro.FindAsync(id);
            if (carro != null)
            {
                _context.Carro.Remove(carro);
            }

            await _context.SaveChangesAsync();
            TempData["Mensagem"] = "Carro Excluido com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        private bool CarroExists(int id)
        {
            return (_context.Carro?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
