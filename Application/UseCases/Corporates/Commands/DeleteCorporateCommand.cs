using Application.Common.Attributes;
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Corporates.Commands
{
    public class DeleteCorporateCommand : IRequest<ResponseModel>
    {
        public Guid CorporateId { get; set; }
    }

    public class DeleteCorporateCommandHandler : IRequestHandler<DeleteCorporateCommand, ResponseModel>
    {
        private readonly IUnitOfWork _uow;
        public DeleteCorporateCommandHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public async Task<ResponseModel> Handle(DeleteCorporateCommand request, CancellationToken cancellationToken)
        {
            var corporate = await _uow.CorporateService.GetByIdAsync(request.CorporateId);
            if (corporate is null) return ResponseModel.Vf("Corporate not found");

            _uow.CorporateService.Delete(request.CorporateId);
            await _uow.CommitAsync();

            return ResponseModel.Success();
        }
    }
}
