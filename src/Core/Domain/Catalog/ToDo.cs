using DN.WebApi.Domain.Common;
using DN.WebApi.Domain.Common.Contracts;
using DN.WebApi.Domain.Contracts;

namespace DN.WebApi.Domain.Catalog;

public class ToDo : AuditableEntity, IMustHaveTenant
{
    public string? Name { get; private set; }
    public bool IsComplete { get; private set; }
    public string? Tenant { get; set; }

    public ToDo(string? name, bool isComplete)
    {
        Name = name;
        IsComplete = isComplete;
    }

    public ToDo Update(string? name, bool isComplete)
    {
        if (name != null && !Name.NullToString().Equals(name)) Name = name;
        if (!IsComplete.NullToString().Equals(isComplete)) IsComplete = isComplete;
        return this;
    }
}