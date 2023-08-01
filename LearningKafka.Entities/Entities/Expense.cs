using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningKafka.Entities.Entities
{
    public class Expense
    {
        public ObjectId Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public decimal Value { get; protected set; }

        public Expense() { }

        public Expense(string title, string description, decimal value)
        {
            Title = title;
            Description = description;
            Value = value;
        }
    }
}
