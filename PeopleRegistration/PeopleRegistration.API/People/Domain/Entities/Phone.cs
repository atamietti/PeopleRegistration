using PeopleRegistration.Shared.Domain;

namespace PeopleRegistration.Domain.Entities;

public class Phone : EntityBase
{
    public Guid PersonId { get; set; }
    public string PhoneNumber { get; set; } 
    public string CountryCode { get; set; }
    public bool IsPrimary { get; set; }
    public bool IsVerified { get; set; }

}
