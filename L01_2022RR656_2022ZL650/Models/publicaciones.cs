using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace L01_2022RR656_2022ZL650.Models
{
    public class publicaciones
    {
        [Key]
        public int publicacionId { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public int? usuarioId { get; set; }
    }
}
