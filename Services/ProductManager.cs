using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ProductManager : IProductService   //ProductService çözümlenirken ProductManager gelecek
    {   
        //ProductManager , repository managere bağımlı
        private readonly IRepositoryManager _manager;
        private readonly IMapper _mapper;
        //readonly bir ifadenin değeri yalnızca iki yerde verilebilir
        //ya tanımlandığı yer ya da structor

        public ProductManager(IRepositoryManager manager, IMapper mapper)   //DI çerçevesi
        {
           
            _manager = manager;
            _mapper = mapper;
        }

        public void CreateProduct(ProductDtoForInsertion productDto)
        {
            // Product product = new Product() //ProductDto dan gelen özellikleri Product a aktaracaz (Maplemek gibi bir şey)
            // //bu tür işlemlerin sayısı çok fazla artar diye AutoMapperlar kullanılıyor.
            // {
            //     ProductName = productDto.ProductName,
            //     Price = productDto.Price,
            //     CategoryId = productDto.CategoryId
            // };

            Product product = _mapper.Map<Product>(productDto);
           _manager.Product.Create(product);
           _manager.Save();
        }

        public void DeleteOneProduct(int id)
        {
            //Product product = GetOneProduct(id,false) ?? new Product(); //null değer olabilirdi,
            //null değer olursa yeni product ile veri tabanına git, amaç her türlü orada bir nesne olmasını sağlamak

            Product product = GetOneProduct(id,false);
            if(product is not null)
            {
            _manager.Product.DeleteOneProduct(product);
            _manager.Save();
            }
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

        public void UpdateOneProduct(Product product)
        {
            var entity = _manager.Product.GetOneProduct(product.ProductId,true);
            entity.ProductName = product.ProductName;
            entity.Price = product.Price;
            _manager.Save();
            //? entity framefork core ilgili varlığı izlediği için ilgili işlemleri yapıyor
        }
    }
}