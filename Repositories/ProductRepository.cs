using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    //bu generic bir ifade ve Product ifadesini burada tanımlayabiliriz
    public class ProductRepository : RepositoryBase<Product> , IProductRepository  //base ile ilişkili , basenin bir bağımlılığı var
    //context ile de ilişkili
    {
        //ProductRepository , RepositoryContext e bağlı
        public ProductRepository(RepositoryContext context) : base(context)
        {

        }

        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);
       

       //interface
        public Product? GetOneProduct(int id , bool trackChanges)
        {
            return FindByCondition(P => P.ProductId.Equals(id),trackChanges);
        }
    }
}