using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    //bu generic bir ifade ve Product ifadesini burada tanımlayabiliriz
    public class ProductRepository : RepositoryBase<Product> , IProductRepository  
    {
        //ProductRepository , RepositoryContext e bağlı
        public ProductRepository(RepositoryContext context) : base(context)
        {

        }

        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);
       
    }
}