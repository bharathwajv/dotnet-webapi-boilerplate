namespace DN.WebApi.Shared.DTOs.Todo;
public class UpdateToDoRequest : IMustBeValid
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsComplete { get; set; }
}