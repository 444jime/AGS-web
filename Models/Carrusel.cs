using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGS_Models
{
    public class Carrusel
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string ImageUrl { get; set; } // Aquí guardaremos la URL de S3

        public string? Title { get; set; } // Título opcional

        public int SortOrder { get; set; } // Para ordenar las imágenes en el carrusel

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
