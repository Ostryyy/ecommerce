using Core.Entities;

namespace Core.Specifications;

public class ProductSpecification : BaseSpecification<Product>
{
    public ProductSpecification(ProductSpecParams prodSpecParams) : base(x =>
        (string.IsNullOrEmpty(prodSpecParams.Search) || x.Name.ToLower().Contains(prodSpecParams.Search)) &&
        (prodSpecParams.Brands.Count == 0 || prodSpecParams.Brands.Contains(x.Brand)) &&
        (prodSpecParams.Types.Count == 0 || prodSpecParams.Types.Contains(x.Type)))
    {
        ApplyPaging(prodSpecParams.PageSize * (prodSpecParams.PageIndex - 1), prodSpecParams.PageSize);
        switch (prodSpecParams.Sort)
        {
            case "priceAsc":
                AddOrderBy(p => p.Price);
                break;
            case "priceDesc":
                AddOrderByDescending(p => p.Price);
                break;
            default:
                AddOrderBy(p => p.Name);
                break;
        }
    }
}
