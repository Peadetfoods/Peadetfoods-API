using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace Peadetfoods.Application.CQRS
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {
    }

    public interface ICommand : IRequest { }
}
