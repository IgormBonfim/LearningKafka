using LearningKafka.Entities.Entities;
using LearningKafka.Infra.Configs.Interfaces;
using LearningKafka.Infra.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LearningKafka.Infra.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        public readonly IMongoCollection<Expense> mongoCollection;
        public ExpenseRepository(IMongoConfiguration mongoConfiguration)
        {
            mongoCollection = mongoConfiguration.MongoDatabase.GetCollection<Expense>("expenses");
        }
        public void Delete(ObjectId id)
        {
            mongoCollection.DeleteOne(expense => expense.Id == id);
        }

        public Expense Get(ObjectId id)
        {
            return mongoCollection.Find(expense => expense.Id == id).FirstOrDefault();
        }

        public Expense Insert(Expense expense)
        {
            mongoCollection.InsertOne(expense);
            return expense;
        }

        public IEnumerable<Expense> List()
        {
            return mongoCollection.Find(expense => true).ToEnumerable();
        }

        public IEnumerable<Expense> List(Expression<Func<Expense, bool>> filtro)
        {
            return mongoCollection.AsQueryable().Where(filtro).AsEnumerable();
        }

        public Expense Update(ObjectId id, Expense expense)
        {
            mongoCollection.ReplaceOne(expense => expense.Id == id, expense);
            return expense;
        }
    }
}
