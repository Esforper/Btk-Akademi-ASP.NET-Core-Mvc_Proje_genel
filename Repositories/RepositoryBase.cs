using Repositories.Contracts;

namespace Repositories  //Repositories şeklinde namespace i tanımladık
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> //generic çalışacak o nedenle T ile tipi belirtmiş olacaz
    where T : class, new()  //tipi kısıtlayan tanım
    // * abstract:temel sınıflar yenilenmesi istenmediğinden temel sınıflar abstract sınıflar olacak, soyutlar
    //baseclass ı devralan sınıflar newlenebilecek, baseclass ın kendisi newlenemeyecek
    {
        private readonly RepositoryContext _context;
        public IQueryable<T> FindAll(bool trackChanges) //veri ile ilgili bir iş yapılmak isteniyor, DI çerçevesi kullanılabilir
        {
            throw new NotImplementedException();

        }


    }
}
//public abstract class RepositoryBase<T> : IRepositoryBase<T> ,  IRepositoryBase yapısını kabul etmesi , desteklenmesi isteniyor.
//bunun için using ifadesi ekleniyor.