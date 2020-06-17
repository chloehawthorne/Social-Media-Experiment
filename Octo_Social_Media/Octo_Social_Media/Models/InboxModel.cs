using System;
using System.Collections.Generic;
using System.Text;

namespace Octo_Social_Media.Models
{
    public class InboxModel
    {
        public string Username { get; set; }
        public string Message { get; set; }
        public string ShortenedMessage()
        {
            Message.Substring(0, Math.Min(Message.Length, 50));
            return Message;
        }
        public string FinalMessage
        {
            get { return ShortenedMessage(); }
        }
    }
}
