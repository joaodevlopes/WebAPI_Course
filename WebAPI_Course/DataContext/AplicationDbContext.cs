using Microsoft.EntityFrameworkCore;
using WebAPI_Course.Models;

namespace WebAPI_Course.DataContext
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {     
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
    }
}
