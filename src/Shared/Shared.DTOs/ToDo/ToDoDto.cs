namespace DN.WebApi.Shared.DTOs.Todo;

public class ToDoDto : IDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; } = "Yet to fill";
    public bool IsComplete { get; set; }
}