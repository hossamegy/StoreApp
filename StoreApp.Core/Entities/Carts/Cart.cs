using System.ComponentModel.DataAnnotations.Schema;
using StoreApp.Core.Entities.Users;

namespace StoreApp.Core.Entities.Carts;

public class Cart
{
    public int Id { get; set; }

    public string UserId { get; set; } 
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }
    public ICollection<CartItem> CartItem { get; set; } = new List<CartItem>();

    public decimal TotalPrice => CartItem.Sum(x => x.TotalPrice);

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}