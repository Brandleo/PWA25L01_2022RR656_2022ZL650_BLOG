using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace L01_2022RR656_2022ZL650.Models
{
    public class roles
    {
        [Key]
        public int rolId { get; set; }
        public string? rol {  get; set; }
    }
}
