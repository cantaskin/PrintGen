using Application.Features.CustomizedImages.Constants;
using Application.Features.CustomizedImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using NArchitecture.Core.Application.Pipelines.Logging;
using NArchitecture.Core.Application.Pipelines.Transaction;
using MediatR;
using static Application.Features.CustomizedImages.Constants.CustomizedImagesOperationClaims;
using System.Drawing;

namespace Application.Features.CustomizedImages.Commands.Create;

public class CreateCustomizedImageCommand : IRequest<CreatedCustomizedImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid? PrintAreaId { get; set; }
    public required string Prompt { get; set; }
    public required int X { get; set; }
    public required int Y { get; set; }

    public string[] Roles => [Admin, Write, CustomizedImagesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCustomizedImages"];

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