using Microsoft.VisualStudio.TestTools.UnitTesting;
using NeuralNetwork.NetworkModels;
using SimpleNeuralNetwork.Model.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleNeuralNetworkTest.Helper
{
    [TestClass]
    public class DataSetHelperTest
    {
        const string correctFilename = "trainingData.sigmoid";
        const char correctDelimiter = ';';
        const int correctInputs = 2;
        const int correctTargets = 1;

        const string wrongFilename = "wrongPath.txt";
        const char wrongDelimiter = ':';
        const int wrongInputs = 3;
        const int wrongTargets = 2;

        [TestMethod]
        public void GetDatasetsFromFile_CorrectArguments_CreatesDataSets()
        {
            var dataSets = DataSetHelper.GetDatasetsFromFile(correctFilename, correctDelimiter, correctInputs, correctTargets);

            var expectedCount = 123;
            Assert.IsNotNull(dataSets);
            Assert.AreEqual(expectedCount, dataSets.Count);
            Assert.AreEqual(correctInputs, dataSets.First().Values.Count());
            Assert.AreEqual(correctTargets, dataSets.First().Targets.Count());
        }

        [TestMethod]
        public void GetDatasetsFromFile_WrongFileName_Throws()
        {
            try
            {
                var dataSets = DataSetHelper.GetDatasetsFromFile(wrongFilename, correctDelimiter, correctInputs, correctTargets);
            }
            catch(Exception)
            {
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void GetDatasetsFromFile_WrongDelimiter_Throws()
        {
            try
            {
                var dataSets = DataSetHelper.GetDatasetsFromFile(correctFilename, wrongDelimiter, correctInputs, correctTargets);
            }
            catch (Exception)
            {
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void GetDatasetsFromFile_WrongInputs_Throws()
        {
            try
            {
                var dataSets = DataSetHelper.GetDatasetsFromFile(correctFilename, correctDelimiter, wrongInputs, correctTargets);
            }
            catch (Exception)
            {
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void GetDatasetsFromFile_WrongTargets_Throws()
        {
            try
            {
                var dataSets = DataSetHelper.GetDatasetsFromFile(correctFilename, correctDelimiter, correctInputs, wrongTargets);
            }
            catch (Exception)
            {
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void CreateDatalineFromDataset_2Values2Targets_CreatesDataLine()
        {
            var dataset = new DataSet(new double[] { 4.123, 6.8765 }, new double[] { 3.2, 4 });

            var line = DataSetHelper.CreateDatalineFromDataset(dataset, correctDelimiter);

            var expectedOutput = "4,123;6,8765;3,2;4";
            Assert.AreEqual(expectedOutput, line);
        }
    }
}
