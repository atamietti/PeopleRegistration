
namespace PeopleRegistration.Client.Dtos;

public class Person 
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Address> Addresses { get; set; }
    public List<Phone> Phones { get; set; }
}
