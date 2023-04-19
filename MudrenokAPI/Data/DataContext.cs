using Microsoft.EntityFrameworkCore;
using MudrenokAPI.Models;

namespace MudrenokAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option)
        {

        }

        public DbSet<Jewelry> Jewelry { get; set; }
    }
}
