using BackEnd_ExpenseTRacker.Model;
using Microsoft.AspNetCore.Mvc;
namespace BackEnd_ExpenseTRacker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpenseTracker : ControllerBase
    {
        private readonly ExpenseDbContext _context;
        public  ExpenseTracker(ExpenseDbContext context)
        {
            _context = context;
        } 

        [HttpGet]
        public ActionResult GetExpenses()
        {
            List<Expenses> expenses = _context.Expenses.ToList();
            return Ok(expenses);
        }

        [HttpPost]
        public ActionResult PostExpenses([FromBody] Expenses newexpense)
        {
            if (newexpense != null)
            {
                _context.Expenses.Add(newexpense);
                _context.SaveChanges();
                return Ok();

            }
            else
                return NotFound();

        }
        [HttpPut("{Id}")]
        public ActionResult<IEnumerable<Expenses>> UpdateExpense(int Id,[FromBody] Expenses updateExpense)
        {
            if (Id != null)
            {
                Expenses change = _context.Expenses.FirstOrDefault(x => x.Id == updateExpense.Id);
                if (change != null)
                {
                    change.Amount = updateExpense.Amount;
                    change.Category = updateExpense.Category;
                    _context.Expenses.Update(change);
                    _context.SaveChanges();
                    return Ok();
                }
                else
                    return NotFound($"The id is not found {Id}");
            }
            return NotFound();
        }
        [HttpDelete("{Id}")]
        public  ActionResult<IEnumerable<Expenses>> DeleteExpense(int Id)
        {
            if (Id != null)
            {
                Expenses tobeDeleted = _context.Expenses.FirstOrDefault(x => x.Id == Id);
                if (tobeDeleted != null)
                {
                    _context.Expenses.Remove(tobeDeleted);
                    _context.SaveChanges();
                    return Ok();
                }
                return NotFound();

            }
            else
                return NotFound($"The id is not found {Id}");
        }
    }
}
