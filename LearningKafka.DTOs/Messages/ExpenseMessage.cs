using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningKafka.DTOs.Messages
{
    public class ExpenseMessage
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}
