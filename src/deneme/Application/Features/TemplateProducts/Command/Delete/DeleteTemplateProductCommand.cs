using Application.Features.TemplateProducts.Rules;
using Application.Services.TemplateProducts;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.TemplateProducts.Command.Delete;
public class DeleteTemplateProductCommand : IRequest<DeletedTemplateProductResponse>
{
    public Guid TemplateId { get; set; }
    public class DeleteTemplateProductCommandHandler : MediatR.IRequestHandler<DeleteTemplateProductCommand, DeletedTemplateProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITemplateProductService _templateProductService;
        private readonly TemplateProductBusinessRules _templateProductBusinessRules;
        
        public DeleteTemplateProductCommandHandler(IMapper mapper, ITemplateProductService templateProductService, TemplateProductBusinessRules templateProductBusinessRules)
        {
            _mapper = mapper;
            _templateProductService = templateProductService;
            _templateProductBusinessRules = templateProductBusinessRules;
        }
        public async Task<DeletedTemplateProductResponse> Handle(DeleteTemplateProductCommand request, CancellationToken cancellationToken)
        {
            TemplateProduct templateProduct = _mapper.Map<TemplateProduct>(request);
            await _templateProductBusinessRules.TemplateProductShouldExistWhenSelected(templateProduct);

            await _templateProductService.DeleteAsync(templateProduct);

            DeletedTemplateProductResponse deletedTemplateProductResponse = _mapper.Map<DeletedTemplateProductResponse>(request);
            return deletedTemplateProductResponse;

        }
    }
}
