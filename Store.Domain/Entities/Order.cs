using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class Order : Entity
{
    public string? Status { get; private set; }
    public decimal Total { get; private set; }
    public Guid CustomerId { get; private set; }
    public Guid AddressId { get; private set; }

    public Order (string? status, decimal total)
    {
        Status = status;
        Total = total;
        CustomerId = Guid.NewGuid();
        AddressId = Guid.NewGuid();

        base.CreatedAt = DateTime.UtcNow;
        base.UpdatedAt = DateTime.UtcNow;
    }

    public void UpdateOrder (string? status = null, decimal? total = null)
    {
        if (status != null &&
            (status == "pending" ||
            status == "paid" ||
            status == "shipped" ||
            status == "delivered" ||
            status == "canceled"))
            throw new InvalidOperationException(message: "Invalid status");

        if (total != null && total <= 0)
            throw new InvalidOperationException(message: "Value must be greater than 0");

        Status = status ?? Status;
        Total = total ?? Total;
    }
}
