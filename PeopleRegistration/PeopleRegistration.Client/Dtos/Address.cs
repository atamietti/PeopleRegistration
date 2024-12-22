using System.ComponentModel.DataAnnotations;

namespace PeopleRegistration.Client.Dtos;

public class Address
{
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
  
    [Required()]
    [MaxLength(100)]
    public string Street { get; set; }
   
    [Required()]
    [MaxLength(100)] 
    public string City { get; set; }
    [Required()]
    [MaxLength(100)] public string Region { get; set; }

    [Required()]
    [MaxLength(10)]
    public string PostalCode { get; set; }
    [Required()]
    [MaxLength(10)]
    public string Country { get; set; }


}
