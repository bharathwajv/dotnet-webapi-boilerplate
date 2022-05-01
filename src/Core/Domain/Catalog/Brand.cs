namespace FSH.WebApi.Domain.Catalog;

public class Brand : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; }
    public string? Description { get; private set; }
    public int? Quantity { get; private set; }
    public Brand()
    {
    }

    public Brand(string name, string? description, int? q)
    {
        Name = name;
        Description = description;
        Quantity = q;
    }

    public Brand Update(string? name, string? description)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        return this;
    }
}