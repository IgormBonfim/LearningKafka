using LearningKafka.Infra.Configs.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningKafka.Infra.Configs
{
    public class MongoConfiguration : IMongoConfiguration
    {
        public IMongoClient MongoClient { get; set; }
        public IMongoDatabase MongoDatabase { get; set; }

        public MongoConfiguration ConfigureClient(string connectionString)
        {
            MongoClient = new MongoClient(connectionString);
            var dataBaseName = MongoUrl.Create(connectionString).DatabaseName;
            MongoDatabase = MongoClient.GetDatabase(dataBaseName);

            return this;
        }
    }
}
