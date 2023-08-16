using Repositories.Contracts;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IProductRepository Product {get ;}
        //ef core nesneleri izliyor, nesnelerde bir değişiklik olduğunda bunları kalıcı olarak kaydedilmesi için bir save
        //komutuna ihtiyaç var

        ICategoryRepository Category {get ;}  
        void Save();
    }    
}