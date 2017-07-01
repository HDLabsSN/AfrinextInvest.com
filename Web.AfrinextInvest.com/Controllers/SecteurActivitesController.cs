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
    public class SecteurActivitesController : Controller
    {
        private readonly AfrinextInvestContext _context;

        public SecteurActivitesController(AfrinextInvestContext context)
        {
            _context = context;    
        }

        // GET: SecteurActivites
        public async Task<IActionResult> Index()
        {
            return View(await _context.SecteurActivite.ToListAsync());
        }

        // GET: SecteurActivites/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secteurActivite = await _context.SecteurActivite
                .SingleOrDefaultAsync(m => m.id == id);
            if (secteurActivite == null)
            {
                return NotFound();
            }

            return View(secteurActivite);
        }

        // GET: SecteurActivites/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SecteurActivites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nomSecteur,description")] SecteurActivite secteurActivite)
        {
            if (ModelState.IsValid)
            {
                _context.Add(secteurActivite);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(secteurActivite);
        }

        // GET: SecteurActivites/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secteurActivite = await _context.SecteurActivite.SingleOrDefaultAsync(m => m.id == id);
            if (secteurActivite == null)
            {
                return NotFound();
            }
            return View(secteurActivite);
        }

        // POST: SecteurActivites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("nomSecteur,description")] SecteurActivite secteurActivite)
        {
            if (id != secteurActivite.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(secteurActivite);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SecteurActiviteExists(secteurActivite.id))
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
            return View(secteurActivite);
        }

        // GET: SecteurActivites/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var secteurActivite = await _context.SecteurActivite
                .SingleOrDefaultAsync(m => m.id == id);
            if (secteurActivite == null)
            {
                return NotFound();
            }

            return View(secteurActivite);
        }

        // POST: SecteurActivites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var secteurActivite = await _context.SecteurActivite.SingleOrDefaultAsync(m => m.id == id);
            _context.SecteurActivite.Remove(secteurActivite);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SecteurActiviteExists(int id)
        {
            return _context.SecteurActivite.Any(e => e.id == id);
        }
    }
}
