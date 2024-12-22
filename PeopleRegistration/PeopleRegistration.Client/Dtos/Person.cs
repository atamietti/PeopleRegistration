
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PeopleRegistration.Client.Dtos;

public class Person 
{
    public Guid Id { get; set; }
    [Required()]
    [MaxLength(100)] 
    public string Name { get; set; }
    [Required()]
    [MaxLength(100)]
    [EmailAddress()]
    public string Email { get; set; }
    public List<Address> Addresses { get; set; }
    public List<Phone> Phones { get; set; }
}
