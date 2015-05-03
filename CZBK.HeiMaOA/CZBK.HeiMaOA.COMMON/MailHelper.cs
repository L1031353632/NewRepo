using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.HeiMaOA.COMMON
{
    class MailHelper
    {
        /// <summary>
        /// 发送邮件类
        /// </summary>
        /// <param name="ToAddress">收件人地址</param>
        /// <param name="title">邮件的标题</param>
        /// <param name="content">邮件的内容</param>
        public void SendEmail(string ToAddress, string title, string content)
        {
            MailMessage mailMsg = new MailMessage();//两个类，别混了，要引入System.Net这个Assembly
            mailMsg.From = new MailAddress("wang_itcast@126.com", "王承伟");//源邮件地址 
            mailMsg.To.Add(new MailAddress(ToAddress));//目的邮件地址。可以有多个收件人
            mailMsg.Subject = title;//发送邮件的标题 
            mailMsg.Body = content;//发送邮件的内容 
            mailMsg.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.126.com");//smtp.163.com，smtp.qq.com
            client.Credentials = new NetworkCredential("wang_itcast", "wangchengwei");
            client.Send(mailMsg);//排队发送邮件.
        }
    }
}
