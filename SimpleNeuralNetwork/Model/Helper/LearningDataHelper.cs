using NeuralNetwork.NetworkModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork.Model.Helper
{
    public static class LearningDataHelper
    {
        public static List<DataSet> GetDatasets(string learningFileName, char delimiter, int inputCount, int targetCount)
        {
            var result = new List<DataSet>();

            using (var reader = new StreamReader(learningFileName))
            {
                List<double> inputs = new List<double>();
                List<double> targets = new List<double>();

                while (!reader.EndOfStream)
                {
                    var elements = reader.ReadLine().Split(delimiter);

                    for(int i = 0; i < inputCount; i++)
                    {
                        inputs.Add(double.Parse(elements[i]));
                    }
                
                    for(int i = inputCount; i < inputCount + targetCount; i++)
                    {
                        targets.Add(double.Parse(elements[i]));
                    }

                    var dataset = new DataSet(inputs.ToArray(), targets.ToArray());
                    result.Add(dataset);

                    inputs.Clear();
                    targets.Clear();
                }
            }

            return result;
        }
    }
}
