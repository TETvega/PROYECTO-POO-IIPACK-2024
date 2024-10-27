using System.ComponentModel.DataAnnotations;

namespace InmobiliariaUNAH.Dtos.Auth
{
    public class RegisterDto
    {
        [Display(Name = "Correo Electronico")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [EmailAddress(ErrorMessage = "El campo {0} no es valido.")]
        public string Email { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "La contraseña debe ser segura y contener al menos 8 caracteres, incluyendo minúsculas, mayúsculas, números y caracteres especiales.")]
        public string Password { get; set; }

        [Display(Name = "Confirmar Contraseña.")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [Compare(nameof(Password), ErrorMessage = "Las conotraseñas no coinciden")]
        public string ConfirmPassword { get; set; }
    }
}
