using System.Linq.Expressions;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;


namespace Repositories.Contracts
{
    // Genel bir sözleşme olan IRepositoryBase<T> arayüzü tanımlanmıştır.
    public interface IRepositoryBase<T> 
    {
         // IQueryable<T> tipindeki öğeleri bulan bir metot tanımlanmıştır.
        // Parametre "trackChanges", öğelerin değişikliklerinin takip edilip edilmeyeceğini belirler.
        // Eğer trackChanges true olarak ayarlanırsa, değişiklikler takip edilir, aksi halde edilmez.
        IQueryable<T> FindAll(bool trackChanges);
        T? FindByCondition(Expression<Func<T,bool>> Expression , bool trackChanges);    //ilgili kural

        void Create(T entitiy);
    }
}