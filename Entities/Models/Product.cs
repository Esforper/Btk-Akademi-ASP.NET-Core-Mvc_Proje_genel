namespace Entities.Models;
// namespace kısmını Store.Entities gibi özelleştirebiliriz
public class Product
{
     public int ProductId { get; set; }
        public String? ProductName { get; set; } = string.Empty;
        public decimal Price { get; set; }

}
//StoreApp yazan yerin içinden Product dosyasını sildik. buraya yazdık.
//bu iki projeyi birbirine bağlamamız lazım, onun için komut sisteminden yapacaz
