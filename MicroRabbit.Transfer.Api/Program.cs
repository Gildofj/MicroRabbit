var builder = WebApplication.CreateBuilder(args);
{
    //builder.Services.AddDbContext<BankingDbContext>(options =>
    //{
    //    options.UseSqlServer(builder.Configuration.GetConnectionString("BankingDbConnection"));
    //});

    //builder.Services.AddSwaggerGen(c =>
    //{
    //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Banking API", Version = "v1" });
    //});


    builder.Services.AddControllers();
    //builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    //DependencyContainer.RegisterServices(builder.Services);
}


var app = builder.Build();
{
    app.UseCors(x => x
   .AllowAnyOrigin()
   .AllowAnyHeader()
   .AllowAnyMethod());

    app.UseHttpsRedirection();
    app.MapControllers();
    //app.UseSwagger();
    //app.UseSwaggerUI(c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Banking Microsservice V1");
    //});

    app.Run();
}
