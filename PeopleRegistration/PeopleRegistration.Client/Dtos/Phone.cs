
namespace PeopleRegistration.Client.Dtos;

public class Phone
{
    public Guid Id { get; set; }
    public Guid PersonId { get; set; }
    public string PhoneNumber { get; set; }
    public string CountryCode { get; set; }
    public bool IsPrimary { get; set; }
    public bool IsVerified { get; set; }

}
