using Microsoft.AspNetCore.Mvc;
using Rovema.Shared.Repositories;

namespace Rovema.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RpaController : ControllerBase
{
    private readonly ILogger<RpaController> _logger;
    private readonly IRpaRepository _repository;

    public RpaController(ILogger<RpaController> logger, IRpaRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult> GetAsync()
    {
        return Ok(await _repository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetByIdAsync(Guid id)
    {
        return Ok(await _repository.GetByIdAsync(id));
    }

}
