using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class CategoryManager : ICategoryService
    {

        //------    DI çerçevesi
        public readonly IRepositoryManager _manager;
        public CategoryManager(IRepositoryManager manager)
        {
            _manager = manager;
        }
        // ** IRepositoryManager , hem category yi dikkate alıyor hem product ı dikkate alıyor
        // ** category de product da repolara bağlı olarak çalışıyor, o repo da contextler var
        // contextin çözümlenmesi gerekiyor base repository gereği 
        //base repository deki contextin bir configuration ifadesine ihtiyacı var

        //----------


        //Repositorymanager ile tüm repoları kontrol edebildiğimizden böyle yaptık
        public IEnumerable<Category> GetAllCategories(bool trackChanges)
        {
            return _manager.Category.FindAll(trackChanges);
            //GetAllCategories gibi bir ifade yok çünkü tanımlamadık
            //FindAll base class da hangi nesneyi arıyorsak onun için bir ifade var
        
            //bu sayede Category listesinin elde edilmesini sağlayacaz
        }
    }
}