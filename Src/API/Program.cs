using Infrastructure.Extensions.ServiceCollection;
using Infrastructure.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(typeof(Program).Assembly,typeof(AutoMapperProfile).Assembly);
CtrlCfg.AddControllersExtend(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyCors", builder =>
    {
        builder.SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
        .AllowAnyHeader().AllowAnyMethod();
    });
});

DbCtx.AddDbContexts(builder.Services, builder.Configuration);
DbCtxFactory.AddDbFactory(builder.Services);
IoC.addDepencency(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyCors");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
