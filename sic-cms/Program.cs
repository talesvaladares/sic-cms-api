using Microsoft.EntityFrameworkCore;
using sic_cms.Helpers;
using sic_cms.Services;

var builder = WebApplication.CreateBuilder(args);

//liberação do cors para conexão com frontend
builder.Services.AddCors();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
 );

// injeção de dependencias
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IRecursoService, RecursoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//liberação do cors para conexão com frontend
app.UseCors( cors => {
    cors.AllowAnyHeader();
    cors.AllowAnyMethod();
    cors.AllowAnyOrigin();
});

app.MapControllers();

app.Run();
