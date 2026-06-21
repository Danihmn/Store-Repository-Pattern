using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Address.Create;

public sealed record Command (string Street, string City, string State, string ZipCode) : IRequest<Result<Response>>;
