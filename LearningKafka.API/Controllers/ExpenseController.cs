using LearningKafka.DTOs.Messages;
using LearningKafka.DTOs.Requests;
using LearningKafka.Entities.Entities;
using LearningKafka.Infra.Producers.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningKafka.API.Controllers
{
    [Route("api/expenses")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseProducer expenseProducer;

        public ExpenseController(IExpenseProducer expenseProducer)
        {
            this.expenseProducer = expenseProducer;
        }


        [HttpPost]
        public IActionResult AddExpense([FromBody] ExpenseAddRequest expenseAddRequest)
        {
            Expense expense = new Expense(expenseAddRequest.Title, expenseAddRequest.Description, expenseAddRequest.Value);

            var message = new ExpenseMessage
            {
                Title = expense.Title,
                Description = expense.Description,
                Value = expense.Value,
            };
            var response = expenseProducer.sendMessage(message);

            return Ok(response);
        }
    }
}
