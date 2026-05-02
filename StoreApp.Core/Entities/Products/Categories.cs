using System.ComponentModel.DataAnnotations;

namespace StoreApp.Core.Entities.Products;

public class Categories
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    public ICollection<Product> Products = new List<Product>();

}