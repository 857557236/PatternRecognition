using System;
using System.Collections.Generic;

using PatternRecognition.NeuralNetworks.Neurons;
using PatternRecognition.Tools;

namespace PatternRecognition.NeuralNetworks.Networks
{
    public class HopfieldNetwork
    {        
        private NetworkLayer layer;
        private double forgetRatio;
        
        public HopfieldNetwork(int dim, double forgetRatio)
        {
            IList<Neuron> neurons = new List<Neuron>();
            for (int i = 0; i < dim; i++) 
            {
                neurons.Add(MemoryNeuron.Create(dim));
            }            
            layer = NetworkLayer.Of(neurons);
            this.forgetRatio = forgetRatio;
        }
    
        public void Memorize(double[] input) 
        {
            for (int i = 0; i < Size; i++) 
            {
                for (int j = 0; j < Neurons[i].Weights.Length; j++) 
                {
                    Neurons[i].Weights[j] += input[i]*input[j];
                }
                Neurons[i].Weights[i] = 0;
            }
        }
        
        public void Forget(double[] input) 
        {
            for (int i = 0; i < Size; i++) 
            {
                for (int j = 0; j < Neurons[i].Weights.Length; j++) 
                {
                    Neurons[i].Weights[j] -= forgetRatio*input[i]*input[j];
                }
            }
        }
        
        public double ForgetRatio 
        {
            get { return forgetRatio; }
        }
        
        public NetworkLayer Neurons 
        {
            get { return layer; }
        }
        
        public int Size 
        {
            get { return layer.Size; }
        }
        
        public int NeuronInputDimension 
        {
            get { return layer.NeuronInputDimension; }
        }
        
        public double[] FireSignal(double[] args) 
        {
            double[] current = args;
            double[] signal = layer.FireSignal(current);
            while (!current.EqualsElementwise(signal)) 
            {
                current = signal;
                signal = layer.FireSignal(current);
            }
            return current;
        }
        
        private void MemorizePreviousSignal(double[] input) 
        {
            double[] result = FireSignal(input);
            for (int i = 0; i < result.Length; i++) 
            {
                ((MemoryNeuron)Neurons[i]).PreviousSignal = result[i];
            }
        }
    }
}
