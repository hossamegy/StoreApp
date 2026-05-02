using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreApp.Core.Entities.Users;



public class Address
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; }
    
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }
    
    [Required]
    public string City { get;  set; }

    [Required]
    public string Street { get;  set; }
    public string Building { get; set; }
    public string PostalCode { get; set; }

}