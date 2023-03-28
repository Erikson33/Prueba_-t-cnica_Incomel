using System;
using System.Collections.Generic;

namespace Prueba__técnica_Incomel.Models
{
    public partial class Empleado
    {
        public int Idempleado { get; set; }
        public string Dpi { get; set; } = null!;
        public string Nombrecompleto { get; set; } = null!;
        public int CantHijos { get; set; }
        public double Salariobase { get; set; }
        public double Bonodecreto { get; set; }
        public int Idusuario { get; set; }
        public DateTime? Fechacreacion { get; set; }
        public double? Igss { get; set; }
        public double? Irtra { get; set; }
        public double? Bonopaternidad { get; set; }
        public double? SalarioTotal { get; set; }
        public double? SalarioLiquido { get; set; }

        public virtual Usuario IdusuarioNavigation { get; set; } = null!;
    }
}
