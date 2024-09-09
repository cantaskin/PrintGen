using Application.Features.Auth.Constants;
using Application.Features.CustomizedImages.Constants;
using Application.Features.CustomizedImages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.CustomizedImages.Commands.Delete;

public class DeleteCustomizedImageCommand : IRequest<DeletedCustomizedImageResponse>, ISecuredRequest
{
    public Guid Id { get; set; }

    public string[] Roles => [];

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