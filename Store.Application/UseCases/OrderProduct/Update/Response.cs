namespace Store.Application.UseCases.OrderProduct.Update;

public sealed record Response (Guid OrderId, Guid ProductId, int Quantity);
