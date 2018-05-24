using NeuralNetwork.Helpers;
using NeuralNetwork.NetworkModels;
using SimpleNeuralNetwork.Model.Helper;
using SimpleNeuralNetwork.Model.Logger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static Network network;

        const string learningFileName = "trainingData.sigmoid";
        const string learningLogFileName = "learningLog.txt";
        const string learnedNetworkFilename = "learned.xml";
        const char learningFileDelimiter = ';';


        static void Main(string[] args)
        {
            CreateNewNetwork();
            TrainNetwork();
            SaveNetwork();

            Console.WriteLine("Done!");
            Console.ReadKey();
        }

        static void CreateNewNetwork()
        {
            network = new Network(inputSize: 2,
                hiddenSizes: new int[] { 3, 3 },
                outputSize: 1,
                logger: new ConsoleAndFileLogger(learningLogFileName),
                learnRate: 1, 
                momentum: 1);
        }

        static void TrainNetwork()
        {
            network.Train(DataSetHelper.GetDatasetsFromFile(learningFileName, learningFileDelimiter, network.InputLayer.Count, network.OutputLayer.Count), minimumError: 0.06f);
        }

        static void SaveNetwork()
        {
            ExportHelper.ExportNetwork(network, learnedNetworkFilename, new XmlSerializer());
        }

        static void LoadNetwork()
        {
            network = ImportHelper.ImportNetwork(learnedNetworkFilename, new XmlSerializer());
        }

        static double Compute(double x, double y)
        {
            return network.Compute(new double[] { x, y }).First();
        }
    }
}
