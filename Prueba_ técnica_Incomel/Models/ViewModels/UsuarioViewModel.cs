namespace Prueba__técnica_Incomel.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public int Idusuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime FechaNacimiento { get; set; }
        public string Contraseña { get; set; } = null!;

        public string ContraseñaConf { get; set; } = null!;
    }
}
