using JogoJustoDotNet.AppData;
using Microsoft.AspNetCore.Mvc;

namespace JogoJustoDotNet.Controllers;

[ApiController]
[Route("esg")]
public class EsgController : ControllerBase
{
    private readonly JogoDbContext _jogoDbContext;

    private readonly IConfiguration _config;

    public EsgController(JogoDbContext jogoDbContext, IConfiguration config)
    {
        _jogoDbContext = jogoDbContext;
        _config = config;
    }
    [HttpGet]
    public IActionResult ObterEsgLogs()
    {
        var esgLogs = _jogoDbContext.EsgLogModel.ToList();
        return Ok(esgLogs);
    }
}
