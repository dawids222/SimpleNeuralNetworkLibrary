using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork.Model.Logger
{
    public class FileLogger : ILogger
    {
        public string FileName { get; private set; }


        public FileLogger(string fileName)
        {
            FileName = fileName;
        }


        public void Log(object message)
        {
            using (var writer = File.AppendText(FileName))
            {
                writer.WriteLine(message);
            }
        }
    }
}
