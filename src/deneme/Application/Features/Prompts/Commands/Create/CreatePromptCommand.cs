using Application.Features.CustomizedImages.Commands.Create;
using Application.Features.Prompts.Rules;
using Application.Services.CustomizedImages;
using Application.Services.ImageGeneratorService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Nest;

namespace Application.Features.Prompts.Commands.Create;

public class CreatePromptCommand : MediatR.IRequest<CreatedPromptResponse>
{
    public required string PromptString { get; set; }
    public required string PromptCategory { get; set; }

    public class CreatePromptCommandHandler : IRequestHandler<CreatePromptCommand, CreatedPromptResponse>
    {
        private readonly IPromptRepository _promptRepository;
        private readonly ImageGeneratorServiceBase _imageGeneratorService;
        private readonly PromptBusinessRules _bussinesRules; 
        private readonly ICustomizedImageService _customizedImageService;

        private readonly IMapper _mapper;



        public CreatePromptCommandHandler(
            IPromptRepository promptRepository,
            PromptBusinessRules businessRules,
            ImageGeneratorServiceBase imageGeneratorService, ICustomizedImageService customizedImageService,
            IMapper mapper)
        {
            _promptRepository = promptRepository;
            _imageGeneratorService = imageGeneratorService;
            _bussinesRules = businessRules;
            _mapper = mapper;
            _customizedImageService = customizedImageService;
        }

        public async Task<CreatedPromptResponse> Handle(CreatePromptCommand request, CancellationToken cancellationToken)
        { 

            Prompt prompt = _mapper.Map<Prompt>(request);

            await _promptRepository.AddAsync(prompt);
            string imageUrl = await _imageGeneratorService.CreateAsync(prompt.PromptString);

            CustomizedImage Image = new CustomizedImage();
            Image.ImageUrl = imageUrl;
            Image.PromptId = prompt.Id;
            await _customizedImageService.AddAsync(Image);


            prompt.ImageId = Image.Id;
            await _promptRepository.UpdateAsync(prompt);

            CreatedPromptResponse response = _mapper.Map<CreatedPromptResponse>(prompt);
            response.ImageUrl = imageUrl;
            return response;
        }
    }

    //public class CreatePromptCommandHandler : IRequestHandler<CreatePromptCommand, CreatedPromptResponse>
    //{
    //    private readonly IMapper _mapper;
    //    private readonly IPromptRepository _promptRepository;
    //    private readonly PromptBusinessRules _promptBusinessRules;
    //    private readonly ImageGeneratorServiceBase _imageGeneratorServiceBase;

    //    public CreatePromptCommandHandler(IMapper mapper, IPromptRepository promptRepository,
    //                                     PromptBusinessRules promptBusinessRules,ImageGeneratorServiceBase imageGeneratorServiceBase)
    //    {
    //        _mapper = mapper;
    //        _promptRepository = promptRepository;
    //        _promptBusinessRules = promptBusinessRules;
    //        _imageGeneratorServiceBase = imageGeneratorServiceBase;
    //    }

    //    public async Task<CreatedPromptResponse> Handle(CreatePromptCommand request, CancellationToken cancellationToken)
    //    {
    //        Prompt prompt = _mapper.Map<Prompt>(request);

    //        await _promptRepository.AddAsync(prompt);

    //        string url = await _imageGeneratorServiceBase.CreateAsync(prompt.PromptString);
    //        CreatedPromptResponse response = _mapper.Map<CreatedPromptResponse>(prompt);
    //        response.CustomizedImage = new CustomizedImage
    //        {
    //            ImagePrompt = prompt,
    //            CreatedDate = DateTime.UtcNow,
    //            Id = Guid.NewGuid(),
    //            ImageUrl = url
    //        };
    //        //image service yaz
    //        return response;
    //    }
    //}
}