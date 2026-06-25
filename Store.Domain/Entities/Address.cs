using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class Address : Entity
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }

    public Address (string street, string city, string state, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;

        base.CreatedAt = DateTime.UtcNow;
        base.UpdatedAt = DateTime.UtcNow;
        base.Id = Guid.NewGuid();
    }

    public void UpdateAddress (string? street = null, string? city = null, string? state = null, string? zipCode = null)
    {
        Street = street ?? Street;
        City = city ?? City;
        State = state ?? State;
        ZipCode = zipCode ?? ZipCode;

        base.UpdatedAt = DateTime.UtcNow;
    }
}
