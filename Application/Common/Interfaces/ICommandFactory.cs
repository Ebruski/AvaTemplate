using Application.Common.Models;
using MediatR;

namespace Application.Common.Interfaces
{
    public interface ICommandFactory
    {
        IRequest<ResponseModel> Create(GenericRequest request);
    }
}
