using Entities.Models;
using Repositories.Contracts;

namespace Repositories
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        //base class dan dolayı bir context ifadesinin base ye gönderilmesi gerekiyor.
        public CategoryRepository(RepositoryContext context) : base(context)
        {
            //findAll ve FindByCondition baseden gelen ve kullanılabilir metodlar
        }
    }
}