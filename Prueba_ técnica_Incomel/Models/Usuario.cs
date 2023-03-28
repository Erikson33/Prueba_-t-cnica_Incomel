using System;
using System.Collections.Generic;

namespace Prueba__técnica_Incomel.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Idusuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Contraseña { get; set; } = null!;
        public string? TokenRecovery { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
