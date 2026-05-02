using System.ComponentModel.DataAnnotations;
using StoreApp.Core.Entities.Carts;
using StoreApp.Core.Entities.Orders;
using Microsoft.AspNetCore.Identity;

namespace StoreApp.Core.Entities.Users;

public class User : IdentityUser
{

    [Required]
    [MaxLength(25)]
    public string FirstName { get;  set; }
    [Required]
    [MaxLength(25)]
    public string LastName { get;  set; }
        
    public string? ProfileImg { get;  set; }

    public bool IsActive { get; set; } = false;
    
    [Required]
    public ICollection<Address> Addresses { get; set; } = new List<Address>();
  
    public ICollection<Order> Orders { get; set; } = new List<Order>();
    public virtual Cart Cart { get; set; }


}