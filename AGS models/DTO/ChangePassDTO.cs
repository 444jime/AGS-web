using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGS_Models.DTO
{
    public class ChangePassDTO
    {
        [Required]
        [MinLength(8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword", ErrorMessage = "Las contraseñas no coinciden")]
        public string ConfirmNewPassword { get; set; }
    }
}