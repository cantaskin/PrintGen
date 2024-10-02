using Application.Features.Addresses.Commands.Create;
using FluentValidation;

namespace Application.Features.Mockups.Commands.Create;

public class CreateMockupCommandValidator : AbstractValidator<CreateMockupCommand>
{
    public CreateMockupCommandValidator()
    {
    }
}