using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Web.AfrinextInvest.com.Models;

namespace Web.AfrinextInvest.com.Controllers
{
    public class ProjetsController : Controller
    {
        private readonly AfrinextInvestContext _context;

        public ProjetsController(AfrinextInvestContext context)
        {
            _context = context;    
        }

        // GET: Projets
        public async Task<IActionResult> Index()
        {
            var afrinextInvestContext = _context.Projets.Include(p => p.SecteurActvite);
            return View(await afrinextInvestContext.ToListAsync());
        }

        // GET: Projets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projet = await _context.Projets
                .Include(p => p.SecteurActvite)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (projet == null)
            {
                return NotFound();
            }

            return View(projet);
        }

        // GET: Projets/Create
        public IActionResult Create()
        {
            ViewData["SecteurId"] = new SelectList(_context.SecteurActivite, "id", "nomSecteur");
            return View();
        }

        // POST: Projets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nom,Description,Pays,SecteurId,BudgetRequis")] Projet projet)
        {
            if (ModelState.IsValid)
            {
                // L'enregistrement de la date de création du projet se fait de façon automatique
                projet.DateCreation = DateTime.Now;

                // Par défaut le projet est enregistré en tant que brouillon
                projet.isDraft = true;

                // Par défaut le projet n'est pas vérifié par les administrateurs
                projet.isVerified = false;

                _context.Add(projet);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["SecteurId"] = new SelectList(_context.SecteurActivite, "id", "nomSecteur", projet.SecteurId);
            return View(projet);
        }

        // GET: Projets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projet = await _context.Projets.SingleOrDefaultAsync(m => m.Id == id);
            if (projet == null)
            {
                return NotFound();
            }
            ViewData["SecteurId"] = new SelectList(_context.SecteurActivite, "id", "nomSecteur", projet.SecteurId);
            return View(projet);
        }

        // POST: Projets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nom,Description,Pays,SecteurId,BudgetRequis")] Projet projet)
        {
            if (id != projet.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjetExists(projet.Id))
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
            ViewData["SecteurId"] = new SelectList(_context.SecteurActivite, "id", "nomSecteur", projet.SecteurId);
            return View(projet);
        }

        // GET: Projets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projet = await _context.Projets
                .Include(p => p.SecteurActvite)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (projet == null)
            {
                return NotFound();
            }

            return View(projet);
        }

        // POST: Projets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projet = await _context.Projets.SingleOrDefaultAsync(m => m.Id == id);
            _context.Projets.Remove(projet);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProjetExists(int id)
        {
            return _context.Projets.Any(e => e.Id == id);
        }
    }
}
