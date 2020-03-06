using System;
using System.IO;

namespace IoCSimpleDemo
{
    public class FileLogger : ILogger
    {
        string filePath;

        public FileLogger(string filePath)
        {
            this.filePath = filePath;

            Console.WriteLine("***ctor FileLogger");
        }

        public void Write(string text)
        {
            File.AppendAllText(filePath, text + "\n");
        }
    }
}