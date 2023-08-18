using Microsoft.EntityFrameworkCore;
using Entities.Models;
using Repositories.Config;
using System.Reflection;

namespace Repositories
{
    public class RepositoryContext : DbContext  //veri tabanını temsil eder, indirdiğimiz nugeti kullandı yani o şart
    //artık bu classı veri tabanı gibi düşünecez
    //DbContext kalıtım ile RepositoryContexte devraldı
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        //*** normalde default olarak construct tanımlanır ama eğer başka construct tanımlanırsa default construct iptal olur 
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }
        
        //overide dedi sonra ctrl + space ile OnModelCreating i seçti
        protected override void OnModelCreating(ModelBuilder modelBuilder)  //protected, sadece kalıtım ile alınabilen bir özellik için kullanılıyor
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.ApplyConfiguration(new ProductConfig());    // * bu alternatif bir yol
            // modelBuilder.ApplyConfiguration(new CategoryConfig());
            //Config ifadelerinin RepoContext içinde kullanılması için tanım

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //bu saydede migration ifadelerinin oluşması hedefleniyor


            //base = DBContext
            // modelBuilder.Entity<Product>()  //üzerinden çalışılmak istenen varlık : Product ,HasData : metod
            // .HasData(   //birden fazla product tanımı yapılabilir
            //     new Product() { ProductId = 1,CategoryId=2, ProductName = "Computer", Price = 17_000 },  //bu bir çekirdek data
            //     new Product() { ProductId = 2,CategoryId=2, ProductName = "Keyboard", Price = 1_000 },
            //     new Product() { ProductId = 3,CategoryId=2, ProductName = "Mause", Price = 500 },
            //     new Product() { ProductId = 4,CategoryId=2, ProductName = "Monitor", Price = 7_000 },
            //     new Product() { ProductId = 5,CategoryId=2, ProductName = "Deck", Price = 1_500 },
            //     new Product() { ProductId = 6,CategoryId=1, ProductName = "History", Price = 25 },
            //     new Product() { ProductId = 7,CategoryId=1, ProductName = "Hamlet", Price = 75 }

            // );

            // modelBuilder.Entity<Category>()
            // .HasData(
            //     new Category() {CategoryId=1, CategoryName="Book"},
            //     new Category() {CategoryId=2, CategoryName="Electronic"}
            // );  //bunu yaptıktan sonra migration almaya hazırız
        }
    }
}
