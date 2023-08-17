using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService   //ProductService çözümlenirken ProductManager gelecek
    {   
        //ProductManager , repository managere bağımlı
        private readonly IRepositoryManager _manager;

        public ProductManager(IRepositoryManager manager)   //DI çerçevesi
        {
            _manager = manager;
        }
        //manager productRepository e bağlı
        //IProductRepository , repository e bağlı
        //repository configuration a bağlı




        //bir alt katmandaki nesneyi buraya manager nesnesi olarak enjekti edildi

        public IEnumerable<Product> GetAllProducts(bool trackChanges)   //IProductService arabirimi uygulayınca bunun içindeki dosyaları getirdi
        //yani metodları implemente etti
        {
            return _manager.Product.GetAllProducts(trackChanges);
            //ef core değişiklikleri izler , o nedenle trackChanges soruluyor
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            var product = _manager.Product.GetOneProduct(id,trackChanges);
            //getOneProduct null bir değer olabilir ,olmayan bir kayıt istenebilir
            if(product is null)
            {
                throw new Exception("Product Not found!");
            }
            return product;
        }
    }
}