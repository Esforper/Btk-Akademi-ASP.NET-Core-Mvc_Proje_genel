using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;

// Repositories.Contracts namespace içinde I ile başlayan dosyalar genellikle arayüzleri ifade eder.
namespace Repositories.Contracts
{
    // IRepositoryBase isimli bir arayüz tanımlanıyor. Bu arayüz genel (generic) bir yapı taşıyor.
    // T, tipi belirtir ve class ve new() ile sınırlanmış durumda.
    public interface IRepositoryBase<T> 
    where T : class, new()
    {

        // Veritabanı işlemleri yapabilmek için bir _context nesnesi tanımlanıyor.
        // Bu nesne, alt sınıflarda da kullanılabilmeli, bu yüzden protected erişim belirleyicisi ile tanımlanmış.

        protected readonly RepositoryContext _context;    
        // RepositoryBase sınıfının yapıcı metodu (constructor).
        // Dependency Injection (DI) yoluyla bir RepositoryContext nesnesi alır ve _context'e atar.

        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;     // Veritabanı erişimi için _context nesnesi atanıyor.
            // Bu nesne DI mekanizması tarafından çözümlenir.   (IoC)
        }

        // IQueryable<T> tipinde FindAll adında bir metod tanımlanıyor.
        // Bu metod veritabanından tüm verileri sorgulayabilir ve IQueryable olarak dönebilir.
        // trackChanges parametresi ile performans ve izleme seçeneği sunuluyor.
        // Eğer trackChanges true ise izleme yapılır, false ise AsNoTracking() ile izleme yapılmaz.
        // Bu metodun temel implementasyonu sunuluyor, alt sınıflarda genişletilebilir.
        public IQueryable<T> FindAll(bool trackChanges );   
        {
           // throw new NotImplementedException();
           return trackChanges
                    ? _context.Set<T>()     // İzleme yapılıyor.
                    : _context.Set<T>().AsNoTracking();     // İzleme yapılmıyor.
        }

        //? trackChanges: performans için izleme parametresi
        //sorgulanabilir T formatında , ismi FindAll olan bir metod tanımlandı
    }
}