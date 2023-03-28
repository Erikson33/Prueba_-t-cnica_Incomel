using LogiSmart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba__técnica_Incomel.Models;
using Prueba__técnica_Incomel.Models.ViewModels;
using System.Net;
using System.Net.Mail;

namespace Prueba__técnica_Incomel.Controllers
{
    public class RestaurarContraseñaController : Controller
    {
        string urldomain = "https://localhost:7230/";
        private readonly pruebadbContext _context;

        public RestaurarContraseñaController(pruebadbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult StarRecovery()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StarRecovery(RecoveryViewModel Recovery)
        {
            if (!ModelState.IsValid)
            {
                return View(Recovery);
            }
            string token = Encript.Encriptar(Guid.NewGuid().ToString(), "1234");
            Usuario _Recovery = _context.Usuarios.Where(u => u.Email == Recovery.Email && u.FechaNacimiento == Recovery.FechaNacimiento).FirstOrDefault();

            if (_Recovery != null)
            {
                _Recovery.TokenRecovery = token;
                _context.Update(_Recovery);
                _context.SaveChanges();

                EnviarEmail(_Recovery.Email, token);
            }
            else
            {
                TempData["Message_err"] = "El email y fecha de nacimiento no coincide";

                return View(Recovery);

            }
            return View();
        }

        [HttpGet]
        public IActionResult Recovery(string Token)
        {
            RecoveryPasswordViewModel model = new RecoveryPasswordViewModel();
            //Usuario user = _context.Usuarios.Where(u => u.TokenRecovery == Token).FirstOrDefault();
            //if (user == null)
            //{
            //    ViewBag.error = "El enlace a expirado";
            //    return View();
            //}

            model.Token = Token;
            return View(model);
        } 

        [HttpPost]
        public IActionResult Recovery(RecoveryPasswordViewModel RecoveryPasswordViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(RecoveryPasswordViewModel);
                }

                Usuario usuario = _context.Usuarios.Where(u => u.TokenRecovery == RecoveryPasswordViewModel.Token).FirstOrDefault();
                if (usuario != null)
                {
                    usuario.Contraseña = RecoveryPasswordViewModel.ContraseñaConf;
                    usuario.TokenRecovery = null;
                    _context.Update(usuario);
                    _context.SaveChanges();
                }
                return View(RecoveryPasswordViewModel);
                
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }


        public void EnviarEmail(string EmailDesting, string token)
        {
            // Configurar los detalles del correo electrónico
            string EmailOrigen = "testdesarrollo573@gmail.com"; // dirección de correo electrónico del remitente
            string password = "fxfyhzmsrqifohod"; // contraseña del remitente
            string subject = "Recuperación de contraseña"; // asunto del correo electrónico
            string url = urldomain + "RestaurarContraseña/Recovery/?Token=" + token;
            string body = "<p>Correo para restablezer de contraseña</p><br><a href='"+url+"'>Click para restablezer</a>"; // contenido del correo electrónico

            // Configurar el cliente de correo electrónico
            SmtpClient client = new SmtpClient("smtp.gmail.com"); // servidor SMTP de ejemplo
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(EmailOrigen, password);

            // Crear el correo electrónico y enviarlo
            MailMessage message = new MailMessage(EmailOrigen, EmailDesting, subject, body);
            message.IsBodyHtml = true;
            client.Send(message);
        }
    }
}
