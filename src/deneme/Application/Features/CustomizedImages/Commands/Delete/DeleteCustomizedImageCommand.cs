using Application.Features.CustomizedImages.Constants;
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

namespace Application.Features.CustomizedImages.Commands.Delete;

public class DeleteCustomizedImageCommand : IRequest<DeletedCustomizedImageResponse>, ISecuredRequest, ICacheRemoverRequest, ILoggableRequest, ITransactionalRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [Admin, Write, CustomizedImagesOperationClaims.Delete];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetCustomizedImages"];

    public class DeleteCustomizedImageCommandHandler : IRequestHandler<DeleteCustomizedImageCommand, DeletedCustomizedImageResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomizedImageRepository _customizedImageRepository;
        private readonly CustomizedImageBusinessRules _customizedImageBusinessRules;

        public DeleteCustomizedImageCommandHandler(IMapper mapper, ICustomizedImageRepository customizedImageRepository,
                                         CustomizedImageBusinessRules customizedImageBusinessRules)
        {
            _mapper = mapper;
            _customizedImageRepository = customizedImageRepository;
            _customizedImageBusinessRules = customizedImageBusinessRules;
        }

        public async Task<DeletedCustomizedImageResponse> Handle(DeleteCustomizedImageCommand request, CancellationToken cancellationToken)
        {
            CustomizedImage? customizedImage = await _customizedImageRepository.GetAsync(predicate: ci => ci.Id == request.Id, cancellationToken: cancellationToken);
            await _customizedImageBusinessRules.CustomizedImageShouldExistWhenSelected(customizedImage);

            await _customizedImageRepository.DeleteAsync(customizedImage!);

            DeletedCustomizedImageResponse response = _mapper.Map<DeletedCustomizedImageResponse>(customizedImage);
            return response;
        }
    }
}