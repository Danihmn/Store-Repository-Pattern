using Store.Domain.Abstractions;
using Store.Domain.ValueObjects;

namespace Store.Domain.Entities;

public class Order : Entity
{
    public Status Status { get; private set; }
    public Currency Total { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid AddressId { get; private set; }

    public Order (string status, decimal total, Guid customerId, Guid addressId)
    {
        if (customerId == Guid.Empty) throw new InvalidOperationException("CustomerId cannot be empty");
        if (addressId == Guid.Empty) throw new InvalidOperationException("AddressId cannot be empty");

        Status = new Status(status);
        Total = new Currency(total);
        CustomerId = customerId;
        AddressId = addressId;

        base.CreatedAt = DateTime.UtcNow;
        base.UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateOrder (string? status = null, decimal? total = null)
    {
        Status = status != null ? new Status(status) : Status;
        Total = total != null ? new Currency(total.Value) : Total;

        base.UpdatedAt = DateTime.UtcNow;
    }
}
