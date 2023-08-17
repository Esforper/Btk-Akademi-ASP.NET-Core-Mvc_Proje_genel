using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService    //bu bir interface,
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        Product? GetOneProduct(int id,bool trackChanges);

        void CreateProduct(Product product);
        void UpdateOneProduct(Product product); //ProductManagerda metod üret diyince direkt buraya gönderdi
    }   
}