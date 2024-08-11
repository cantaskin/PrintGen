using Application.Features.CustomizedImages.Rules;
using Application.Services.ImageGeneratorService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.CustomizedImages.Commands.Create;

public class CreateCustomizedImageRemoveBackgroundCommand : IRequest<CreatedCustomizedImageRemoveBackgroundResponse>
{
    public required string ImageUrl { get; set; }
    public required Guid PromptId { get; set; }

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
            CustomizedImage customizedImage = _mapper.Map<CustomizedImage>(request);

            customizedImage.ImageUrl = await _imageGeneratorService.RemoveBackgroundAsync(customizedImage.ImageUrl);

            await _customizedImageRepository.AddAsync(customizedImage);

            CreatedCustomizedImageRemoveBackgroundResponse response = _mapper.Map<CreatedCustomizedImageRemoveBackgroundResponse>(customizedImage);
            return response;
        }
    }
}