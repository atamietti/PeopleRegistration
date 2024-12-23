using PeopleRegistration;
using PeopleRegistration.Domain.Entities;
using PeopleRegistration.Domain.Services;
using PeopleRegistration.Shared;
using PeopleRegistration.Shared.Domain;
using PeopleRegistration.Shared.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration.GetSection("Config").Get<PeopleRegistrationConfiguration>() ?? new();
builder.Services.UsePersonInject(config);
builder.Services.UseSharedInject();
builder.Services.AddControllers()
.AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("myPolicy",
        builder => builder.WithOrigins("*")
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("myPolicy");

app.UseHttpsRedirection();

#region PHONES

app.MapGet("/api/phones", async (IRepository<Phone> request) =>
    await request.GetAll())
    .WithTags("Phones")
    .WithOpenApi();

app.MapGet("/api/phones/{id}", async (string id, IRepository<Phone> request) =>
    await request.Get(Guid.Parse(id)))
    .WithTags("Phones")
    .WithOpenApi();

app.MapPost("/api/phones", async (Phone phone, IPersonService request) =>
    await request.SavePhone(phone))
    .WithTags("Phones")
    .WithOpenApi();

app.MapPut("/api/phones/{id}", async (string id, Phone phone, IPersonService request) =>
{
    phone.Id = Guid.Parse(id);
    var response = await request.SavePhone(phone);
    return response;
})
    .WithTags("Phones")
    .WithOpenApi();

app.MapDelete("/api/phones/{id}", async (string id, IPersonService request) =>
{
    var response = await request.DeletePhone(id);
    return response;
})
    .WithTags("Phones")
    .WithOpenApi();
#endregion

#region PEOPLE

app.MapGet("/api/people", async (IRepository<Person> request) =>
    await request.GetAll())
    .WithTags("People")
    .WithOpenApi();

app.MapGet("/api/people/{id}", async (string id, IRepository<Person> request) =>
    await request.Get(Guid.Parse(id)))
    .WithTags("People")
    .WithOpenApi();

app.MapPost("/api/people", async (Person person, IPersonService request) =>
    await request.SavePerson(person))
    .WithTags("People")
    .WithOpenApi();

app.MapPut("/api/people{id}", async (string id, Person person, IPersonService request) =>
{
    person.Id = Guid.Parse(id);
    var response = await request.SavePerson(person);
    return response;
})
.WithTags("People")
.WithOpenApi();

app.MapDelete("/api/people/{id}", async (string id, IPersonService request) =>
{
    var response = await request.DeletePerson(id);
    return response;
})
.WithTags("People")
.WithOpenApi();

#endregion

#region ADDRESS

app.MapGet("/api/addresses", async (IRepository<Address> request) =>
    await request.GetAll())
    .WithTags("Adresses")
    .WithOpenApi();

app.MapGet("/api/addresses/{id}", async (string id, IRepository<Address> request) =>
    await request.Get(Guid.Parse(id)))
    .WithTags("Adresses")
    .WithOpenApi();

app.MapPost("/api/addresses", async (Address address, IPersonService request) =>
    await request.SaveAddress(address))
    .WithTags("Adresses")
    .WithOpenApi();

app.MapPut("/api/addresses/{id}", async (string id, Address address, IPersonService request) =>
{
    address.Id = Guid.Parse(id);
    var response = await request.SaveAddress(address);
    return response;
})
    .WithTags("Adresses")
    .WithOpenApi();


app.MapDelete("/api/addresses/{id}", async (string id, IPersonService request) =>
{
    var response = await request.DeleteAddress(id);
    return response;
})
    .WithTags("Adresses")
    .WithOpenApi();

#endregion


app.Run();

