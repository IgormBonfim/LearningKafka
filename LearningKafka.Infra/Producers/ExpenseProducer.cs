using Confluent.Kafka;
using LearningKafka.DTOs.Messages;
using LearningKafka.Infra.Producers.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LearningKafka.Infra.Producers
{
    public class ExpenseProducer : IExpenseProducer
    {
        public string Server { get; }
        public ExpenseProducer(IConfiguration configuration)
        {
            Server = configuration.GetSection("Kafka:Url").Value!;
        }
        public ExpenseMessage sendMessage(ExpenseMessage expenseMessage)
        {
            Message<string, string> message = new Message<string, string>
            {
                Key = Guid.NewGuid().ToString(),
                Value = JsonSerializer.Serialize(expenseMessage),
            };

            var configs = new ProducerConfig
            {
                BootstrapServers = Server
            };

            using (var producer = new ProducerBuilder<string, string>(configs).Build())
            {
                var result = producer.ProduceAsync("expenses", message);
            }

            return expenseMessage;
        }
    }
}
