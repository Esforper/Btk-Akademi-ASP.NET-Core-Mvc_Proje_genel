using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ProductDto
    {   //classdan çok bir farkı yok ama arka planda derleyicide farklılıklar var

        public int ProductId { get; init; }
        

        [Required(ErrorMessage = "ProductName is required")] //boş ürün tanımlamamak için
        public String? ProductName { get; init; } = string.Empty;
        //burada set olursa örneğin ProductName değişebilir ama eğer init olursa bir daha değişemez

        [Required(ErrorMessage = "The Value is invalid")]  //ilgili nesnenin hemen üstüne yazılmalı
        public decimal Price { get; init; }

        public int CategoryId { get; init; } 

       // public Category? Category { get; set; } //bu alana ihtiyaç yok , kalan alanları Models klasörü altındaki
       //Product.cs klasöründen aldık

    }
}