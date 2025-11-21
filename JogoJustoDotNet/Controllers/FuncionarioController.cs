using JogoJustoDotNet.AppData;
using JogoJustoDotNet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJustoDotNet.Controllers;

[ApiController]
[Route("funcionario")]
public class FuncionarioController : Controller
{
    private readonly JogoDbContext _jogoDbContext;

    private readonly IConfiguration _config;
    //private readonly HttpClient _httpClient;

    public FuncionarioController(JogoDbContext jogoDbContext, IConfiguration config)
    {
        _jogoDbContext = jogoDbContext;
        _config = config;
        //_httpClient = httpClient;
    }

    public IActionResult Criar()
    {
        var funcionario = new FuncionarioCreatedViewModel
        {
            Nome = "João Silva",
            DataNascimento = new DateTime(1990, 5, 15),
            Genero = "Masculino",
            Cargo = "Desenvolvedor",
            DataContratacao = new DateTime(2020, 1, 10),
            Raca = "Branco",
            StPcd = false,
            TipoPcd = "",
            Cpf = "123.456.789-00",
            CargaHoraria = "12 horas",
            DescricaoCargaHoraria = "Tempo integral",
            Salario = 5000.00m
             
        };

        return View(funcionario);
    }



    [Authorize]
    [HttpPost("criar")]
    public IActionResult  CriarFuncionario( FuncionarioCreatedViewModel funcionarioviewmodel)
    {
        var funcionarioview = new FuncionarioCreatedViewModel
        {
            Nome = funcionarioviewmodel.Nome,
            DataNascimento = funcionarioviewmodel.DataNascimento,
            Genero = funcionarioviewmodel.Genero,
            Cargo = funcionarioviewmodel.Cargo,
            DataContratacao = funcionarioviewmodel.DataContratacao,
            Raca = funcionarioviewmodel.Raca,
            StPcd = funcionarioviewmodel.StPcd,
            TipoPcd = funcionarioviewmodel.TipoPcd,
            Cpf = funcionarioviewmodel.Cpf,
            CargaHoraria = funcionarioviewmodel.CargaHoraria,
            DescricaoCargaHoraria = funcionarioviewmodel.DescricaoCargaHoraria,
            Salario = funcionarioviewmodel.Salario,
            Departamento = funcionarioviewmodel.Departamento
        };
        return View(funcionarioview);
    }

    [Authorize]
    [HttpPut("atualizar/{id}")]
    public IActionResult AtualizarFuncionario(int id, [FromBody] Models.FuncionarioModel funcionarioAtualizado)
    {
        var funcionarioExistente = _jogoDbContext.Funcionario.Find(id);
        if (funcionarioExistente == null)
        {
            return NotFound("Funcionário não encontrado.");
        }
        funcionarioExistente.Nome = funcionarioAtualizado.Nome;
        funcionarioExistente.DataNascimento = funcionarioAtualizado.DataNascimento;
        funcionarioExistente.Genero = funcionarioAtualizado.Genero;
        funcionarioExistente.Cargo = funcionarioAtualizado.Cargo;
        funcionarioExistente.DataContratacao = funcionarioAtualizado.DataContratacao;
        funcionarioExistente.Raca = funcionarioAtualizado.Raca;
        funcionarioExistente.StPcd = funcionarioAtualizado.StPcd;
        funcionarioExistente.TipoPcd = funcionarioAtualizado.TipoPcd;
        funcionarioExistente.Cpf = funcionarioAtualizado.Cpf;
        funcionarioExistente.CargaHoraria = funcionarioAtualizado.CargaHoraria;
        funcionarioExistente.DescricaoCargaHoraria = funcionarioAtualizado.DescricaoCargaHoraria;
        funcionarioExistente.Salario = funcionarioAtualizado.Salario;
        funcionarioExistente.Departamento = funcionarioAtualizado.Departamento;
        _jogoDbContext.SaveChanges();
        return Ok("Funcionário atualizado com sucesso.");
    }

    [HttpGet("obter/{id}")]
    public IActionResult ObterFuncionario(int id)
    {
        var funcionario = _jogoDbContext.Funcionario.Find(id);
        if (funcionario == null)
        {
            return NotFound("Funcionário não encontrado.");
        }
        return Ok(funcionario);
    }

    [HttpGet("listar")]
    public IActionResult ListarFuncionarios()
    {
        var funcionarios = _jogoDbContext.Funcionario.ToList();
        return Ok(funcionarios);
    }

    [Authorize]
    [HttpDelete("deletar/{id}")]
    public IActionResult DeletarFuncionario(int id)
    {
        var funcionario = _jogoDbContext.Funcionario.Find(id);
        if (funcionario == null)
        {
            return NotFound("Funcionário não encontrado.");
        }
        _jogoDbContext.Funcionario.Remove(funcionario);
        _jogoDbContext.SaveChanges();
        return Ok("Funcionário deletado com sucesso.");
    }
}
