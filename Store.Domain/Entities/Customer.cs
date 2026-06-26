using Store.Domain.Abstractions;
using Store.Domain.ValueObjects;

namespace Store.Domain.Entities;

public class Customer : Entity
{
    public string Name { get; private set; } = null!;
    public Email Email { get; private set; } = null!;
    public Phone Phone { get; private set; }

    public Customer (string name, string email, string phone)
    {
        Name = name;
        Email = new Email(email);
        Phone = new Phone(phone);

        base.CreatedAt = DateTime.UtcNow;
        base.UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateCustomer (string? name = null, string? email = null, string? phone = null)
    {
        if (name != null && string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException("Name cannot be empty");

        if (email != null && (string.IsNullOrWhiteSpace(email) || !email.Contains('@') || !email.Contains('.')))
            throw new InvalidOperationException("Invalid email");

        Name = name ?? Name;
        Email = email != null ? new Email(email) : Email;
        Phone = phone != null ? new Phone(phone) : Phone;

        base.UpdatedAt = DateTime.UtcNow;
    }
}
