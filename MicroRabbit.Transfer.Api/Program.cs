
using MicroRabbit.Transfer.Domain.Events.Transfer;
using MicroRabbit.Infra.IoC;
using MicroRabbit.Transfer.Data.Context;
using MicroRabit.Domain.Core.Bus;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<TransferDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("TransferDbConnection"));
    });

    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Transfer API", Version = "v1" });
    });


    builder.Services.AddControllers();
    builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    DependencyContainer.RegisterServices(builder.Services);
}


var app = builder.Build();
{
    app.UseCors(x => x
   .AllowAnyOrigin()
   .AllowAnyHeader()
   .AllowAnyMethod());

    app.UseHttpsRedirection();
    app.MapControllers();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Transfer Microsservice V1");
    });

    var eventBus = app.Services.GetRequiredService<IEventBus>();
    eventBus.Subscribe<TransferCreatedEvent, TransferEventHandler>();

    app.Run();
}
