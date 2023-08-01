using LearningKafka.Infra.Configs;
using LearningKafka.Infra.Configs.Interfaces;
using LearningKafka.Infra.Producers;
using LearningKafka.Infra.Producers.Interfaces;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("MongoDB");
var dataBaseName = MongoUrl.Create(connectionString).DatabaseName;

builder.Services.AddSingleton<IMongoConfiguration>(x => MongoConfigurationFluent.Configure().ConfigureClient(connectionString!));

builder.Services.AddScoped<IExpenseProducer, ExpenseProducer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
