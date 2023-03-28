using LogiSmart;
using Microsoft.AspNetCore.Mvc;
using Prueba__técnica_Incomel.Models;
using Prueba__técnica_Incomel.Models.ViewModels;

namespace Prueba__técnica_Incomel.Controllers
{
    public class RegistrarseController : Controller
    {
        private readonly pruebadbContext _context;

        public RegistrarseController(pruebadbContext context)
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

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idusuario,Nombre,Email,FechaNacimiento,Contraseña,ContraseñaConf")] UsuarioViewModel usuario)
        {
            if (UsuarioExists(usuario.Email))
            {
                TempData["Message_err"] = "Este email ya esta registrado";
                return View(usuario);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (usuario.Contraseña == usuario.ContraseñaConf)
                    {
                        Usuario User = new Usuario
                        {
                            Nombre = usuario.Nombre,
                            Email = usuario.Email,
                            FechaNacimiento = usuario.FechaNacimiento,
                            Contraseña = Encript.Encriptar(usuario.Contraseña, "1234"),
                        };
                        _context.Add(User);
                        TempData["Message"] = "Se registro correctamente";
                        TempData["class"] = "alert alert-success alert-dismissible fade show";
                        TempData["icon"] = "bi bi-check-circle me-1";
                        await _context.SaveChangesAsync();
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        TempData["Message_err"] = "Las contraseñas no coinciden";
                        return View(usuario);

                    }
                }
                return View(usuario);
            }
        }


        private bool UsuarioExists(string correo)
        {
            return _context.Usuarios.Any(e => e.Email == correo);
        }

    }
}
