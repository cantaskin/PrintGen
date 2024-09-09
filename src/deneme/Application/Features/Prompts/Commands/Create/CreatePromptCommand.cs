using Application.Features.Auth.Constants;
using Application.Features.CustomizedImages.Commands.Create;
using Application.Features.Prompts.Constants;
using Application.Features.Prompts.Rules;
using Application.Services.CustomizedImages;
using Application.Services.ImageGeneratorService;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using NArchitecture.Core.Application.Pipelines.Authorization;
using Nest;
using System.ComponentModel;

namespace Application.Features.Prompts.Commands.Create;

public class CreatePromptCommand : MediatR.IRequest<CreatedPromptResponse> , ISecuredRequest
{
    public required string PromptString { get; set; }
    public required Guid PromptCategoryId { get; set; }

    public string[] Roles => [AuthOperationClaims.User];


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
            // burada bir yerde getbyid ile promptcategory çekilip stringe eklenecek;
            string imageUrl = await _imageGeneratorService.CreateAsync(prompt.PromptString);

            CustomizedImage Image = new CustomizedImage();
            Image.ImageUrl = imageUrl;
            Image.PromptId = prompt.Id;
            Image = await _customizedImageService.AddAsync(Image);


            CreatedPromptResponse response = _mapper.Map<CreatedPromptResponse>(prompt);
            response.ImageId = Image.Id;
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