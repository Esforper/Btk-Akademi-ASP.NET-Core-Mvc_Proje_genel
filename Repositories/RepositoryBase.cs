using Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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

        public void Create(T entitiy)
        {
            _context.Set<T>().Add(entitiy);
        }

        //önce interface seviyesinde bu tanım yapılmalı
        public IQueryable<T> FindAll(bool trackChanges) //veri ile ilgili bir iş yapılmak isteniyor, DI çerçevesi kullanılabilir
        {
            return trackChanges
                ? _context.Set<T>()
                : _context.Set<T>().AsNoTracking();
                //6.4
        }

        public T? FindByCondition(Expression<Func<T, bool>> Expression, bool trackChanges)  //ilgili kuralım implemente edilmiş hali
        {   //trackChanges ifadesi true ise değişiklikler izlenecek demek
            return trackChanges
                ? _context.Set<T>().Where(Expression).SingleOrDefault()
                : _context.Set<T>().Where(Expression).AsNoTracking().SingleOrDefault();     //eğer değişiklikler izlenmeyecekse
                //.AsNoTracking() : değişiklikleri takip etme
        }

        
    }
}
//public abstract class RepositoryBase<T> : IRepositoryBase<T> ,  IRepositoryBase yapısını kabul etmesi , desteklenmesi isteniyor.
//bunun için using ifadesi ekleniyor.