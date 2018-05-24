using NeuralNetwork.NetworkModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetwork.Model.Helper
{
    public static class DataSetHelper
    {
        public static List<DataSet> GetDatasetsFromFile(string learningFileName, char delimiter, int inputCount, int targetCount)
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

        public static void SaveDatasetsToFile(List<DataSet> datasets, string filename, char delimiter)
        {
            using (var writer = File.AppendText(filename))
            {
                foreach (var dataset in datasets)
                {
                    writer.WriteLine(CreateDatalineFromDataset(dataset, delimiter));
                }
            }
        }

        public static string CreateDatalineFromDataset(DataSet dataset, char delimiter)
        {
            var line = string.Empty;

            foreach (var value in dataset.Values)
            {
                line += value;
                line += delimiter;
            }

            for (int i = 0; i < dataset.Targets.Length; i++)
            {
                line += dataset.Targets[i];
                if (i < dataset.Targets.Length - 1)
                    line += delimiter;
            }

            return line;
        }
    }
}
