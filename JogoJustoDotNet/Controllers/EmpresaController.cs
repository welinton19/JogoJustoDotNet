using AutoMapper;
using JogoJustoDotNet.AppData;
using JogoJustoDotNet.Models;
using JogoJustoDotNet.Service;
using JogoJustoDotNet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJustoDotNet.Controllers;

//[ApiController]
[Route("empresa")]
public class EmpresaController : Controller
{
    private readonly IMapper _mapper;
    private readonly IEmpresaService _empresaService;

    private readonly IConfiguration _config;

    public EmpresaController( IConfiguration config, IEmpresaService empresaService, IMapper mapper = null)
    {

        _config = config;
        _empresaService = empresaService;
        _mapper = mapper;
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
        _empresaService.AdicionarEmpresa(empresa);
        return CreatedAtAction(nameof(CriarEmpresa), new { id = empresa }, empresa);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("atualizar/{id}")]
    [ValidateAntiForgeryToken]
    public IActionResult AtualizarEmpresa(int id, [FromBody] Models.EmpresaModel empresaAtualizada)
    {
       _empresaService.AtualizarEmpresa(id, empresaAtualizada);
        return View(empresaAtualizada);

    }
    [HttpGet]
    public IActionResult ObterEmpresas()
    {
        var empresas = _empresaService.ListarEmpresas();
        return Ok(empresas);
    }

    public IEmpresaService Get_empresaService()
    {
        return _empresaService;
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("deletar/{id}")]
    public IActionResult DeletarEmpresa(int id, IEmpresaService _empresaService)
    {
        _empresaService.DeletarEmpresa(id);
        return Ok();
    }
}
