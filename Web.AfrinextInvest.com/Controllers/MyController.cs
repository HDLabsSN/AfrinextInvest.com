using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.AfrinextInvest.com.Data;
using Web.AfrinextInvest.com.Identity;
using Web.AfrinextInvest.com.Models;

namespace Web.AfrinextInvest.com.Controllers
{
    [Authorize]
    public class MyController : Controller
    {
        private readonly AfrinextInvestContext _context;
        private readonly IdentityContext _identitycontext;
        private readonly string _userId;
        private readonly UserManager<User> _usermanager;

        public MyController(AfrinextInvestContext context, IdentityContext identitycontext, UserManager<User> usermanager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _identitycontext = identitycontext;
            _usermanager = usermanager;
            _userId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public async Task<IActionResult> Index()
        {
            var loggedInUser = await _usermanager.FindByIdAsync(this._userId);
            string Name = loggedInUser.Prenom + " " + loggedInUser.Nom;
            ViewData.Add("Nom", Name);
            return View();
        }

        public async Task<IActionResult> Profile()
        {
            var loggedInUser = await _usermanager.FindByIdAsync(this._userId);
            string Name = loggedInUser.Prenom + " " + loggedInUser.Nom;
            ViewData.Add("Nom", Name);
            return View(loggedInUser);
        }

        [Route("My/Profile/Edit")]
        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var loggedInUser = await _usermanager.FindByIdAsync(this._userId);
            string Name = loggedInUser.Prenom + " " + loggedInUser.Nom;
            ViewData.Add("Nom", Name);
            return View(loggedInUser);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile([Bind("Prenom","Nom","UserName","Email","Bio")] User user)
        {
            var loggedInUser = await _usermanager.FindByIdAsync(this._userId);
            string Name = loggedInUser.Prenom + " " + loggedInUser.Nom;
            ViewData.Add("Nom", Name);

            if (ModelState.IsValid)
            {
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            return View(loggedInUser);
        }
    }
}