using AutoMapper;
using JogoJustoDotNet.AppData;
using JogoJustoDotNet.AppData.Repository;
using JogoJustoDotNet.Auth;
using JogoJustoDotNet.Models;
using JogoJustoDotNet.Service;
using JogoJustoDotNet.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.InteropServices;
using System.Text;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<Microsoft.AspNetCore.Authorization.IAuthorizationHandler, RoleAuthorizationHandler>();

#region configigurando autorizacao de papel

builder.Services.AddScoped<ITokenService, TokenService>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("weliton1912024"))
    };
});
#endregion



builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
        policy.Requirements.Add(new RoleRequeriment("Admin")));
    options.AddPolicy("UserPolicy", policy =>
        policy.Requirements.Add(new RoleRequeriment("User")));
});

#region Injeção de ISercevice e IRepository
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IMetaEsgRepository, MetaEsgRepository>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();


builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();
builder.Services.AddScoped<IEmpresaService, EmpresaService>();
builder.Services.AddScoped<IMetaEsgService, MetaEsgService>();
builder.Services.AddScoped<IDepartamentoService, DepartamentoService>();


#endregion


//#region Automapper
//var mapperConfig = new MapperConfiguration(cfg =>
//{
//    cfg.AllowNullCollections = true;
//    cfg.AllowNullDestinationValues = true;

//    cfg.CreateMap<UsuarioModel, UsuarioViewModel>();
//    cfg.CreateMap<UsuarioViewModel, UsuarioModel>();
//    cfg.CreateMap<FuncionarioModel, FuncionarioCreatedViewModel>();
//    cfg.CreateMap<FuncionarioCreatedViewModel, FuncionarioModel>();
//});
//IMapper mapper = mapperConfig.CreateMapper();
//builder.Services.AddSingleton(mapper);
//#endregion

#region conexao com o banco de dados
var conenectionString = builder.Configuration.GetConnectionString("JogoJustoConnection");

builder.Services.AddDbContext<JogoDbContext>(options =>
    options.UseSqlServer(conenectionString));
#endregion
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
