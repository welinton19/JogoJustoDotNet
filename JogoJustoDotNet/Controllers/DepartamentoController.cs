using AutoMapper;
using JogoJustoDotNet.AppData;
using JogoJustoDotNet.Models;
using JogoJustoDotNet.Service;
using JogoJustoDotNet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJustoDotNet.Controllers;

//[ApiController]
[Route("departamento")]
public class DepartamentoController : Controller
{
    private readonly IMapper _mapper;
    private readonly IDepartamentoService _departamentoService;

    private readonly IConfiguration _config;

    public DepartamentoController(IConfiguration config, IMapper mapper = null, IDepartamentoService departamentoService = null)
    {

        _config = config;
        _mapper = mapper;
        _departamentoService = departamentoService;
    }

    [HttpGet]
    public IActionResult CriarDepartamento()
    {
        var departamento = new DepartamentoViewModel
        {
            NomeDepartamento = "Recursos Humanos"

        };
        return View(departamento);


    }

    [HttpPost]
    public IActionResult CriarDepartamento(DepartamentoModel departamentoview)
    {
        var departamento = new DepartamentoViewModel
        {
            NomeDepartamento = departamentoview.NomeDepartamento
        };
        _departamentoService.AdicionarDepartamento(departamento);
        return CreatedAtAction(nameof(CriarDepartamento), new { id = departamento }, departamento);
    }

    [HttpGet]
    public IActionResult ObterTodosDepartamentos()
    {
        var departamentos = _departamentoService.ObterTodosDepartamentos();
        return View(departamentos);
    }
    
    [Authorize]
    [HttpDelete("deletar/{id}")]
    public IActionResult DeletarDepartamento(int id)
    {
        _departamentoService.DeletarDepartamento(id);
        return NoContent();
    }
}
