//using AutoMapper;
using JogoJustoDotNet.AppData;
using JogoJustoDotNet.Models;
using JogoJustoDotNet.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JogoJustoDotNet.Controllers;

[Route("usuario")]
public class UsuarioController : Controller
{
    private readonly JogoDbContext _jogoDbContext;
    private readonly IConfiguration _config;
    //private readonly HttpClient _httpClient;
    //private readonly IMapper _mapper;

    public UsuarioController(JogoDbContext jogoDbContext, IConfiguration config )
    {
        this._jogoDbContext = jogoDbContext;
        _config = config;
        //httpClient = httpClient;
        //_mapper = mapper;
    }

    [HttpGet("logar")]
    public IActionResult Logar()
    {
        
        
        var usuario = new UsuarioViewModel
        {
            Email = "",
            Password = "",
            Tipo = ""
        };

        return View("Logar", usuario);
    }

    [HttpPost("criar")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult CriarUsuario( UsuarioModel usuario)
    {
        if (ModelState.IsValid)
        {
            if (usuario == null || string.IsNullOrEmpty(usuario.Email) || string.IsNullOrEmpty(usuario.Password) || string.IsNullOrEmpty(usuario.Tipo))
            {
                return BadRequest("Dados do usuário inválidos.");
            }
            _jogoDbContext.Usuario.Add(usuario);
            _jogoDbContext.SaveChanges();
            return CreatedAtAction(nameof(CriarUsuario), new { id = usuario.Id }, usuario);
        }
        else 
        {
            return View(usuario);
        }
        
       
    }

    [HttpPost("login")]
    [ValidateAntiForgeryToken]
    public IActionResult Login(UsuarioViewModel usuario)
    {
        if (usuario == null || string.IsNullOrWhiteSpace(usuario.Email) || string.IsNullOrWhiteSpace(usuario.Password))
        {
            ModelState.AddModelError(string.Empty, "Email e senha são obrigatórios.");
            return View("Logar", new UsuarioViewModel { Email = usuario?.Email ?? "", Password = "" });
        }

        var user = _jogoDbContext.Usuario.FirstOrDefault(u => u.Email == usuario.Email && u.Password == usuario.Password);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Credenciais inválidas.");
            return View("Logar", new UsuarioViewModel { Email = usuario.Email });
        }

        // Autenticação / redirecionamento
        return RedirectToAction("Index", "Home");
    }
}
