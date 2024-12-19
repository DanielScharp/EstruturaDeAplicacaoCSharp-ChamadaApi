using ChamadaApi.Database.MySql;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
// Add services to the container.
builder.Services.Add(new ServiceDescriptor(typeof(LeiloesRepository), new LeiloesRepository(Environment.GetEnvironmentVariable("Dashboard_ConnMySqlLeilao"))));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
