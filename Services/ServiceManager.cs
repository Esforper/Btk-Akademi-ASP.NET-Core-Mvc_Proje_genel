using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {

        // --- DI yapısı
        private readonly IProductService _productService;   //ProductService nin newlenmiş hali
        private readonly ICategoryService _categoryService;

        public ServiceManager(IProductService productService, ICategoryService categoryService)
        {   //IProductService in bağımlılığı var
            _productService = productService;
            _categoryService = categoryService;
        }
        //category service , product service constructora enjekte edilecek


        // ----------
        public IProductService ProductService => _productService;   //Product isteğine ProductService ile dönüş olacak

        public ICategoryService CategoryService => _categoryService; //category isteğine CategoryService ile dönüş olacak
}
}