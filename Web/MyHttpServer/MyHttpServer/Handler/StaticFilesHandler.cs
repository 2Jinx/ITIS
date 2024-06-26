﻿using System.Net;
using MyHttpServer.Configuration;

namespace MyHttpServer.Handler
{
    public class StaticFilesHandler: IHandler
    {
        private readonly string _sitePreset;
        private readonly ServerConfiguration _configuration;

        public StaticFilesHandler(string sitePreset, ServerConfiguration configuration)
        {
            _sitePreset = sitePreset;
            _configuration = configuration;
        }

        public async void Handle(HttpListenerContext context)
        {
            try
            {
                HttpListenerRequest request = context.Request;
                HttpListenerResponse response = context.Response;
                string absolutePath = request.Url!.AbsolutePath, filePath = absolutePath;

                if (request.HttpMethod.Equals("Get", StringComparison.OrdinalIgnoreCase))
                {
                    if (filePath == "/")
                        filePath = _configuration!.StaticFilesPath + _sitePreset + "index.html";

                    if (filePath.StartsWith("/"))
                        filePath = filePath.Trim('/');

                    if (!File.Exists(filePath))
                    {
                        if (!File.Exists(_configuration!.StaticFilesPath + _sitePreset + filePath))
                        {
                            response.StatusCode = (int)HttpStatusCode.NotFound;
                            filePath = $"{_configuration.StaticFilesPath}/404.html";
                        }
                        else
                        {
                            filePath = _configuration.StaticFilesPath + _sitePreset + filePath;
                        }
                    }

                    string extension = Path.GetExtension(filePath);

                    ParseExtention(extension, response);

                    using (var fileStream = File.OpenRead(filePath))
                    {
                        await fileStream.CopyToAsync(response.OutputStream);
                    }

                    response.Close();
                }
                else if (request.HttpMethod.Equals("Post", StringComparison.OrdinalIgnoreCase))
                {
                    // вызываем ControllersHandler -> AuthenticationController -> SendEmail
                    new ControllersHandler(_sitePreset, _configuration).Handle(context);
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error handling request: {ex.Message}");
                Console.ResetColor();
            }
        }

        private void ParseExtention(string extention, HttpListenerResponse response)
        {
            switch (extention)
            {
                case ".html":
                    response.ContentType = "text/html";
                    break;
                case ".css":
                    response.ContentType = "text/css";
                    break;
                case ".jpeg":
                    response.ContentType = "image/jpeg";
                    break;
                case ".png":
                    response.ContentType = "image/png";
                    break;
                case ".svg":
                    response.ContentType = "image/svg+xml";
                    break;
                case ".ico":
                    response.ContentType = "image/x-icon";
                    break;
            }
        }
    }
}

