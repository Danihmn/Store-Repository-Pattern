using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Address.Update;

public sealed record Command (Guid Id, string Street, string City, string State, string ZipCode) : IRequest<Result<Response>>;
