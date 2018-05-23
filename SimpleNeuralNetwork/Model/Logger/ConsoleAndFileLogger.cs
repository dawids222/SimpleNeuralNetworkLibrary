using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork.Model.Logger
{
    public class ConsoleAndFileLogger : ILogger
    {
        private ConsoleLogger _consoleLogger;
        private FileLogger _fileLogger;


        public ConsoleAndFileLogger(string filename)
        {
            _consoleLogger = new ConsoleLogger();
            _fileLogger = new FileLogger(filename);
        }


        public void Log(object message)
        {
            _consoleLogger.Log(message);
            _fileLogger.Log(message);
        }
    }
}
