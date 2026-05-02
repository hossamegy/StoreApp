using System.ComponentModel.DataAnnotations.Schema;
using StoreApp.Core.Entities.Products;
using StoreApp.Core.Entities.Users;

namespace StoreApp.Core.Entities;

public class Review
{
    public int Id { get; set; }
    public string UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }

    public int ProductId { get; set; }
    [ForeignKey(nameof(ProductId))]
    public virtual Product Product { get; set; }

    public int Rating { get; set; } = 0;
    public string Comment { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}