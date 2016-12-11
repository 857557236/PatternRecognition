using System;

using PatternRecognition.Tools;

namespace PatternRecognition.NeuralNetworks.Teaching
{
    public class TeachingPair : IEquatable<TeachingPair>
    {
        private const string WRONG_INPUT_FIELD_VALUE_MSG = "Null or zero-length array are not allowed for the value of Input";
        
        private double[] input;
        private double output;
        
        public TeachingPair(double[] input, double output) 
        {
            Input = input;
            this.output = output;
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
        
        public double Output 
        {
            get { return output; }
        }
        
        public override bool Equals(object obj)
        {
            if (obj == null) 
            {
                return false;
            }
            if (!(obj is TeachingPair)) 
            {
                return false;
            }
            TeachingPair other = obj as TeachingPair;
            return this.Equals(other);
        }
        
        public bool Equals(TeachingPair other) 
        {
            if (other == null) 
            {
                return false;
            }
            return this.input.EqualsElementwise(other.input) && this.output == other.output;
        }
        
        public override int GetHashCode()
        {
            int prime = 31;
            int result = 1;
            result = prime*result + (input == null ? 0 : input.GetHashCode());
            result = prime*result + output.GetHashCode();
            return result;
        }
        
        public static bool operator==(TeachingPair left, TeachingPair right)
        {
            return left.Equals(right);
        }
    
        public static bool operator!=(TeachingPair left, TeachingPair right)
        {
            return !left.Equals(right);
        }        
        
        public override string ToString()
        {
            return string.Format("[TeachingPair Input={0}, Output={1}]", input.GetContentsString(), output);
        }
    }
}
