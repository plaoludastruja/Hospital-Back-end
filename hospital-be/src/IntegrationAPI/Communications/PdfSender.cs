﻿using RestSharp;

namespace IntegrationAPI.Communications
{
    public class PdfSender
    {
        public static string SendPdf(string url, string path)
        {
            //"http://localhost:8080/bloodUsage/upload"
            var options = new RestClientOptions(url)
            {
                ThrowOnAnyError = true,
                MaxTimeout = -1
            };
            var client = new RestClient(options);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddFile("file", path);
            var response = client.ExecuteAsync(request);
            return response.Result.ResponseStatus.ToString();

        }
        
    }
}
