using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;




namespace L01_2022RR656_2022ZL650.Models
{
    public class blogDBContext: DbContext
    {


        public blogDBContext(DbContextOptions<blogDBContext> options) : base(options) 
        
        
        
        {
            


        }

        public DbSet<comentarios> comentarios { get; set; }

        public DbSet<calificaciones> calificaciones { get; set; }
        public DbSet<roles> roles { get; set; }
        public DbSet<usuarios> usuarios { get; set; }
        public DbSet<publicaciones> publicaciones { get; set; }

    }
}
