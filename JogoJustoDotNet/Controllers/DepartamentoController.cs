using JogoJustoDotNet.AppData;
using JogoJustoDotNet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJustoDotNet.Controllers;

//[ApiController]
[Route("departamento")]
public class DepartamentoController : Controller
{
    private readonly JogoDbContext _jogoDbContext;

    private readonly IConfiguration _config;

    public DepartamentoController(JogoDbContext jogoDbContext, IConfiguration config)
    {
        _jogoDbContext = jogoDbContext;
        _config = config;
    }

    public IActionResult Createdep()
    {
        var dep = new DepartamentoViewModel
        {
            NomeDepartamento = "Tecnologia",
            GerenteId = 3
        };
        return View(dep);
    }


    [Authorize(Roles = "Admin, Gerente")]
    [HttpPost]
    public IActionResult CriarDepartamento(DepartamentoViewModel departamentoview)
    {
        
        var novoDepartamento = new DepartamentoViewModel
        {
            NomeDepartamento = departamentoview.NomeDepartamento,

            Empresa = departamentoview.Empresa


        };

        //_jogoDbContext.Departamento.Add(novoDepartamento);
        //_jogoDbContext.SaveChanges();
        return View(novoDepartamento);
    }

    [Authorize(Roles = "Admin, Gerente")]
    [HttpPut("atualizar/{id}")]
    public IActionResult AtualizarDepartamento(int id, [FromBody] Models.DepartamentoModel departamentoAtualizado)
    {
        var departamentoExistente = _jogoDbContext.Departamento.Find(id);
        if (departamentoExistente == null)
        {
            return NotFound("Departamento não encontrado.");
        }
        departamentoExistente.NomeDepartamento = departamentoAtualizado.NomeDepartamento;
        departamentoExistente.GerenteId = departamentoAtualizado.GerenteId;
        departamentoExistente.Empresa = departamentoAtualizado.Empresa;
        _jogoDbContext.SaveChanges();
        return Ok(departamentoExistente);
    }

    [HttpGet]
    public IActionResult ObterDepartamentos()
    {
        var departamentos = _jogoDbContext.Departamento.ToList();
        return Ok(departamentos);
    }

    [HttpGet("{id}")]
    public IActionResult ObterDepartamentoPorId(int id)
    {
        var departamento = _jogoDbContext.Departamento.Find(id);
        if (departamento == null)
        {
            return NotFound("Departamento não encontrado.");
        }
        return Ok(departamento);
    }

    [Authorize(Roles = "Admin, Gerente")]
    [HttpDelete("deletar/{id}")]
    public IActionResult DeletarDepartamento(int id)
    {
        var departamentoExistente = _jogoDbContext.Departamento.Find(id);
        if (departamentoExistente == null)
        {
            return NotFound("Departamento não encontrado.");
        }
        _jogoDbContext.Departamento.Remove(departamentoExistente);
        _jogoDbContext.SaveChanges();
        return Ok("Departamento deletado com sucesso.");
    }
}
