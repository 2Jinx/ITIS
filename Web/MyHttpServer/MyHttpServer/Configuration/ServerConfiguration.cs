﻿using System.Net;
using System.Text.Json;

namespace MyHttpServer.Configuration
{
    public class ServerConfiguration
    {
        private const string _configFilePath = "appsettings.json";
        private readonly object _lock = new object();
        private AppSettings _config;

        public ServerConfiguration()
        {
            if (_config == null)
            {
                lock (_lock)
                {
                    if(_config == null)
                        _config = new AppSettings();
                }
            }
            
        }

        /// <summary>
        /// Server configuration settings
        /// </summary>
        /// <param name="httplistener"></param>
        public void Set(HttpListener httplistener)
        {
            try
            {
                if (!File.Exists(_configFilePath))
                {
                    throw new FileNotFoundException("json file not found!");
                }

                
                using (FileStream file = File.OpenRead(_configFilePath))
                {
                    _config = JsonSerializer.Deserialize<AppSettings>(file);
                }

                httplistener.Prefixes.Add($"{_config?.Address}:{_config?.Port}/");
                httplistener.Prefixes.Add($"http://localhost:{_config?.Port}/");
            }
            catch(Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Configuration: {ex.Message}");
                Console.ResetColor();
            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("=== Configuration: All configurations set! ===\n");
                Console.ResetColor();
            }
        }

        /// <summary>
        /// Static files path
        /// </summary>
        public string StaticFilesPath
        {
            get { return _config.StaticFilesPath; }
            set
            {
                if (!Directory.Exists(_config?.StaticFilesPath))
                {
                    Directory.CreateDirectory(_config.StaticFilesPath);
                }
            }
        }

        public string MailSender
        {
            get { return _config.MailSender; }
        }

        public string PasswordSender
        {
            get { return _config.PasswordSender; }
        }

        public string FromEmail
        {
            get { return _config.FromEmail; }
        }

        public string SmtpServerHost
        {
            get { return _config.SmtpServerHost; }
        }

        public int SmtpServerPort
        {
            get { return _config.SmtpServerPort; }
        }
    }
}

