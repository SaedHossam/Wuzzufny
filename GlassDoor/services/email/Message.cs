using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MimeKit;

namespace GlassDoor.services.email
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public bool IsHtml { get; set; }
        public IFormFileCollection Attachments { get; set; }

        public Message(IEnumerable<string> to, string subject, string content, IFormFileCollection attachments, bool isHtml)
        {
            To = new List<MailboxAddress>();

            To.AddRange(to.Select(x => new MailboxAddress(x)));
            Subject = subject;
            Content = content;
            Attachments = attachments;
            IsHtml = isHtml;
        }
    }
}
