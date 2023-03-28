using LogiSmart;
using Microsoft.AspNetCore.Mvc;
using Prueba__técnica_Incomel.Models;
using Prueba__técnica_Incomel.Models.ViewModels;

namespace Prueba__técnica_Incomel.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly pruebadbContext _context;

        public EmpleadosController(pruebadbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult LstEmpleados()
        {
            List<EmpleadoViewModel> Empleados = new List<EmpleadoViewModel>();
            using (_context)
            {
                Empleados = (from e in _context.Empleados
                            select new EmpleadoViewModel
                            {
                                Idempleado = e.Idempleado,
                                Dpi = e.Dpi,
                                Nombrecompleto = e.Nombrecompleto,
                                CantHijos = e.CantHijos,
                                Salariobase = e.Salariobase.ToString(),
                                Bonodecreto = e.Bonodecreto.ToString(),
                                Usuario = new Usuario() { Idusuario = Convert.ToInt32(e.Idusuario), Nombre = e.IdusuarioNavigation.Nombre },
                                Fechacreacion = e.Fechacreacion,
                                Igss = e.Igss.ToString(),
                                Irtra = e.Irtra.ToString(),
                                Bonopaternidad = e.Bonopaternidad.ToString(),
                                SalarioTotal = e.SalarioTotal.ToString(),
                                SalarioLiquido = e.SalarioLiquido.ToString(),
                            }).ToList();
            }
            return Json(new { Data = Empleados });
        }

        [HttpPost]
        public JsonResult Add(EmpleadoViewModel Empleado)
        {
            try
            {
                int userId = Convert.ToInt32(User.getUserId());

                if (Empleado.Idempleado == 0)
                {
                    if (Empleado.Dpi != null && Empleado.Nombrecompleto != null && Empleado.CantHijos != null && Empleado.Salariobase != null)
                    {

                        Empleado _Empleado = new Empleado
                        {
                            Dpi = Empleado.Dpi,
                            Nombrecompleto = Empleado.Nombrecompleto,
                            CantHijos = Empleado.CantHijos,
                            Salariobase = Convert.ToDouble(Empleado.Salariobase.Replace(".", ",")),
                            Bonodecreto = Convert.ToDouble(Empleado.Bonodecreto.Replace(".",",")),
                            Idusuario = userId,
                            Fechacreacion = Empleado.Fechacreacion,
                            Igss = Convert.ToDouble(Empleado.Igss.Replace(".",",")),
                            Irtra = Convert.ToDouble(Empleado.Irtra.Replace(".",",")),
                            Bonopaternidad = Convert.ToDouble(Empleado.Bonopaternidad.Replace(".",",")),
                            SalarioTotal = Convert.ToDouble(Empleado.SalarioTotal.Replace(".",",")),
                            SalarioLiquido = Convert.ToDouble(Empleado.SalarioLiquido.Replace(".",",")),
                        };

                        _context.Add(_Empleado);
                        _context.SaveChanges();
                        return Json(true);
                    }
                    else
                    {
                        return Json(false);
                    }

                }
                else
                {
                    if (Empleado.Dpi != null && Empleado.Nombrecompleto != null && Empleado.CantHijos != null && Empleado.Salariobase != null)
                    {
                        Empleado _Empleado = new Empleado
                        {
                            Idempleado = Empleado.Idempleado,
                            Dpi = Empleado.Dpi,
                            Nombrecompleto = Empleado.Nombrecompleto,
                            CantHijos = Empleado.CantHijos,
                            Salariobase = Convert.ToDouble(Empleado.Salariobase.Replace(".", ",")),
                            Bonodecreto = Convert.ToDouble(Empleado.Bonodecreto.Replace(".", ",")),
                            Idusuario = userId,
                            Fechacreacion = Empleado.Fechacreacion,
                            Igss = Convert.ToDouble(Empleado.Igss.Replace(".", ",")),
                            Irtra = Convert.ToDouble(Empleado.Irtra.Replace(".", ",")),
                            Bonopaternidad = Convert.ToDouble(Empleado.Bonopaternidad.Replace(".", ",")),
                            SalarioTotal = Convert.ToDouble(Empleado.SalarioTotal.Replace(".", ",")),
                            SalarioLiquido = Convert.ToDouble(Empleado.SalarioLiquido.Replace(".", ",")),
                        };
                        _context.Update(_Empleado);
                        _context.SaveChanges();
                        return Json(true);
                    }
                    else
                    {
                        return Json(false);
                    }

                }
            }
            catch
            {
                return Json(false);
            }

        }

        [HttpPost]
        public JsonResult Eliminar(Empleado empleado)
        {
            if (empleado != null)
            {
                _context.Empleados.Remove(empleado);
                _context.SaveChanges();
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
    }
}
