using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.AfrinextInvest.com.Identity;

namespace Web.AfrinextInvest.com.Controllers
{
    public class AccountController : Controller
    {
        public readonly UserManager<User> userManager;
        public readonly SignInManager<User> loginManager;
        public readonly RoleManager<Role> roleManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> loginManager, RoleManager<Role> roleManager)
        {
            this.userManager = userManager;
            this.loginManager = loginManager;
            this.roleManager = roleManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel obj)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.UserName = obj.UserName;
                user.Email = obj.Email;
                user.Prenom = obj.Prenom;
                user.Nom = obj.Nom;
                user.DateNaissance = obj.DateNaissance;
                user.PhoneNumber = obj.Portable;

                IdentityResult result = userManager.CreateAsync
                (user, obj.Password).Result;

                if (result.Succeeded)
                {
                    if (!roleManager.RoleExistsAsync("NormalUser").Result)
                    {
                        Role role = new Role();
                        role.Name = "NormalUser";
                        role.Description = "Perform normal operations.";
                        IdentityResult roleResult = roleManager.CreateAsync(role).Result;
                        if (!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "Error while creating role!");
                            return View(obj);
                        }
                    }

                    userManager.AddToRoleAsync(user, "NormalUser").Wait();
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(obj);
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnUrl } ;
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel obj)
        {
            if (ModelState.IsValid)
            {
                var result = await loginManager.PasswordSignInAsync(obj.UserName, obj.Password, obj.RememberMe, false);

                if (result.Succeeded)
                {
                    // Après connexion, on retourne l'utilisateur sur la page où il voulait aller
                    if (!string.IsNullOrEmpty(obj.ReturnUrl) && Url.IsLocalUrl(obj.ReturnUrl))
                    {
                        return Redirect(obj.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "Connexion Echouee!");
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOff()
        {
            await loginManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
