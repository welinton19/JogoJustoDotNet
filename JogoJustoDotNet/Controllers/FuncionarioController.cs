using AutoMapper;
using JogoJustoDotNet.AppData;
using JogoJustoDotNet.Models;
using JogoJustoDotNet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJustoDotNet.Controllers;

//[ApiController]
[Route("funcionario")]
public class FuncionarioController : Controller
{
    private readonly JogoDbContext _jogoDbContext;
    private readonly IMapper _mapper;

    private readonly IConfiguration _config;
    //private readonly HttpClient _httpClient;

    public FuncionarioController(JogoDbContext jogoDbContext, IConfiguration config, IMapper mapper)
    {
        _jogoDbContext = jogoDbContext;
        _config = config;
        _mapper = mapper;
        //_httpClient = httpClient;
    }

    [HttpGet("criar")]
    public IActionResult Criar()
    {
        return View();
    }

    [HttpPost("criar")]
    [ValidateAntiForgeryToken]
    public IActionResult Criar(FuncionarioCreatedViewModel funcionarioCreatedViewModel) 
    {
        var novfunc = new FuncionarioCreatedViewModel
        {
            Nome = funcionarioCreatedViewModel.Nome,
            DataNascimento = funcionarioCreatedViewModel.DataNascimento,
            Genero = funcionarioCreatedViewModel.Genero,
            Cargo = funcionarioCreatedViewModel.Cargo,
            DataContratacao = funcionarioCreatedViewModel.DataContratacao,
            Raca = funcionarioCreatedViewModel.Raca,
            StPcd = funcionarioCreatedViewModel.StPcd,
            TipoPcd = funcionarioCreatedViewModel.TipoPcd,
            Cpf = funcionarioCreatedViewModel.Cpf,
            CargaHoraria = funcionarioCreatedViewModel.CargaHoraria,
            DescricaoCargaHoraria = funcionarioCreatedViewModel.DescricaoCargaHoraria,
            Salario = funcionarioCreatedViewModel.Salario
        };
        return View(novfunc);
    }

    [HttpGet("detalhesfunc")]
    public IActionResult Detalhesfunc(int id) 
    {
        var funcionario = _jogoDbContext.Funcionario.Find(id);
        if (funcionario == null)
        {
            return NotFound("Funcionário não encontrado.");
        }
        return View(funcionario);
    }



    [HttpGet("funcionarioid/{id}")]
    public IActionResult Funcionarioid(int id) 
    {
        return View($"{id}");
    }

    [Authorize]
    [HttpGet("deletarfunc/{id}")]
    public IActionResult Deletafunc(int id) 
    {
        return View();
    }

}
