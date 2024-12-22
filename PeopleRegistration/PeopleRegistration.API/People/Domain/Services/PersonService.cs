using PeopleRegistration.Domain.Entities;
using PeopleRegistration.Shared.Domain.Interfaces;

namespace PeopleRegistration.Domain.Services;

public class PersonService : IPersonService
{
    private readonly IRepository<Person> _repository;
    private readonly IRepository<Address> _addrresRepository;
    private readonly IRepository<Phone> _phoneRepository;

    public PersonService(IRepository<Person> repository,
        IRepository<Address> addrresRepository,
        IRepository<Phone> phoneRepository)
    {
        _repository = repository;
        _addrresRepository = addrresRepository;
        _phoneRepository = phoneRepository;
    }

    public async Task<Person> SavePerson(Person person)
    {
        if (person.Id == Guid.Empty)
            await _repository.Insert(person);
        else
            await _repository.Update(person);

        return person;
    }

    public async Task<bool> DeletePerson(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return false;

        var response = await _repository.Delete(Guid.Parse(id));

        return response == 0;
    }

    public async Task<bool> DeleteAddress(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return false;

        var response = await _addrresRepository.Delete(Guid.Parse(id));

        return response == 0;
    }

    public async Task<bool> DeletePhone(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return false;

        var response = await _phoneRepository.Delete(Guid.Parse(id));

        return response == 0;
    }

    public async Task<Phone> SavePhone(Phone phone)
    {
        if (phone.Id == Guid.Empty)
            await _phoneRepository.Insert(phone);
        else
            await _phoneRepository.Update(phone);

        return phone;
    }

    public async Task<Address> SaveAddress(Address address)
    {
        if (address.Id == Guid.Empty)
            await _addrresRepository.Insert(address);
        else
            await _addrresRepository.Update(address);

        return address;
    }
}

