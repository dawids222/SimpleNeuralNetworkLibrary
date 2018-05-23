﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NeuralNetwork.NetworkModels;

namespace NeuralNetwork.Helpers
{
	public static class ImportHelper
	{
        public static Network ImportNetwork(string filename, ISerializer serializer)
        {
            var dn = GetHelperNetwork(filename, serializer);
            if (dn == null) return null;

            var network = new Network();
            var allNeurons = new List<Neuron>();

            network.LearnRate = dn.LearnRate;
            network.Momentum = dn.Momentum;

            //Input Layer
            foreach (var n in dn.InputLayer)
            {
                var neuron = new Neuron
                {
                    Id = n.Id,
                    Bias = n.Bias,
                    BiasDelta = n.BiasDelta,
                    Gradient = n.Gradient,
                    Value = n.Value
                };

                network.InputLayer.Add(neuron);
                allNeurons.Add(neuron);
            }

            //Hidden Layers
            foreach (var layer in dn.HiddenLayers)
            {
                var neurons = new List<Neuron>();
                foreach (var n in layer)
                {
                    var neuron = new Neuron
                    {
                        Id = n.Id,
                        Bias = n.Bias,
                        BiasDelta = n.BiasDelta,
                        Gradient = n.Gradient,
                        Value = n.Value
                    };

                    neurons.Add(neuron);
                    allNeurons.Add(neuron);
                }

                network.HiddenLayers.Add(neurons);
            }

            //Export Layer
            foreach (var n in dn.OutputLayer)
            {
                var neuron = new Neuron
                {
                    Id = n.Id,
                    Bias = n.Bias,
                    BiasDelta = n.BiasDelta,
                    Gradient = n.Gradient,
                    Value = n.Value
                };

                network.OutputLayer.Add(neuron);
                allNeurons.Add(neuron);
            }

            //Synapses
            foreach (var syn in dn.Synapses)
            {
                var synapse = new Synapse { Id = syn.Id };
                var inputNeuron = allNeurons.First(x => x.Id == syn.InputNeuronId);
                var outputNeuron = allNeurons.First(x => x.Id == syn.OutputNeuronId);
                synapse.InputNeuron = inputNeuron;
                synapse.OutputNeuron = outputNeuron;
                synapse.Weight = syn.Weight;
                synapse.WeightDelta = syn.WeightDelta;

                inputNeuron.OutputSynapses.Add(synapse);
                outputNeuron.InputSynapses.Add(synapse);
            }

            return network;
        }

        private static HelperNetwork GetHelperNetwork(string filename, ISerializer serializer)
        {
            return serializer.Deserialize(filename);
        }

    }
}
