namespace Store.Domain.Entities;

public class OrderProduct
{
    public Guid OrderId { get; private set; }
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }

    public OrderProduct (Guid orderId, Guid productId, int quantity)
    {
        if (orderId == Guid.Empty)
            throw new InvalidOperationException("OrderId cannot be empty");

        if (productId == Guid.Empty)
            throw new InvalidOperationException("ProductId cannot be empty");

        if (quantity <= 0)
            throw new InvalidOperationException("Quantity must be greater than 0");

        OrderId = orderId;
        ProductId = productId;
        Quantity = quantity;
    }

    public void UpdateQuantity (int quantity)
    {
        if (quantity <= 0)
            throw new InvalidOperationException("Quantity must be greater than 0");

        Quantity = quantity;
    }
}
