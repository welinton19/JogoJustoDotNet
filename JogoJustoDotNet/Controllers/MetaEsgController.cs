using JogoJustoDotNet.AppData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JogoJustoDotNet.Controllers;

[ApiController]
[Route("meta-esg")]
public class MetaEsgController : Controller
{
    private readonly JogoDbContext _jogoDbContext;

    private readonly IConfiguration _config;

    public MetaEsgController(JogoDbContext jogoDbContext, IConfiguration config)
    {
        _jogoDbContext = jogoDbContext;
        _config = config;
    }


    [Authorize(Roles = "Admin,Empresa")]
    [HttpPost]
    public IActionResult CriarMetaEsg([FromBody] Models.MetaEsgModel metaEsg)
    {
        var novaMetaEsg = new Models.MetaEsgModel
        {
            DescricaoMetaEsg = metaEsg.DescricaoMetaEsg,
            TipoMetaEsg = metaEsg.TipoMetaEsg,
            Empresa = metaEsg.Empresa
        };
        _jogoDbContext.MetaEsg.Add(novaMetaEsg);
        _jogoDbContext.SaveChanges();
        return CreatedAtAction(nameof(CriarMetaEsg), new { id = novaMetaEsg }, novaMetaEsg);
    }

    [Authorize(Roles = "Admin,Empresa")]
    [HttpPut("atualizar/{id}")]
    public IActionResult AtualizarMetaEsg(int id, [FromBody] Models.MetaEsgModel metaEsgAtualizada)
    {
        var metaEsgExistente = _jogoDbContext.MetaEsg.Find(id);
        if (metaEsgExistente == null)
        {
            return NotFound("Meta ESG não encontrada.");
        }
        metaEsgExistente.DescricaoMetaEsg = metaEsgAtualizada.DescricaoMetaEsg;
        metaEsgExistente.TipoMetaEsg = metaEsgAtualizada.TipoMetaEsg;
        metaEsgExistente.Empresa = metaEsgAtualizada.Empresa;
        _jogoDbContext.SaveChanges();
        return Ok(metaEsgExistente);
    }
    [HttpGet]
    public IActionResult ObterMetasEsg()
    {
        var metasEsg = _jogoDbContext.MetaEsg.ToList();
        return Ok(metasEsg);
    }
    [HttpGet("{id}")]
    public IActionResult ObterMetaEsgPorId(int id)
    {
        var metaEsg = _jogoDbContext.MetaEsg.Find(id);
        if (metaEsg == null)
        {
            return NotFound("Meta ESG não encontrada.");
        }
        return Ok(metaEsg);
    }

    [Authorize(Roles = "Admin,Empresa")]
    [HttpDelete("deletar/{id}")]
    public IActionResult DeletarMetaEsg(int id)
    {
        var metaEsgExistente = _jogoDbContext.MetaEsg.Find(id);
        if (metaEsgExistente == null)
        {
            return NotFound("Meta ESG não encontrada.");
        }
        _jogoDbContext.MetaEsg.Remove(metaEsgExistente);
        _jogoDbContext.SaveChanges();
        return Ok("Meta ESG deletada com sucesso.");
    }
}
