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
        if (string.IsNullOrWhiteSpace(street))
            throw new InvalidOperationException("Street cannot be empty");

        if (string.IsNullOrWhiteSpace(city))
            throw new InvalidOperationException("City cannot be empty");

        if (string.IsNullOrWhiteSpace(state))
            throw new InvalidOperationException("State cannot be empty");

        if (string.IsNullOrWhiteSpace(zipCode))
            throw new InvalidOperationException("ZipCode cannot be empty");

        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;

        base.CreatedAt = DateTime.UtcNow;
        base.UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateAddress (string? street = null, string? city = null, string? state = null, string? zipCode = null)
    {
        if (street != null && string.IsNullOrWhiteSpace(street))
            throw new InvalidOperationException("Street cannot be empty");

        if (city != null && string.IsNullOrWhiteSpace(city))
            throw new InvalidOperationException("City cannot be empty");

        if (state != null && string.IsNullOrWhiteSpace(state))
            throw new InvalidOperationException("State cannot be empty");

        if (zipCode != null && string.IsNullOrWhiteSpace(zipCode))
            throw new InvalidOperationException("ZipCode cannot be empty");

        Street = street ?? Street;
        City = city ?? City;
        State = state ?? State;
        ZipCode = zipCode ?? ZipCode;

        base.UpdatedAt = DateTime.UtcNow;
    }
}
