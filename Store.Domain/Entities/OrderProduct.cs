using FluentResults;
using Store.Domain.Abstractions;

namespace Store.Domain.Entities;

public class OrderProduct
{
    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

    private OrderProduct (Guid orderId, Guid productId, int quantity)
    {
        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
    }

    public static Result<OrderProduct> Create (Guid orderId, Guid productId, int quantity)
    {
        var errors = new List<IError>();

        if (orderId == Guid.Empty)
            errors.Add(new Abstractions.Error("InvalidOrderId", "OrderId cannot be empty"));

        if (productId == Guid.Empty)
            errors.Add(new Abstractions.Error("InvalidProductId", "ProductId cannot be empty"));

        if (quantity <= 0)
            errors.Add(new Abstractions.Error("InvalidQuantity", "Quantity must be greater than 0"));

        if (errors.Count > 0)
            return Result.Fail<OrderProduct>(errors);

        return Result.Ok(new OrderProduct(orderId, productId, quantity));
    }

    public Result UpdateQuantity (int quantity)
    {
        if (quantity <= 0)
            return Result.Fail(new Abstractions.Error("InvalidQuantity", "Quantity must be greater than 0"));

        Quantity = quantity;
        return Result.Ok();
    }
}
