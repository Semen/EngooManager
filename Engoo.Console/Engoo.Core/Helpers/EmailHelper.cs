using Engoo.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Engoo.Core.Helpers
{
	public static class EmailHelper
	{
		public static void SendNotice(List<Teacher> teachers)
		{
			var fromAddress = new MailAddress("s.i.gordeyev@gmail.com", "Engoo");
			var toAddress = new MailAddress("senyagordeev@gmail.com", "Me");

			var smtp = new SmtpClient
			{
				Host = "smtp.gmail.com",
				Port = 587,
				EnableSsl = true,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				UseDefaultCredentials = false,
				Credentials = new NetworkCredential(fromAddress.Address, "!!2qfflvbyrj0011")
			};

			using (var message = new MailMessage(fromAddress, toAddress)
			{
				Subject = "New lessons available",
				IsBodyHtml = true
			})
			{
				message.Body = "New lessons available from teacher " + string.Join("; ", teachers.Select(x => $"<a href='https://engoo.com/teachers/{x.TeacherId}'>{ x.Name}</a> "));
				
				smtp.Send(message);
			}
		}
	}
}
