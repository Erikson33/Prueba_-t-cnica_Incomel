namespace Prueba__técnica_Incomel.Models.ViewModels
{
    public class EmpleadoViewModel
    {
        public int Idempleado { get; set; }
        public string Dpi { get; set; } = null!;
        public string Nombrecompleto { get; set; } = null!;
        public int CantHijos { get; set; }
        public string Salariobase { get; set; }
        public string Bonodecreto { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime? Fechacreacion { get; set; }
        public string? Igss { get; set; }
        public string? Irtra { get; set; }
        public string? Bonopaternidad { get; set; }
        public string? SalarioTotal { get; set; }
        public string? SalarioLiquido { get; set; }
    }
}
