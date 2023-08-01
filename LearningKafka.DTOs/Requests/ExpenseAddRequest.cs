using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningKafka.DTOs.Requests
{
    public class ExpenseAddRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}
