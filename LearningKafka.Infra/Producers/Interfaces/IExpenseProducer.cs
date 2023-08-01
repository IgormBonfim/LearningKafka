using LearningKafka.DTOs.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningKafka.Infra.Producers.Interfaces
{
    public interface IExpenseProducer
    {
        ExpenseMessage sendMessage(ExpenseMessage expenseMessage);
    }
}
