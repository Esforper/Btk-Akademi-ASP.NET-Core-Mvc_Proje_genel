using Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Repositories  //Repositories şeklinde namespace i tanımladık
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> //generic çalışacak o nedenle T ile tipi belirtmiş olacaz
    where T : class, new()  //tipi kısıtlayan tanım
    // * abstract:temel sınıflar yenilenmesi istenmediğinden temel sınıflar abstract sınıflar olacak, soyutlar
    //baseclass ı devralan sınıflar newlenebilecek, baseclass ın kendisi newlenemeyecek
    // * RepositoryBase : bir base class, deviralınan classlar tarafından newlenecek
    {
        protected readonly RepositoryContext _context;

        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }
        public IQueryable<T> FindAll(bool trackChanges) //veri ile ilgili bir iş yapılmak isteniyor, DI çerçevesi kullanılabilir
        {
            return trackChanges
                ? _context.Set<T>()
                : _context.Set<T>().AsNoTracking();
                //6.4
        }


    }
}
//public abstract class RepositoryBase<T> : IRepositoryBase<T> ,  IRepositoryBase yapısını kabul etmesi , desteklenmesi isteniyor.
//bunun için using ifadesi ekleniyor.