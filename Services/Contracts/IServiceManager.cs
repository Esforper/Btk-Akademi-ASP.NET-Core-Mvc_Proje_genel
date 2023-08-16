namespace Services.Contracts
{
    public interface IServiceManager
    {

        
        IProductService ProductService {get;}
        ICategoryService CategoryService {get;}

    //daha sonra servis ile ilgili order servise ihtiyacımız olursa tanımlayabiliriz
    //kullanıcı yetkilendirme işlemleri olacak servise ihtiyacımız olacak burada tanımlanabilir


    }
}