using FluentResults;
using Store.Domain.Abstractions;
using Store.Domain.ValueObjects;

namespace Store.Domain.Entities;

public class Address : Entity
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public ZipCode ZipCode { get; private set; }

    private Address (string street, string city, string state, ZipCode zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;

        base.CreatedAt = DateTime.UtcNow;
        base.UpdatedAt = DateTime.UtcNow;
    }

    public static Result<Address> Create (string street, string city, string state, string zipCode)
    {
        var errors = new List<IError>();

        if (string.IsNullOrWhiteSpace(street))
            errors.Add(new Abstractions.Error("InvalidStreet", "Street cannot be empty"));

        if (string.IsNullOrWhiteSpace(city))
            errors.Add(new Abstractions.Error("InvalidCity", "City cannot be empty"));

        if (string.IsNullOrWhiteSpace(state))
            errors.Add(new Abstractions.Error("InvalidState", "State cannot be empty"));

        var zipCodeResult = ZipCode.Create(zipCode);

        if (zipCodeResult.IsFailed)
            errors.AddRange(zipCodeResult.Errors);

        if (errors.Count > 0)
            return Result.Fail<Address>(errors);

        return Result.Ok(new Address(street, city, state, zipCodeResult.Value));
    }

    public Result UpdateAddress (string? street = null, string? city = null, string? state = null, string? zipCode = null)
    {
        var errors = new List<IError>();
        ZipCode? newZipCode = ZipCode;

        if (zipCode != null)
        {
            var zipCodeResult = ZipCode.Create(zipCode);

            if (zipCodeResult.IsFailed)
                errors.AddRange(zipCodeResult.Errors);
            else
                newZipCode = zipCodeResult.Value;
        }

        if (errors.Count > 0)
            return Result.Fail(errors);

        Street = street ?? Street;
        City = city ?? City;
        State = state ?? State;
        ZipCode = newZipCode!;

        base.UpdatedAt = DateTime.UtcNow;
        return Result.Ok();
    }
}