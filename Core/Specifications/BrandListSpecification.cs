using Core.Entities;

namespace Core.Specifications;

public class BrandListSpecification : BaseSpecification<Product, string>
{
    public BrandListSpecification()
        : base(p => p.Brand != null)
    {
        AddSelect(p => p.Brand!);
        ApplyDistinct();
    }
}

