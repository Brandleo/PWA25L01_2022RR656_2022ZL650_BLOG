using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;


namespace L01_2022RR656_2022ZL650.Models
{
    public class comentarios
    {

        [Key]

        public int cometarioId { get; set; }

        public int ? publicacionId { get; set; }

        public string comentario { get; set; }

        public int? usuarioId {  get; set; }




    }
}
