using Application.Common.Attributes;
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.Corporates.Commands
{
    public class AddCorporateCommand : IRequest<ResponseModel>
    {
        public string CorporateName { get; set; }
        public int Number { get; set; }
        public int? NumberNull { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DateNull { get; set; }
    }

    public class AddCorporateCommandHandler : IRequestHandler<AddCorporateCommand, ResponseModel>
    {
        private readonly IUnitOfWork _uow;
        public AddCorporateCommandHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
        }

        public async Task<ResponseModel> Handle(AddCorporateCommand request, CancellationToken cancellationToken)
        {
            var corporateExists = await _uow.CorporateService.CorporateNameExist(request.CorporateName);
            if (corporateExists) return ResponseModel.Vf($"{request.CorporateName} already exists.");

            var corporate = new Corporate
            {
                CorporateName = request.CorporateName
            };

            //if (corporate.CorporateName == "1") return ResponseModel.Failure();
            //if (corporate.CorporateName == "2") return ResponseModel.Failure("304");
            //if (corporate.CorporateName == "3") return ResponseModel.Vf("valiation failed already exists");

            _uow.CorporateService.Insert(corporate);
            await _uow.CommitAsync();

            return ResponseModel<Guid>.Success(corporate.Id);
        }
    }
}
