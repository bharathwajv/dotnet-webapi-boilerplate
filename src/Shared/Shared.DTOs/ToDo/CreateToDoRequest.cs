namespace DN.WebApi.Shared.DTOs.Todo;
public class CreateToDoRequest : IMustBeValid
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public bool IsComplete { get; set; }
}