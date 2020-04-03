using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Nancy;
using Nancy.Hosting.Self;

namespace CheckpointA
{
    public class HelloModule : NancyModule
    {
        public HelloModule()
        {
            Get("/", _ => "Hello World");

            Get("/file/{file}", p =>
            {
                string filepath = p.file;
                if (File.Exists(filepath))
                {
                    string text = File.ReadAllText(filepath);
                    return text;
                }
                else
                {
                    return "The requested file doesn't exist";
                }
            });

            Delete("/file/{file}", p =>
            {
                string filepath = p.file;
                if (File.Exists(filepath))
                {
                    File.Delete(filepath);
                    return $"File Succefully Deleted \n FilePath : {filepath}";
                }
                else
                {
                    return "The requested file doesn't exist";
                }
            });
            
            Put("/file/{file}", p =>
            {
                string filepath = AppDomain.CurrentDomain.BaseDirectory + p.file;
                File.Create(filepath);
                return $"File Succefully Created \n FilePath : {filepath}";
            });
        }        
    }
}
