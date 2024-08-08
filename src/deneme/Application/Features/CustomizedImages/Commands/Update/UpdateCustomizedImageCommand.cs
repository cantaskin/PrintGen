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

namespace Application.Features.CustomizedImages.Commands.Update;

public class UpdateCustomizedImageCommand : IRequest<UpdatedCustomizedImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }
    public required Guid PrintAreaId { get; set; }
    public required string Prompt { get; set; }
    public required int X { get; set; }
    public required int Y { get; set; }

    public string[] Roles => [Admin, Write, CustomizedImagesOperationClaims.Update];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCustomizedImages"];

    public class UpdateCustomizedImageCommandHandler : IRequestHandler<UpdateCustomizedImageCommand, UpdatedCustomizedImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomizedImageRepository _customizedImageRepository;
        private readonly CustomizedImageBusinessRules _customizedImageBusinessRules;

        public UpdateCustomizedImageCommandHandler(IMapper mapper, ICustomizedImageRepository customizedImageRepository,
                                         CustomizedImageBusinessRules customizedImageBusinessRules)
        {
            _mapper = mapper;
            _customizedImageRepository = customizedImageRepository;
            _customizedImageBusinessRules = customizedImageBusinessRules;
        }

        public async Task<UpdatedCustomizedImageResponse> Handle(UpdateCustomizedImageCommand request, CancellationToken cancellationToken)
        {
            CustomizedImage? customizedImage = await _customizedImageRepository.GetAsync(predicate: ci => ci.Id == request.Id, cancellationToken: cancellationToken);
            await _customizedImageBusinessRules.CustomizedImageShouldExistWhenSelected(customizedImage);
            customizedImage = _mapper.Map(request, customizedImage);

            await _customizedImageRepository.UpdateAsync(customizedImage!);

            UpdatedCustomizedImageResponse response = _mapper.Map<UpdatedCustomizedImageResponse>(customizedImage);
            return response;
        }
    }
}