using Application.Features.Auth.Constants;
using Application.Features.CustomizedImages.Rules;
using Application.Services.ImageGeneratorService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.CustomizedImages.Commands.Create;

public class CreateCustomizedImageCommand : IRequest<CreatedCustomizedImageResponse>, ISecuredRequest
{
    public required Guid Id { get; set; }

    public string[] Roles => [AuthOperationClaims.User];

    public class CreateCustomizedImageCommandHandler : IRequestHandler<CreateCustomizedImageCommand, CreatedCustomizedImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomizedImageRepository _customizedImageRepository;
        private readonly CustomizedImageBusinessRules _customizedImageBusinessRules;

        public CreateCustomizedImageCommandHandler(IMapper mapper, ICustomizedImageRepository customizedImageRepository,
                                         CustomizedImageBusinessRules customizedImageBusinessRules)
        {
            _mapper = mapper;
            _customizedImageRepository = customizedImageRepository;
            _customizedImageBusinessRules = customizedImageBusinessRules;
        }

        public async Task<CreatedCustomizedImageResponse> Handle(CreateCustomizedImageCommand request, CancellationToken cancellationToken)
        {

            CustomizedImage customizedImage = _mapper.Map<CustomizedImage>(request);


            await _customizedImageRepository.AddAsync(customizedImage);

            CreatedCustomizedImageResponse response = _mapper.Map<CreatedCustomizedImageResponse>(customizedImage);
            return response;
        }
    }
}