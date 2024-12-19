using ChamadaApi.Web.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMyApiService, MyApiService>();

builder.Services.AddHttpClient("MyApiClient", client => {
    client.BaseAddress = new Uri("https://localhost:7259"); // Base URL da API
    client.DefaultRequestHeaders.Add("Accept", "application/json"); // Configurar cabeçalhos padrão
    // Adicione outros headers se necessário, como autenticação
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
