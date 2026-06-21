using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Customer.Update;

public sealed record Command (Guid Id, string Name, string Email, string? Phone) : IRequest<Result<Response>>;
