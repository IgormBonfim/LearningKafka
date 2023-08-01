using LearningKafka.Consumers.Consumers.Interfaces;

namespace LearningKafka.Consumers.BackgroundServices
{
    public class ExpenseBackgroundService : BackgroundService
    {
        private readonly IExpenseConsumer expenseConsumer;
        private readonly ILogger<ExpenseBackgroundService> logger;

        public ExpenseBackgroundService(IExpenseConsumer expenseConsumer ,ILogger<ExpenseBackgroundService> logger)
        {
            this.expenseConsumer = expenseConsumer;
            this.logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            logger.LogInformation("Iniciando Consumer");
            await expenseConsumer.Execute();
        }
    }
}
