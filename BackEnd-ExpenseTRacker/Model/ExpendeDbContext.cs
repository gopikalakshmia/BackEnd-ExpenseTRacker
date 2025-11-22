using Microsoft.EntityFrameworkCore;

namespace BackEnd_ExpenseTRacker.Model
{
    public class ExpenseDbContext:DbContext
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options)
        {

        }
        public DbSet<Expenses> Expenses { get; set; }
    }
}
