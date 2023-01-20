using Application.Common.Attributes;
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using MediatR;

namespace Application.UseCases.Corporates.Commands
{
    public class UpdateCorporateCommand : IRequest<ResponseModel>
    {
        public Guid CorporateId { get; set; }
        public string CorporateName { get; set; }
    }

    public class UpdateCorporateCommandHandler : IRequestHandler<UpdateCorporateCommand, ResponseModel>
    {
        private readonly IUnitOfWork _uow;
        public UpdateCorporateCommandHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }
        public async Task<ResponseModel> Handle(UpdateCorporateCommand request, CancellationToken cancellationToken)
        {
            var corporate = await _uow.CorporateService.GetByIdAsync(request.CorporateId);

            corporate.CorporateName = request.CorporateName;

            _uow.CorporateService.Update(corporate);
            await _uow.CommitAsync();

            return ResponseModel.Success();
        }
    }
}
