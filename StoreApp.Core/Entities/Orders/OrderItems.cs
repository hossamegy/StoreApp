using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StoreApp.Core.Entities.Products;

namespace StoreApp.Core.Entities.Orders;


public class OrderItems
{
    [Key]
    public int Id { get; set; }

    public int OrderId { get;  set; }
    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; }
    [ForeignKey(nameof(OrderId))]
    public virtual Order Order { get; set; }
    public decimal Quantity { get;  set; }
    public decimal UnitPrice { get;  set; }
    public decimal TotalPrice => UnitPrice * Quantity;

}