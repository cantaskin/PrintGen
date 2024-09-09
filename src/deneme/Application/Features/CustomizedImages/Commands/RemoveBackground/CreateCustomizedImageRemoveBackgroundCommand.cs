using Application.Features.Auth.Constants;
using Application.Features.CustomizedImages.Rules;
using Application.Services.ImageGeneratorService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;

namespace Application.Features.CustomizedImages.Commands.Create;

public class CreateCustomizedImageRemoveBackgroundCommand : IRequest<CreatedCustomizedImageRemoveBackgroundResponse>, ISecuredRequest
{
    public required Guid Id { get; set; }

    public string[] Roles => [AuthOperationClaims.User];
    public class CreateCustomizedImageRemoveBackgroundCommandHandler : IRequestHandler<CreateCustomizedImageRemoveBackgroundCommand, CreatedCustomizedImageRemoveBackgroundResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomizedImageRepository _customizedImageRepository;
        private readonly CustomizedImageBusinessRules _customizedImageBusinessRules;
        private readonly ImageGeneratorServiceBase _imageGeneratorService;

        public CreateCustomizedImageRemoveBackgroundCommandHandler(IMapper mapper, ICustomizedImageRepository customizedImageRepository,
                                         CustomizedImageBusinessRules customizedImageBusinessRules, ImageGeneratorServiceBase imageGeneratorServiceBase)
        {
            _mapper = mapper;
            _customizedImageRepository = customizedImageRepository;
            _customizedImageBusinessRules = customizedImageBusinessRules;
            _imageGeneratorService = imageGeneratorServiceBase;
        }

        public async Task<CreatedCustomizedImageRemoveBackgroundResponse> Handle(CreateCustomizedImageRemoveBackgroundCommand request, CancellationToken cancellationToken)
        {
            //CustomizedImage? customizedImage = _mapper.Map<CustomizedImage>(request);

            CustomizedImage? customizedImage = await _customizedImageRepository.GetAsync(ci => ci.Id == request.Id);

            if (customizedImage == null)
            {
                throw new InvalidOperationException("Customized image not found.");
            }

            CustomizedImage Image = new()
            {
                CreatedDate = DateTime.Now,
                PromptId = customizedImage.PromptId,
                ImageUrl = customizedImage.ImageUrl
            };

            Image.ImageUrl = await _imageGeneratorService.RemoveBackgroundAsync(Image.ImageUrl);

            
            await _customizedImageRepository.AddAsync(Image);

            CreatedCustomizedImageRemoveBackgroundResponse response = _mapper.Map<CreatedCustomizedImageRemoveBackgroundResponse>(customizedImage);
            return response;
        }
    }
}