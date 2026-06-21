namespace Store.Application.UseCases.OrderProduct.GetByOrderId;

public sealed record Response (Guid OrderId, Guid ProductId, int Quantity);
