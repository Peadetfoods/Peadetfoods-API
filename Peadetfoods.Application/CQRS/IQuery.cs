using MediatR;

namespace Peadetfoods.Application.CQRS
{
    public interface IQuery<TResponse> : IRequest<TResponse>
    {
    }
}
