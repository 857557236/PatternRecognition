using System;
using System.Collections.Generic;

using System.Linq;

using PatternRecognition.Tools;
using PatternRecognition.NeuralNetworks.Teaching;

namespace PatternRecognition.NeuralNetworks.Networks
{
    public class MultiLayerNetwork
    {
        private const string EMPTY_NETWORK_MSG = "Empty or null collection of layers is not allowed.",
                             MISALIGNED_LAYERS_MSG = "Layers have non-matching dimensions, cannot be wrapped in a neural network";
        
        private IList<NetworkLayer> layers;
        private int inputDim;
        
        public static MultiLayerNetwork Of(IList<NetworkLayer> layers) 
        {
            if (layers == null || layers.Count < 1) 
            {
                throw new ArgumentException(EMPTY_NETWORK_MSG);
            }
            if (!AreOfConsistentDimension(layers)) 
            {
                throw new ArgumentException(MISALIGNED_LAYERS_MSG);
            }
            MultiLayerNetwork network = new MultiLayerNetwork();
            network.layers = layers;
            network.InputDimension = layers.First().NeuronInputDimension;
            return network;
        }
        
        public void SetRandomWeights()
        {
            foreach (NetworkLayer layer in layers)
            {
                layer.SetRandomWeights();
            }
        }
        
        public int InputDimension
        {
            get { return inputDim; }
            private set { inputDim = value; }
        }
        
        public int Size
        {
            get { return layers.Count; }
        }
        
        public NetworkLayer this[int idx]
        {
            get { return layers[idx]; }
        }
        
        public double[] FireSignal(params double[] args) 
        {
            return FireSignalOfLayer(Size-1, args);
        }
        
        public double[] FireSignalOfLayer(int layerIdx, params double[] args)
        {
            if (layerIdx < 0 && layerIdx > Size - 1)
                throw new ArgumentException(string.Format("Layer index out of range: [0, {0}]", Size));
            double[] signal = args;
            for (int i = 0; i <= layerIdx; i++)
            {
                signal = layers[i].FireSignal(signal);
            }
            return signal;
        }
        
        /// <summary>
        /// Back-propagation teaching method
        /// </summary>        
        public void Teach(NetworkTeachingPair pair, double speedRatio, double ratio)
        {
            double[] actualSignal = FireSignal(pair.Input);
            double[] expectedSignal = pair.Output;
            
            int len = expectedSignal.Length;
            double[] errors = new double[len];
            for (int i = 0; i < len; i++)
            {
                double oi = actualSignal[i], ti = expectedSignal[i];
                errors[i] = -oi*(1-oi)*(ti-oi);
            }
            for (int i = Size - 2; i >= 0; i--)
            {
                //double[] signal = FireSignal(
                
            }
        }
        
        private static bool AreOfConsistentDimension(IList<NetworkLayer> layers) 
        {            
            for (int i = 1; i < layers.Count; i++)
            {
                if (layers[i].NeuronInputDimension != layers[i-1].Size)
                {
                    return false;
                }
            }
            return true;
        }
        
        private MultiLayerNetwork()
        {
        }
    }
}
