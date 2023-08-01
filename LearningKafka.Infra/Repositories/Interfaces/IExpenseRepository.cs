using LearningKafka.Entities.Entities;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LearningKafka.Infra.Repositories.Interfaces
{
    public interface IExpenseRepository
    {
        Expense Insert(Expense expense);
        Expense Update(ObjectId id, Expense expense);
        IEnumerable<Expense> List();
        IEnumerable<Expense> List(Expression<Func<Expense, bool>> filtro);
        Expense Get(ObjectId id);
        void Delete(ObjectId id);
    }
}
