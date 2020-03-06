using System;

namespace IoCSimpleDemo
{
    public class ConsoleLogger : ILogger
    {
        public ConsoleLogger()
        {
            Console.WriteLine("*** ctor ConsoleLogger");
        }

        public void Write(string text)
        {
            Console.WriteLine("*** " + text);
        }
    }
}