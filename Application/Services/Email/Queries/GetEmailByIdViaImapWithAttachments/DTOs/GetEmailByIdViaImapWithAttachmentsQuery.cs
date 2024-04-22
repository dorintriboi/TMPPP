using Core.ExternalServices.EmailClases;
using Core.Validations;
using FluentValidation;
using MailKit;
using MediatR;

namespace Core.Services.Email.Queries.GetEmailByIdViaImapWithAttachments.DTOs;

public class GetEmailByIdViaImapWithAttachmentsQuery :
    BaseMediatorDtoValidation<GetEmailByIdViaImapWithAttachmentsQuery>, IRequest<EmailImapWithAttachments>
{
    public UniqueId Id { get; set; }

    protected override void Validation()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Id most be not null");
    }
}