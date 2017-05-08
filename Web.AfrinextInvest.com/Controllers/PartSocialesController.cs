using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web.AfrinextInvest.com.Models;

namespace Web.AfrinextInvest.com.Controllers
{
    public class PartSocialesController : Controller
    {
        private readonly AfrinextInvestContext _context;

        public PartSocialesController(AfrinextInvestContext context)
        {
            _context = context;    
        }

        // GET: PartSociales
        public async Task<IActionResult> Index()
        {
            return View(await _context.PartSociale.ToListAsync());
        }

        // GET: PartSociales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partSociale = await _context.PartSociale
                .SingleOrDefaultAsync(m => m.Id == id);
            if (partSociale == null)
            {
                return NotFound();
            }

            return View(partSociale);
        }

        // GET: PartSociales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PartSociales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomActivite,DescriptionActivite,AgeActivite,ChiffreAffaire,NbPartsACeder,PrixUnitaire,SecteurActivite,Pays,ActiviteVerifiee")] PartSociale partSociale)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partSociale);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(partSociale);
        }

        // GET: PartSociales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partSociale = await _context.PartSociale.SingleOrDefaultAsync(m => m.Id == id);
            if (partSociale == null)
            {
                return NotFound();
            }
            return View(partSociale);
        }

        // POST: PartSociales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomActivite,DescriptionActivite,AgeActivite,ChiffreAffaire,NbPartsACeder,PrixUnitaire,SecteurActivite,Pays,ActiviteVerifiee")] PartSociale partSociale)
        {
            if (id != partSociale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partSociale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartSocialeExists(partSociale.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(partSociale);
        }

        // GET: PartSociales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partSociale = await _context.PartSociale
                .SingleOrDefaultAsync(m => m.Id == id);
            if (partSociale == null)
            {
                return NotFound();
            }

            return View(partSociale);
        }

        // POST: PartSociales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partSociale = await _context.PartSociale.SingleOrDefaultAsync(m => m.Id == id);
            _context.PartSociale.Remove(partSociale);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool PartSocialeExists(int id)
        {
            return _context.PartSociale.Any(e => e.Id == id);
        }
    }
}
