using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_ExpenseTRacker.Model
{
    [Table("UserExpense")]
    public class Expenses
    {
        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
    }
}
