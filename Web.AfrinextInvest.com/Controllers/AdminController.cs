using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Net;
using System.Threading.Tasks;
using Web.AfrinextInvest.com.Data;
using Web.AfrinextInvest.com.Identity;
using Web.AfrinextInvest.com.Models;

namespace Web.AfrinextInvest.com.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly AfrinextInvestContext _context;
        private readonly IdentityContext _identityContext;
        private readonly UserManager<User> _usermanager;
        private readonly RoleManager<Role> _rolemanager;

        public AdminController(AfrinextInvestContext context, IdentityContext identityContext, UserManager<User> usermanager, RoleManager<Role> rolemanager)
        {
            _context = context;
            _usermanager = usermanager;
            _rolemanager = rolemanager;
            _identityContext = identityContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        /**
         * GESTION DES UTILISATEURS
         **/

        // Liste des utilisateurs
        [Route("Admin/Users")]
        [HttpGet]
        public IActionResult UsersIndex()
        {
            var utilisateurs = _identityContext.Users;
            return View(utilisateurs);
        }

        // Création d'un utilisateur
        [Route("Admin/User/Create")]
        [HttpGet]
        public IActionResult UserCreate()
        {
            var roles = _identityContext.Roles;
            ViewData["Roles"] = new SelectList(roles, "id", "Name", "Description");
            return View();
        }

        [Route("Admin/User/Create")]
        [HttpPost]
        public IActionResult UserCreate([Bind("Prenom", "Nom", "UserName", "Email", "Portable", "DateNaissance", "Password", "ConfirmPassword ")] RegisterViewModel objet)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.Prenom = objet.Prenom;
                user.Nom = objet.Nom;
                user.UserName = objet.UserName;
                user.Email = objet.Email;
                user.PhoneNumber = objet.Portable;

                IdentityResult result = _usermanager.CreateAsync(user, objet.Password).Result;

                if (result.Succeeded)
                {
                    if (!_rolemanager.RoleExistsAsync("SuperAdmin").Result)
                        _rolemanager.CreateAsync(new Role { Name = "SuperAdmin", Description = "Perform normal operations." });

                    _usermanager.AddToRoleAsync(user, "SuperAdmin").Wait();
                    return RedirectToAction("UsersIndex", "Admin");
                }
            }
            return View(objet);
        }

        // Détails d'un utilisateur
        [Route("Admin/User/{UserName}")]
        [HttpGet]
        public async Task<IActionResult> UserDetails(string username)
        {
            var utilisateur = await _usermanager.FindByNameAsync(username);

            return View(utilisateur);
        }

        /**
         * GESTION DES ROLES
         */
        // Liste des Roles
        [Route("Admin/Roles")]
        [HttpGet]
        public IActionResult RolesIndex()
        {
            var roles = _identityContext.Roles;
            return View(roles);
        }

        // Ajout d'un rôle
        [Route("Admin/Role/Create")]
        [HttpGet]
        public IActionResult RoleCreate()
        {
            return View();
        }

        [Route("Admin/Role/Create")]
        [HttpPost]
        public async Task<IActionResult> RoleCreate([Bind("")] Role role)
        {
            if (ModelState.IsValid)
            {
                _identityContext.Roles.Add(role);
                await _identityContext.SaveChangesAsync();
                return RedirectToAction("RolesIndex");
            }
            return View();
        }


        /**
         * GESTION DES CLAIMS
         */
        // Liste des Roles
        [Route("Admin/Claims")]
        public IActionResult ClaimsIndex()
        {
            var claims = _identityContext.RoleClaims;
            return View(claims);
        }


        /*
         * GESTION DES PROJETS
         **/

        // Liste des projets
        [Route("Admin/Projets")]
        [HttpGet]
        public async Task<IActionResult> ProjectIndex()
        {
            var projets = await _context.Projets.Include(p => p.SecteurActvite).ToListAsync();
            return View(projets);
        }

        [HttpGet]
        [Route("Admin/Projet/{Id}/Details")]
        public async Task<IActionResult> ProjectDetails(int? Id)
        {
            if (Id == null)
            return NotFound();

            Projet projet = await _context.Projets.FindAsync(Id);

            if (projet == null)
            return NotFound();

            return View(projet);
        }

        [Route("Admin/Projet/{Id}/Validate")]
        public async Task<IActionResult> ProjectValidate(int? Id)
        {
            if (Id == null)
            return NotFound();

            try
            {
                Projet projet = await _context.Projets.FindAsync(Id);

                if (projet == null)
                    return NotFound();

                projet.State = "Validé";
                _context.Update(projet);
                await _context.SaveChangesAsync();
                return RedirectToAction("ProjectIndex");
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View();
        }

        [Route("Admin/Projet/{Id}/Hold")]
        public async Task<IActionResult> ProjectHold(int? Id)
        {
            if (Id == null)
                return NotFound();

            try
            {
                Projet projet = await _context.Projets.FindAsync(Id);

                if (projet == null)
                    return NotFound();

                projet.State = "Suspendu";
                await _context.SaveChangesAsync();
                return RedirectToAction("ProjectIndex");
            }
            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            return View();
        }
    }
}