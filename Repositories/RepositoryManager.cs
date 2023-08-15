using Repositories.Contracts;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryContext _context;

        private readonly IProductRepository _productRepository;

        //RepositoryManager kullanıldığı anda ilgili elemanı cons üzerinden çözümleyecek

        public RepositoryManager(IProductRepository productRepository, RepositoryContext context)
        {
            _productRepository = productRepository;
            _context = context;
        }
        public IProductRepository Product => _productRepository;
        //sınıf örneğinden producta erişilmek istenirse tanımlamış olunan alan üzerinden yapının üretilmesini sağlar

        public void Save()
        {
            _context.SaveChanges();
        }


    }
}