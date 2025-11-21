using JogoJustoDotNet.AppData;
using JogoJustoDotNet.Models;
using JogoJustoDotNet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJustoDotNet.Controllers;

//[ApiController]
[Route("empresa")]
public class EmpresaController : Controller
{
    private readonly JogoDbContext _jogoDbContext;

    private readonly IConfiguration _config;

    public EmpresaController(JogoDbContext jogoDbContext, IConfiguration config)
    {
        _jogoDbContext = jogoDbContext;
        _config = config;
    }

    public IActionResult criarempresa()
    {
        var empresa = new EmpresaViewModel
        {
            InscricaoEstadual = "Tecnologia",
            Nome = "Jogo Justo",
            Endereco = "Alameda santo antonio do parana n°123",
            Telefone = "(11) 4002-8922"
        };


        return View(empresa);
    }


    [Authorize(Roles = "Admin, Gerente")]
    [HttpPost]
    public IActionResult CriarEmpresa(EmpresaModel empresaview)
    {
        var empresa = new EmpresaViewModel
        {
            Nome = empresaview.Nome,
            InscricaoEstadual = empresaview.InscricaoEstadual,
            Endereco = empresaview.Endereco,
            Telefone = empresaview.Telefone
            
        };
        _jogoDbContext.Empresa.Add(empresaview);
        _jogoDbContext.SaveChanges();
        return CreatedAtAction(nameof(CriarEmpresa), new { id = empresa }, empresa);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("atualizar/{id}")]
    [ValidateAntiForgeryToken]
    public IActionResult AtualizarEmpresa(int id, [FromBody] Models.EmpresaModel empresaAtualizada)
    {
        var empresaExistente = _jogoDbContext.Empresa.Find(id);
        if (empresaExistente == null)
        {
            return NotFound("Empresa não encontrada.");
        }
        empresaExistente.Nome = empresaAtualizada.Nome;
        empresaExistente.InscricaoEstadual = empresaAtualizada.InscricaoEstadual;
        empresaExistente.Endereco = empresaAtualizada.Endereco;
        empresaExistente.Telefone = empresaAtualizada.Telefone;
        _jogoDbContext.SaveChanges();
        return Ok(empresaExistente);
    }
    [HttpGet]
    public IActionResult ObterEmpresas()
    {
        var empresas = _jogoDbContext.Empresa.ToList();
        return Ok(empresas);
    }
    [HttpGet("{id}")]
    public IActionResult ObterEmpresaPorId(int id)
    {
        var empresa = _jogoDbContext.Empresa.Find(id);
        if (empresa == null)
        {
            return NotFound("Empresa não encontrada.");
        }
        return Ok(empresa);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deletar/{id}")]
    public IActionResult DeletarEmpresa(int id)
    {
        var empresaExistente = _jogoDbContext.Empresa.Find(id);
        if (empresaExistente == null)
        {
            return NotFound("Empresa não encontrada.");
        }
        _jogoDbContext.Empresa.Remove(empresaExistente);
        _jogoDbContext.SaveChanges();
        return Ok("Empresa deletada com sucesso.");
    }
}
