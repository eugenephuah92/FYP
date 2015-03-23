using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using OpenPop.Pop3;
using OpenPop.Mime;

/// <summary>
/// Summary description for Email
/// </summary>
[Serializable]
public class Email
{
    public Email()
    {
        this.Attachments = new List<Attachment>();
    }
    public int MessageNumber { get; set; }
    public string From { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public DateTime DateSent { get; set; }
    public List<Attachment> Attachments { get; set; }

    internal void Read_Emails()
    {
        throw new NotImplementedException();
    }
}