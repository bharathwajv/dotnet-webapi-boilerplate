using DN.WebApi.Application.Catalog.Interfaces;
using DN.WebApi.Application.Wrapper;
using DN.WebApi.Shared.DTOs.Todo;
using Microsoft.AspNetCore.Mvc;

namespace DN.WebApi.Host.Controllers.Catalog;

[ApiConventionType(typeof(FSHApiConventions))]
public class ToDoController : BaseController
{
    private readonly IToDoService _service;

    public ToDoController(IToDoService service)
    {
        _service = service;
    }

    [HttpPost("search")]
    public async Task<ActionResult<PaginatedResult<ToDoDto>>> SearchAsync(ToDoListFilter filter)
    {
        var brands = await _service.SearchAsync(filter);
        return Ok(brands);
    }

    [HttpPost]
    public async Task<ActionResult<Result<Guid>>> CreateAsync(CreateToDoRequest request)
    {
        return Ok(await _service.CreateToDoAsync(request));
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Result<Guid>>> UpdateAsync(UpdateToDoRequest request, Guid id)
    {
        return Ok(await _service.UpdateToDoAsync(request, id));
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<Result<Guid>>> DeleteAsync(Guid id)
    {
        var brandId = await _service.DeleteToDoAsync(id);
        return Ok(brandId);
    }
}