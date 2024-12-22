using PeopleRegistration.Shared.Domain;

namespace PeopleRegistration.Domain.Entities;

public class Address : EntityBase
{
    public Guid PersonId { get; set; }
    public string Street{ get; set; }
    public string City { get; set; }
    public string Region { get; set; }
    public string PostalCode { get; set; }
    public string Country { get; set; }
    public bool IsPrimary { get; set; }

}
