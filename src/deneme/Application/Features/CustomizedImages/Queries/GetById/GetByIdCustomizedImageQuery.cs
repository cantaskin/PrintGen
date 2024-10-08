using Application.Features.CustomizedImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CustomizedImages.Queries.GetById;

public class GetByIdCustomizedImageQuery : IRequest<GetByIdCustomizedImageResponse>
{
    public Guid Id { get; set; }

    public class GetByIdCustomizedImageQueryHandler : IRequestHandler<GetByIdCustomizedImageQuery, GetByIdCustomizedImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomizedImageRepository _customizedImageRepository;
        private readonly CustomizedImageBusinessRules _customizedImageBusinessRules;

        public GetByIdCustomizedImageQueryHandler(IMapper mapper, ICustomizedImageRepository customizedImageRepository, CustomizedImageBusinessRules customizedImageBusinessRules)
        {
            _mapper = mapper;
            _customizedImageRepository = customizedImageRepository;
            _customizedImageBusinessRules = customizedImageBusinessRules;
        }

        public async Task<GetByIdCustomizedImageResponse> Handle(GetByIdCustomizedImageQuery request, CancellationToken cancellationToken)
        {
            CustomizedImage? customizedImage = await _customizedImageRepository.GetAsync(predicate: ci => ci.Id == request.Id, cancellationToken: cancellationToken);
            await _customizedImageBusinessRules.CustomizedImageShouldExistWhenSelected(customizedImage);

            GetByIdCustomizedImageResponse response = _mapper.Map<GetByIdCustomizedImageResponse>(customizedImage);
            return response;
        }
    }
}