using System;
using System.Collections.Generic;

using PatternRecognition.NeuralNetworks.Networks;
using PatternRecognition.NeuralNetworks.Neurons;
using PatternRecognition.NeuralNetworks.Teaching;
using PatternRecognition.Tools;
using Commons = PatternRecognition.PatternRecognitionCommons;

namespace PatternRecognition.NeuralNetworks
{
    public static class NeuralNetworksUtils
    {
        public static NetworkLayer CreatePerceptronLayer(int size, int perceptronDim)
        {
            IList<Neuron> neurons = new List<Neuron>();
            for (int i = 0; i < size; i++)
            {
                Perceptron perceptron = new Perceptron(perceptronDim);
                perceptron.InitRandomWeights();
                neurons.Add(perceptron);
            }
            return NetworkLayer.Of(neurons);
        }
        
        public static MultiLayerNetwork CreateTwoLayerPerceptronNetwork(int layer1Size, int layer2Size, int inputDim)
        {
            NetworkLayer layer1 = CreatePerceptronLayer(layer1Size, inputDim);
            NetworkLayer layer2 = CreatePerceptronLayer(layer2Size, layer1Size);
            IList<NetworkLayer> layers = new List<NetworkLayer>() { layer1, layer2 };
            return MultiLayerNetwork.Of(layers);
        }
        
        public static double CalculateErrorProbability(this NetworkLayer layer, IList<NetworkTeachingPair> teachingSet)
        {
            double errorsCount = 0;
            foreach (NetworkTeachingPair pair in teachingSet)
            {
                if (!layer.FireSignal(pair.Input).EqualsElementwiseWithPrecision(pair.Output, 0.001))
                    errorsCount++;
            }
            return errorsCount/teachingSet.Count;
        }
    }
}
