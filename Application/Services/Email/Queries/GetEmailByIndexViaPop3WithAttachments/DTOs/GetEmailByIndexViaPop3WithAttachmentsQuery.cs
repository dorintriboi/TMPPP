using Core.ExternalServices.EmailClases;
using Core.Validations;
using FluentValidation;
using MediatR;

namespace Core.Services.Email.Queries.GetEmailByIndexViaPop3WithAttachments.DTOs;

public class GetEmailByIndexViaPop3WithAttachmentsQuery:
    BaseMediatorDtoValidation<GetEmailByIndexViaPop3WithAttachmentsQuery>, IRequest<EmailPop3WithAttachments>
{
    public int Index { get; set; }

    protected override void Validation()
    {
        RuleFor(x => x.Index)
            .NotEmpty()
            .WithMessage("Index most be not null");
    }
}