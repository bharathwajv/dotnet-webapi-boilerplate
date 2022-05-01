using DN.WebApi.Application.Catalog.Interfaces;
using DN.WebApi.Application.Common.Exceptions;
using DN.WebApi.Application.Common.Interfaces;
using DN.WebApi.Application.Common.Specifications;
using DN.WebApi.Application.Wrapper;
using DN.WebApi.Domain.Catalog;
using DN.WebApi.Domain.Dashboard;
using DN.WebApi.Shared.DTOs.Todo;
using Microsoft.Extensions.Localization;

namespace DN.WebApi.Application.Catalog.Services;

public class ToDoService : IToDoService
{
    private readonly IStringLocalizer<ToDoService> _localizer;
    private readonly IRepositoryAsync _repository;
    private readonly IJobService _jobService;

    public ToDoService(IRepositoryAsync repository, IStringLocalizer<ToDoService> localizer, IJobService jobService)
    {
        _repository = repository;
        _localizer = localizer;
        _jobService = jobService;
    }

    public async Task<Result<Guid>> CreateToDoAsync(CreateToDoRequest request)
    {
        var ToDo = new ToDo(request.Name, request.IsComplete, request.Description);
        ToDo.DomainEvents.Add(new StatsChangedEvent());
        var ToDoId = await _repository.CreateAsync(ToDo);
        await _repository.SaveChangesAsync();
        return await Result<Guid>.SuccessAsync(ToDoId);
    }

    public async Task<Result<Guid>> DeleteToDoAsync(Guid id)
    {
        var ToDoToDelete = await _repository.RemoveByIdAsync<ToDo>(id);
        ToDoToDelete.DomainEvents.Add(new StatsChangedEvent());
        await _repository.SaveChangesAsync();
        return await Result<Guid>.SuccessAsync(id);
    }

    public Task<PaginatedResult<ToDoDto>> SearchAsync(ToDoListFilter filter)
    {
        var specification = new PaginationSpecification<ToDo>
        {
            AdvancedSearch = filter.AdvancedSearch,
            Keyword = filter.Keyword,
            OrderBy = x => x.OrderBy(b => b.Name),
            OrderByStrings = filter.OrderBy,
            PageIndex = filter.PageNumber,
            PageSize = filter.PageSize
        };

        return _repository.GetListAsync<ToDo, ToDoDto>(specification);
    }

    public async Task<Result<Guid>> UpdateToDoAsync(UpdateToDoRequest request, Guid id)
    {
        var ToDo = await _repository.GetByIdAsync<ToDo>(id);
        if (ToDo == null) throw new EntityNotFoundException(string.Format(_localizer["ToDo.notfound"], id));
        var updatedToDo = ToDo.Update(request.Name, request.IsComplete, request.Description);
        updatedToDo.DomainEvents.Add(new StatsChangedEvent());
        await _repository.UpdateAsync(updatedToDo);
        await _repository.SaveChangesAsync();
        return await Result<Guid>.SuccessAsync(id);
    }

}