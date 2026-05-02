using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StoreApp.Core.Entities.Carts;
using StoreApp.Core.Entities.Products;

namespace StoreApp.Core.Entities;

public class CartItem
{
    [Key]
    public int Id { get; set; }
    [Required]
    public int CartId { get;  set; }
    [ForeignKey(nameof(CartId))]
    public virtual Cart Cart { get; set; }

    [Required]
    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; }
    [Required]
    public decimal Quantity { get;  set; }

    [Required]
    public decimal UnitPrice { get;  set; }
    [Required]
    public decimal TotalPrice => UnitPrice * Quantity;
}