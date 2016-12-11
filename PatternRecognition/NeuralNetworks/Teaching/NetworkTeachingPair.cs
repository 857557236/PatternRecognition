using System;
using System.Collections.Generic;

using System.Linq;

using PatternRecognition.NeuralNetworks.Neurons;
using PatternRecognition.Tools;

namespace PatternRecognition.NeuralNetworks.Teaching
{
    public class NetworkTeachingPair : IEquatable<NetworkTeachingPair>
    {    
        private const string WRONG_INPUT_FIELD_VALUE_MSG = "Null or zero-length array are not allowed for the value of Input";
        private const string WRONG_OUTPUT_FIELD_VALUE_MSG = "Null or zero-length array are not allowed for the value of Output";
        
        private const int FIRST_OUTPUT = 0;
        
        private double[] input;
        private double[] output;
        
        public NetworkTeachingPair(double[] input, double[] output) 
        {
            Input = input;
            Output = output;
        }
        
        public double[] Input
        {
            get { return input; }
            private set 
            {
                if (value == null || value.Length == 0) 
                {
                    throw new ArgumentException(WRONG_INPUT_FIELD_VALUE_MSG);
                }
                input = value;
            }
        }
        
        public double[] Output 
        {
            get { return output; }
            private set 
            {
                if (value == null || value.Length == 0) 
                {
                    throw new ArgumentException(WRONG_OUTPUT_FIELD_VALUE_MSG);
                }
                output = value;
            }
        }
        
        public IList<TeachingPair> DecomposeToTeachingPairs() 
        {
            IList<TeachingPair> result = new List<TeachingPair>();
            foreach (double expectedOutput in output) 
            {
                result.Add(new TeachingPair(input, expectedOutput));
            }
            return result;            
        }
        
        public static NetworkTeachingPair ComposeOf(IList<TeachingPair> teachingPairs) 
        {
            if (teachingPairs == null)
                return null;
            int pairCount = teachingPairs.Count;
            if (pairCount == 0)
                return null;
            double[] output = new double[pairCount];
            for (int i = 0; i < pairCount; i++)
            {
                output[i] = teachingPairs[i].Output;
            }            
            return new NetworkTeachingPair(teachingPairs.First().Input, output);
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null) 
            {
                return false;
            }
            if (!(obj is NetworkTeachingPair))
            {
                return false;
            }
            NetworkTeachingPair other = obj as NetworkTeachingPair;
            return this.Equals(other);
        }
        
        public bool Equals(NetworkTeachingPair other) {
            if (other == null) 
            {
                return false;
            }
            return this.input.EqualsElementwise(other.input) &&
                   this.output.EqualsElementwise(other.output);
        }
        
        public override int GetHashCode()
        {
            int prime = 31;
            int result = 1;
            result = prime*result + (input == null ? 0 : input.GetHashCode());
            result = prime*result + (output == null ? 0 : output.GetHashCode());
            return result;
        }
        
        public static bool operator==(NetworkTeachingPair left, NetworkTeachingPair right)
        {
            return left.Equals(right);
        }
        
        public static bool operator!=(NetworkTeachingPair left, NetworkTeachingPair right)
        {
            return !left.Equals(right);
        }
        
        public override string ToString()
        {
            return string.Format("[LayerTeachingPair:\nInput = {0}\nOutput = {1}]", input.GetContentsString(), output.GetContentsString());
        }
    }
}
