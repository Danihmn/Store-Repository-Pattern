using FluentResults;
using Store.Domain.Abstractions;
using Store.Domain.ValueObjects;

namespace Store.Domain.Entities;

public class Order : Entity
{
    public Status Status { get; private set; } = null!;
    public Currency Total { get; private set; } = null!;
    public Guid CustomerId { get; private set; }
    public Guid AddressId { get; private set; }

    private Order (Status status, Currency total, Guid customerId, Guid addressId)
    {
        Status = status;
        Total = total;
        CustomerId = customerId;
        AddressId = addressId;

        base.CreatedAt = DateTime.UtcNow;
        base.UpdatedAt = DateTime.UtcNow;
    }

    public static Result<Order> Create (string status, decimal total, Guid customerId, Guid addressId)
    {
        var errors = new List<IError>();

        if (customerId == Guid.Empty)
            errors.Add(new Abstractions.Error("InvalidCustomerId", "CustomerId cannot be empty"));

        if (addressId == Guid.Empty)
            errors.Add(new Abstractions.Error("InvalidAddressId", "AddressId cannot be empty"));

        var statusResult = Status.Create(status);
        if (statusResult.IsFailed)
            errors.AddRange(statusResult.Errors);

        var totalResult = Currency.Create(total);
        if (totalResult.IsFailed)
            errors.AddRange(totalResult.Errors);

        if (errors.Count > 0)
            return Result.Fail<Order>(errors);

        return Result.Ok(new Order(statusResult.Value, totalResult.Value, customerId, addressId));
    }

    public Result UpdateOrder (string? status = null, decimal? total = null)
    {
        var errors = new List<IError>();
        Status newStatus = Status;
        Currency newTotal = Total;

        if (status != null)
        {
            var statusResult = Status.Create(status);
            if (statusResult.IsFailed)
                errors.AddRange(statusResult.Errors);
            else
                newStatus = statusResult.Value;
        }

        if (total != null)
        {
            var totalResult = Currency.Create(total.Value);
            if (totalResult.IsFailed)
                errors.AddRange(totalResult.Errors);
            else
                newTotal = totalResult.Value;
        }

        if (errors.Count > 0)
            return Result.Fail(errors);

        Status = newStatus;
        Total = newTotal;

        base.UpdatedAt = DateTime.UtcNow;
        return Result.Ok();
    }
}
