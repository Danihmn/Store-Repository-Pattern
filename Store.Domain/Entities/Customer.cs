using FluentResults;
using Store.Domain.Abstractions;
using Store.Domain.ValueObjects;

namespace Store.Domain.Entities;

public class Customer : Entity
{
    public string Name { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public Phone Phone { get; private set; }

    private Customer (string name, Email email, Phone phone)
    {
        Name = name;
        Email = email;
        Phone = phone;

        base.CreatedAt = DateTime.UtcNow;
        base.UpdatedAt = DateTime.UtcNow;
    }

    public static Result<Customer> Create (string name, string email, string phone)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Fail<Customer>("Name cannot be empty");

        if (string.IsNullOrWhiteSpace(email))
            return Result.Fail<Customer>("Email cannot be empty");

        if (string.IsNullOrWhiteSpace(phone))
            return Result.Fail<Customer>("Phone cannot be empty");

        var emailResult = Email.Create(email);
        var phoneResult = Phone.Create(phone);

        return Result.Ok(new Customer(name, emailResult.Value, phoneResult.Value));
    }

    public void UpdateCustomer (string? name = null, string? email = null, string? phone = null)
    {
        Name = name ?? Name;
        Email = email != null ? Email.Create(email).Value : Email;
        Phone = phone != null ? Phone.Create(phone).Value : Phone;

        base.UpdatedAt = DateTime.UtcNow;
    }
}
