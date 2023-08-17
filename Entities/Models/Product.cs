using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
// namespace kısmını Store.Entities gibi özelleştirebiliriz
public class Product
{
        public int ProductId { get; set; }

        [Required(ErrorMessage = "ProductName is required")] //boş ürün tanımlamamak için
        public String? ProductName { get; set; } = string.Empty;


        [Required(ErrorMessage = "The Value is invalid")]  //ilgili nesnenin hemen üstüne yazılmalı
        public decimal Price { get; set; }

}
//StoreApp yazan yerin içinden Product dosyasını sildik. buraya yazdık.
//bu iki projeyi birbirine bağlamamız lazım, onun için komut sisteminden yapacaz
