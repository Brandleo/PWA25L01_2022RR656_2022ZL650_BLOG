using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace L01_2022RR656_2022ZL650.Models
{
    public class calificaciones
    {
        [Key]
        public int calificacionId { get; set; }

        public int ? publicacionId { get; set; }

        public int? usuarioId { get; set; }


        public int ? calificacion {  get; set; }

    }
}
