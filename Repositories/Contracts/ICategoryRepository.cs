using Entities.Models;

namespace Repositories.Contracts
{
    public interface ICategoryRepository : IRepositoryBase<Category>    //bu repository base yi devralıyor ve bunu
    // kategoriye bağlı olarak yapıyor
    {
        
    }
}