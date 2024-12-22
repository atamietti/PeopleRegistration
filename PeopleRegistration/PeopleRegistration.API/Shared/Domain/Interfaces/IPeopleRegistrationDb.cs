using Microsoft.EntityFrameworkCore;

namespace PeopleRegistration.Shared.Domain.Interfaces;

public interface IPeopleRegistrationDb
{
    DbContext DbContext { get; }
}
