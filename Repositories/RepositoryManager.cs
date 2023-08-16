using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;

        private readonly IProductRepository _productRepository;

        private readonly ICategoryRepository _categoryRepository;

        //RepositoryManager kullanıldığı anda ilgili elemanı cons üzerinden çözümleyecek

        public RepositoryManager(IProductRepository productRepository, RepositoryContext context, ICategoryRepository categoryRepository)
        {
            //3 elemanı enjekte etmiş oluyoruz constructor aracılığıyla
            _productRepository = productRepository;
            _context = context;
            _categoryRepository = categoryRepository;   //IoC ye daha kaydı yapılmış değil
            // * IoC : inversion of control
            //bu kayde Program.cs üzerinden yapmamız gerekiyor
        }
        public IProductRepository Product => _productRepository;

        public ICategoryRepository Category => _categoryRepository;
        //biri category i istediği zaman categoryReposity e dönebilecek durumdayız
        //bu ifadenin somut bir nesneyle tanımlanması gerekiyor


        //sınıf örneğinden producta erişilmek istenirse tanımlamış olunan alan üzerinden yapının üretilmesini sağlar

        public void Save()
        {
            _context.SaveChanges();
        }


    }
}