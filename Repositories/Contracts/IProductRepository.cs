using Entities.Models;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    //elimizde bir arayüz var (arabirim var) (IProductRepository)
    // ve bu arabirim Base kalıtımını devralıyor (IRepositoryBase<Product>)
    //bu base den gelen bütün ifadeleri IProductRepository üzerinde rahatlıkla kullanılabilir.
    {
        IQueryable<Product> GetAllProducts(bool trackChanges);





    }
}