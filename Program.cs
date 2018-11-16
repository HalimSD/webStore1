using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Imap;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            // using (var client = new ImapClient ()) {
			// 	// For demo-purposes, accept all SSL certificates
			// 	client.ServerCertificateValidationCallback = (s,c,h,e) => true;

			// 	client.Connect ("imap.friends.com", 993, true);

			// 	client.Authenticate ("joey", "password");

			// 	// The Inbox folder is always available on all IMAP servers...
			// 	var inbox = client.Inbox;
			// 	inbox.Open (FolderAccess.ReadOnly);

			// 	Console.WriteLine ("Total messages: {0}", inbox.Count);
			// 	Console.WriteLine ("Recent messages: {0}", inbox.Recent);

			// 	for (int i = 0; i < inbox.Count; i++) {
			// 		var message = inbox.GetMessage (i);
			// 		Console.WriteLine ("Subject: {0}", message.Subject);
			// 	}

			// 	client.Disconnect (true);
			// }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
