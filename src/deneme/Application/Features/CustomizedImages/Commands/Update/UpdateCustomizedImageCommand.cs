using Application.Features.Auth.Constants;
using Application.Features.CustomizedImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.CustomizedImages.Commands.Update;

public class UpdateCustomizedImageCommand : IRequest<UpdatedCustomizedImageResponse>, ISecuredRequest
{
    public Guid Id { get; set; }
    public string? ImageUrl { get; set; }
    public required Guid PromptId { get; set; }

    public string[] Roles => [];

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