using LogiSmart;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba__técnica_Incomel.Models;
using System.Security.Claims;

namespace Prueba__técnica_Incomel.Controllers
{
    public class LoginController : Controller
    {
        private readonly pruebadbContext _context;

        public LoginController(pruebadbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.Class = TempData["class"];
            ViewBag.Icon = TempData["icon"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ingresar(Usuario user)
        {
            Usuario _user = UserIsvalid(user);
            if (_user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, _user.Idusuario.ToString()),
                    new Claim(ClaimTypes.Name, _user.Nombre),
                    new Claim(ClaimTypes.Email, _user.Email),
                };

                //claims.Add(new Claim(ClaimTypes.Role, _user.IdrolNavigation.Descripcion));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                TempData["Bienvenido"] = "Bienvenido";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Message"] = "El email y la contraseña no coiciden";
                TempData["class"] = "alert alert-danger alert-dismissible fade show";
                TempData["icon"] = "bi bi-x-circle me-1";
                return RedirectToAction("Index", "Login");
            }
        }

        public async Task<IActionResult> LoginOut()
        {

            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Login");
        }

        private Usuario UserIsvalid(Usuario user)
        {
            Usuario usuario;
            if (user.Contraseña != null && user.Email != null)
            {
                user.Contraseña = Encript.Encriptar(user.Contraseña, "1234");
                usuario = _context.Usuarios.Where(e => e.Email == user.Email && e.Contraseña == user.Contraseña).FirstOrDefault();
                return usuario;
            }

            return null;
        }
    }
}
