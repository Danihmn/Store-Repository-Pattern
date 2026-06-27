using FluentResults;
using MediatR;

namespace Store.Application.UseCases.Customer.Update;

public sealed record Command (Guid Id, string Name, string Email, string? Phone) : IRequest<Result<Response>>;
