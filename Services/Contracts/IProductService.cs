using Entities.Dtos;
using Entities.Models;

namespace Services.Contracts
{
    public interface IProductService    //bu bir interface,
    {
        IEnumerable<Product> GetAllProducts(bool trackChanges);
        Product? GetOneProduct(int id,bool trackChanges);

        void CreateProduct(ProductDtoForInsertion productDto);
        void UpdateOneProduct(Product product); //ProductManagerda metod üret diyince direkt buraya gönderdi
        void DeleteOneProduct(int id);
    }   
}