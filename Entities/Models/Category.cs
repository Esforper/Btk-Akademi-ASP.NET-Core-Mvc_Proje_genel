namespace Entities.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public String? CategoryName { get; set; } = string.Empty;
    }
    //bu tanımdan sonra kategorinin repo tanımı gerekli
}