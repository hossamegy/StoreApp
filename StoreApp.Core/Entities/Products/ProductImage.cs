using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StoreApp.Core.Entities.Products;

public class ProductImage
{
    [Key]
    public int Id { get; set; }

    public int ProductId { get; set; }
    [JsonIgnore]

    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; }
    
    [Required]
    public string ImageUrl { get; set; }

    public bool IsPrimary { get; set; }

}