using PeopleRegistration.Domain.Entities;

namespace PeopleRegistration.Domain.Services;

public interface IPersonService
{
    Task<bool> DeletePerson(string id);
    Task<bool> DeleteAddress(string id);
    Task<bool> DeletePhone(string id);

    Task<Person> SavePerson(Person person);
    Task<Phone> SavePhone(Phone phone);
    Task<Address> SaveAddress(Address address);



}