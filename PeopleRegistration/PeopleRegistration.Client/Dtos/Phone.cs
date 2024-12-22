
using System.ComponentModel.DataAnnotations;

namespace PeopleRegistration.Client.Dtos;

public class Phone
{
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    [Required()]
    [Phone()]
    public string PhoneNumber { get; set; }
    [Required()]
    [MaxLength(5)]
    public string CountryCode { get; set; }
    public bool IsVerified { get; set; }

}
