using Application.Common.Attributes;
using Application.Common.Interfaces.Repository;
using Application.Common.Models;
using Application.UseCases.Corporates.Model;
using AutoMapper;
using MediatR;

namespace Application.UseCases.Corporates.Queries
{

    public class GetAllCorporatesQuery : IRequest<ResponseModel>
    {
    }

    public class GetAllCorporatesQueryHandler : IRequestHandler<GetAllCorporatesQuery, ResponseModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllCorporatesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Handle(GetAllCorporatesQuery request, CancellationToken cancellationToken)
        {
            var corporates = await _unitOfWork.CorporateService.GetAsync();
            return ResponseModel<List<CorporateDTO>>.Success(data: _mapper.Map<List<CorporateDTO>>(corporates));
        }
    }
}
