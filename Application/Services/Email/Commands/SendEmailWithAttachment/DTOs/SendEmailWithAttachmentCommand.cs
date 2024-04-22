using Core.Validations;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Core.Services.Email.Commands.SendEmailWithAttachment.DTOs;

public class SendEmailWithAttachmentCommand
    : BaseMediatorDtoValidation<SendEmailWithAttachmentCommand>, IRequest
{
    public IFormFile Attachment { get; set; }
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string ReplyTo { get; set; }

    protected override void Validation()
    {
        RuleFor(x => x.Attachment)
            .NotEmpty()
            .WithMessage("Attachment most be not null");

        RuleFor(x => x.ToEmail)
            .NotEmpty()
            .WithMessage("ToEmail most be not null");

        RuleFor(x => x.Subject)
            .NotEmpty()
            .WithMessage("Subject most be not null");

        RuleFor(x => x.ReplyTo)
            .NotEmpty()
            .WithMessage("ReplyTo most be not null");
    }
}