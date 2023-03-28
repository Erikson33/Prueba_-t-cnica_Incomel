using System.ComponentModel.DataAnnotations;

namespace Prueba__técnica_Incomel.Models.ViewModels
{
    public class RecoveryPasswordViewModel
    {
        public string Token { get; set; }

        [Required]
        public string Contraseña { get; set; } = null!;

        [Compare("Contraseña")]
        [Required]
        public string ContraseñaConf { get; set; } = null!;

    }
}
