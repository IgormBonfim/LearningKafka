using Confluent.Kafka;
using LearningKafka.Consumers.Consumers.Interfaces;
using LearningKafka.DTOs.Messages;
using LearningKafka.Entities.Entities;
using LearningKafka.Infra.Repositories.Interfaces;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace LearningKafka.Consumers.Consumers
{
    public class ExpenseConsumer : IExpenseConsumer
    {
        private readonly IExpenseRepository expenseRepository;

        public ExpenseConsumer(IExpenseRepository expenseRepository)
        {
            this.expenseRepository = expenseRepository;
        }
        public async Task Execute()
       {
            var configs = new ConsumerConfig
            {
                GroupId = "expense-insert-consumer",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var consumer = new ConsumerBuilder<string, string>(configs).Build())
            {
                const string topic = "expenses";
                consumer.Subscribe(topic);

                try
                {
                    while (true)
                    {
                        var evento = consumer.Consume();
                        string message = evento.Message.Value;

                        ExpenseMessage? expenseMessage = JsonSerializer.Deserialize<ExpenseMessage>(message);

                        var expense = new Expense(expenseMessage.Title, expenseMessage.Description, expenseMessage.Value);

                        expenseRepository.Insert(expense);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    consumer.Close();
                    await Task.CompletedTask;
                }
            }
        }
    }
}
