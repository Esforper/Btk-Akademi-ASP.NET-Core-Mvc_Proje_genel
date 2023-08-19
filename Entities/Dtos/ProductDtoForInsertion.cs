//product nesnesi daha sonra büyüyebilir şeklinde düşünüldüğünden bu tanım yapılıyor

namespace Entities.Dtos 
{
    public record ProductDtoForInsertion  : ProductDto  //productDto dan kalıtıyoruz
    //kalıtım ile ProductDtoForInsertion içinde ProductId alanı var , ProductName alanı var , Price ve CategoryId alanı var
    {



    }
}