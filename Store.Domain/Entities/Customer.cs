using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class Customer : Entity
{
    public string Name { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public string? Phone { get; private set; }

    public Customer (string name, string email, string? phone = null)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new InvalidOperationException("Name cannot be empty");

        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@') || !email.Contains('.'))
            throw new InvalidOperationException("Invalid email");

        Name = name;
        Email = email;
        Phone = phone;

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
        Email = email ?? Email;
        Phone = phone ?? Phone;

        base.UpdatedAt = DateTime.UtcNow;
    }
}
