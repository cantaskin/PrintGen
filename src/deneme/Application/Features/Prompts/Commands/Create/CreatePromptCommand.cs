using Application.Features.Prompts.Rules;
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
    public required Guid PrintAreaId { get; set; }

    public class CreatePromptCommandHandler : IRequestHandler<CreatePromptCommand, CreatedPromptResponse>
    {
        private readonly IPromptRepository _promptRepository;
        private readonly ICustomizedImageRepository _customizedImageRepository;
        private readonly ImageGeneratorServiceBase _imageGeneratorService;
        private readonly PromptBusinessRules _bussinesRules;
        private readonly IMapper _mapper;

        public CreatePromptCommandHandler(
            IPromptRepository promptRepository,
            PromptBusinessRules businessRules,
            ICustomizedImageRepository customizedImageRepository,
            ImageGeneratorServiceBase imageGeneratorService,
            IMapper mapper)
        {
            _promptRepository = promptRepository;
            _customizedImageRepository = customizedImageRepository;
            _imageGeneratorService = imageGeneratorService;
            _bussinesRules = businessRules;
            _mapper = mapper;
        }

        public async Task<CreatedPromptResponse> Handle(CreatePromptCommand request, CancellationToken cancellationToken)
        {
                Prompt prompt = _mapper.Map<Prompt>(request);
                prompt.PromptString = request.PromptString;

                await _promptRepository.AddAsync(prompt);

                string imageUrl = await _imageGeneratorService.CreateAsync(prompt.PromptString);

                var customizedImage = new CustomizedImage
                {
                    ImageUrl = imageUrl,
                    PrintAreaId = request.PrintAreaId, // Assuming this comes from the request
                    X = 100, // Assuming this comes from the request
                    Y = 100, // Assuming this comes from the request
                    PromptId = prompt.Id
                };

                await _customizedImageRepository.AddAsync(customizedImage);

                CreatedPromptResponse response = _mapper.Map<CreatedPromptResponse>(prompt);
                response.ImageId = customizedImage.Id;

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