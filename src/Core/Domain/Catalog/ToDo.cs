using DN.WebApi.Domain.Common;
using DN.WebApi.Domain.Common.Contracts;
using DN.WebApi.Domain.Contracts;

namespace DN.WebApi.Domain.Catalog;

public class ToDo : AuditableEntity, IMustHaveTenant
{
    public string? Name { get; private set; }
    public bool IsComplete { get; private set; }
    public string? Description { get; private set; }
    public string? Tenant { get; set; }

    public ToDo(string? name, bool isComplete, string description)
    {
        Name = name;
        IsComplete = isComplete;
        Description = description;
    }

    public ToDo Update(string? name, bool isComplete, string description)
    {
        if (name != null && !Name.NullToString().Equals(name)) Name = name;
        if (Description != null && !Description.NullToString().Equals(Description)) Description = description;
        if (!IsComplete.NullToString().Equals(isComplete)) IsComplete = isComplete;
        return this;
    }
}