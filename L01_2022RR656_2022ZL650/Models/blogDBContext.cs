using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;




namespace L01_2022RR656_2022ZL650.Models
{
    public class blogDBContext: DbContext
    {


        public blogDBContext(DbContextOptions<blogDBContext> options) : base(options) 
        
        
        
        {
            


        }



    }
}
