using PeopleRegistration.Shared.Domain;

namespace PeopleRegistration.Domain.Entities;

public class Person : EntityBase
{
    public string Name { get; set; }
    public string Email { get; set; }
    public List<Address> Addresses { get; set; }
    public List<Phone> Phones { get; set; }
}
