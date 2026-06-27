using FluentResults;
using MediatR;

namespace Store.Application.UseCases.Customer.Create;

public sealed record Command (string Name, string Email, string Phone) : IRequest<Result<Response>>;
