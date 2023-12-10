using CellphoneAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CellphoneAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Cellphone> Cellphones { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options) 
            :base(options)
        { 
        }
    }
}
