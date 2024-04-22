using Core.Services.Email.Queries.GetEmailByIdViaImapWithAttachments.DTOs;
using Core.Services.Email.Queries.GetEmailByIndexViaPop3WithAttachments.DTOs;
using Core.Services.Email.Queries.GetEmailsViaImap.DTOs;
using Core.Services.Email.Queries.GetEmailsViaPop3.DTOs;
using Core.Services.Email.Queries.GetEmailsViaPop3WithAttachments.DTOs;
using Core.Services.Email.Queries.GetEmailViaImapWithAttachments.DTOs;
using MailKit;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proiect_Teatru.Models.V1.In.Email;

namespace Proiect_Teatru.Controllers.V1;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class Email(IMediator mediator) : ControllerBase
{
    [HttpGet("list/pop3/attachments")]
    [Authorize]
    public async Task<IActionResult?> GetEmailsViaPop3WithAttachments()
    {
        return Ok(new JsonResult(await mediator.Send(new GetEmailsViaPop3WithAttachmentsQuery())));
    }
    
    [HttpGet("list/pop3")]
    [Authorize]
    public async Task<IActionResult?> GetEmailsViaPop3()
    {
        return Ok(new JsonResult(await mediator.Send(new GetEmailsViaPop3Query())));
    }
    
    [HttpGet("list/imap")]
    [Authorize]
    public async Task<IActionResult?> GetEmailsViaImap()
    {
        return Ok(new JsonResult(await mediator.Send(new GetEmailsViaImapQuery())));
    }
    
    [HttpGet("list/imap/attachments")]
    [Authorize]
    public async Task<IActionResult?> GetEmailsViaImapWithAttachments()
    {
        return Ok(new JsonResult(await mediator.Send(new GetEmailsViaImapWithAttachmentsQuery())));
    }
    
    [HttpGet("pop3/attachment/{index}")]
    [Authorize]
    public async Task<IActionResult?> GetEmailByIndexViaPop3WithAttachments(int index)
    {
        return Ok(new JsonResult(await mediator.Send(new GetEmailByIndexViaPop3WithAttachmentsQuery(){Index = index})));
    }
    
    [HttpGet("imap/attachment/{id}")]
    [Authorize]
    public async Task<IActionResult?> GetEmailByIdViaImapWithAttachments(string id)
    {
        return Ok(new JsonResult(await mediator.Send(new GetEmailByIdViaImapWithAttachmentsQuery(){Id =UniqueId.Parse(id)})));
    }
    
    [HttpPost("attachment")]
    [Authorize]
    public async Task<IActionResult?> SendEmailWithAttachment([FromForm]SendEmailWithAttachmentRequestViewModel request)
    {
        await mediator.Send(request.Convert());
        return Ok();
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult?> SendEmailWithSubject([FromBody]SendEmailWithSubjectRequestViewModel request)
    {
        await mediator.Send(request.Convert());
        return Ok();
    }
}