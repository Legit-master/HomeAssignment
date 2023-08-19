using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Text;

namespace LegitSecurity.WebHook
{
    /// <summary>
    /// This class listens for new events. and returns them for further handling.
    /// </summary>
    public class Listener
    {
        public static string Start(int port,string prefix)
        {
            var listener = new HttpListener();
            listener.Prefixes.Add($"{prefix}:{port}/");

            listener.Start();
            Console.WriteLine($"Listening for incoming webhook events on port {port}...");
            HttpListenerContext context = listener.GetContext();
            HttpListenerRequest request = context.Request;
            string requestData;
            using (var reader = new StreamReader(request.InputStream, request.ContentEncoding))
            {
                requestData = reader.ReadToEnd();
            }
            return requestData;
        }
    }
}

