using DN.WebApi.Application.Common.Interfaces;
using DN.WebApi.Application.Wrapper;
using DN.WebApi.Shared.DTOs.Todo;

namespace DN.WebApi.Application.Catalog.Interfaces;

public interface IToDoService : ITransientService
{
    Task<PaginatedResult<ToDoDto>> SearchAsync(ToDoListFilter filter);

    Task<Result<Guid>> CreateToDoAsync(CreateToDoRequest request);

    Task<Result<Guid>> UpdateToDoAsync(UpdateToDoRequest request, Guid id);

    Task<Result<Guid>> DeleteToDoAsync(Guid id);
}