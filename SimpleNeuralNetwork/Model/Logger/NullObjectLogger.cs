using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork.Model.Logger
{
    /// <summary>
    /// Klasa nic nie loguje
    /// </summary>
    public class NullObjectLogger : ILogger
    {
        public void Log(object message)
        {
            // Do nothing
        }
    }
}
