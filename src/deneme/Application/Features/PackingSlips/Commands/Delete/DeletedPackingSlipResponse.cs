using NArchitecture.Core.Application.Responses;

namespace Application.Features.PackingSlips.Commands.Delete;

public class DeletedPackingSlipResponse : IResponse
{
    public Guid Id { get; set; }
}