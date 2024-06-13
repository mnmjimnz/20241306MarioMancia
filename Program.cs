using _20241306PruebaTecnicaAFP.Core.Interface;
using _20241306PruebaTecnicaAFP.Infraestructura.Repositorio;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IDapper, DapperRepository>();
builder.Services.AddTransient<IEmpresa, EmpresaRepositiry>();
builder.Services.AddTransient<IDepartamentos, DepartamentosRepository>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Empresa}/{action=Index}/{id?}");

app.MapControllers();

app.Run();
