using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
// namespace kısmını Store.Entities gibi özelleştirebiliriz
public class Product
{
        public int ProductId { get; set; }

     //   [Required(ErrorMessage = "ProductName is required")] //boş ürün tanımlamamak için
     //bu kısımları ProductDto dosyasını oluşturduktan sonra kaldırıyoruz
        public String? ProductName { get; set; } = string.Empty;


       // [Required(ErrorMessage = "The Value is invalid")]  //ilgili nesnenin hemen üstüne yazılmalı
        public decimal Price { get; set; }

        public int CategoryId { get; set; }     //Foregin key
        public Category? Category { get; set; }         //Navigation property
        //Product üzerindeki Category de fiziksel bir kayıt olmayacak, bu kayıt ilgili nesne ile ilişki
        //kurmamıza yardımcı olacak

}
//StoreApp yazan yerin içinden Product dosyasını sildik. buraya yazdık.
//bu iki projeyi birbirine bağlamamız lazım, onun için komut sisteminden yapacaz
