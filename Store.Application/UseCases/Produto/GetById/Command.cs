using MediatR;
using Store.Domain.Abstractions;

namespace Store.Application.UseCases.Produto.GetById;

sealed record Command (Guid Id) : IRequest<Result<Response>>;