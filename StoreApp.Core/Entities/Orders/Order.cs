using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using StoreApp.Core.Entities.Users;

namespace StoreApp.Core.Entities.Orders;


public enum Status
{
    Pending = 0,
    paid = 1,
    Deliverd = 2,
    Cancelled = 3,
    Shipped = 4
}

public class Order
{
    [Key]
    public int Id { get; set; }

    public string UserId { get;  set; }
    
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    public int ShippingAddressId { get; set; }
    [ForeignKey(nameof(ShippingAddressId))]
    public virtual Address Address { get; set; }
    public decimal TotalAmount => OrderItems.Sum(x => x.TotalPrice);
    public ICollection<OrderItems> OrderItems { get; set; } = new List<OrderItems>();

    public Status OrderStatus { get;  set; }

}