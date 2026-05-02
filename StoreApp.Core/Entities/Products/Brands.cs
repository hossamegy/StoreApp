using System.ComponentModel.DataAnnotations;

namespace StoreApp.Core.Entities.Products;

public class Brands
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    public ICollection<Product> Products = new List<Product>();
    
}