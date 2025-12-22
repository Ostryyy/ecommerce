using Core.Entities;

namespace Core.Specifications;

public class TypeListSpecification : BaseSpecification<Product, string>
{
    public TypeListSpecification()
        : base(p => p.Type != null)
    {
        AddSelect(p => p.Type!);
        ApplyDistinct();
    }
}
