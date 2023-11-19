using Mohemby_API.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Mohemby_API;
using Microsoft.AspNetCore.Authentication;
using Webapi.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Contexto>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));
        
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IHelloWorldService,HelloWorldService>();
builder.Services.AddScoped<IAfiliadoService,AfiliadoService>();
builder.Services.AddScoped<IEspecialidadService,EspecialidadService>();
builder.Services.AddScoped<IUserApiService,UserApiService>();
builder.Services.AddScoped<IHorarioService,HorarioService>();
builder.Services.AddScoped<IInactivismo_medicoService,Inactivismo_medicoService>();
builder.Services.AddScoped<IMedicoService,MedicoService>();
builder.Services.AddScoped<IPacienteService,PacienteService>();
builder.Services.AddScoped<IPol_Costos_OsService,Pol_Costos_OsService>();
builder.Services.AddScoped<Ipol_CostoService,pol_CostoService>();
builder.Services.AddScoped<IMedico_especialidadService,Medico_especialidadService>();
builder.Services.AddAuthentication("BasicAuthentication")
.AddScheme<AuthenticationSchemeOptions,BasicAuthHandler>("BasicAuthentication",null);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
