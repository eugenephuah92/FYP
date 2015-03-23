using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using OpenPop.Pop3;
using OpenPop.Mime;
/// <summary>
/// Summary description for Attachment
/// </summary>
[Serializable]
public class Attachment
{
    public string FileName { get; set; }
    public string ContentType { get; set; }
    public byte[] Content { get; set; }
}
