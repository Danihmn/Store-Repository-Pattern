namespace Store.Application.UseCases.OrderProduct.Create;

public sealed record Response (Guid OrderId, Guid ProductId, int Quantity);
