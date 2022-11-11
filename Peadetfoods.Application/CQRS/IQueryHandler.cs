using MediatR;

namespace Peadetfoods.Application.CQRS
{
    public interface IQueryHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IQuery<TResponse>
    {

    }
}
