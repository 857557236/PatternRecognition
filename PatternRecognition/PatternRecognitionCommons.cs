using System;
using System.Drawing;

namespace PatternRecognition
{
    public static class PatternRecognitionCommons
    {
        public static readonly int 
            PATTERN_WIDTH = 5,
            PATTERN_HEIGHT = 7;
            
        public static readonly Color
            BACK_COLOR = Color.White,
            PATTERN_COLOR = Color.Red;
            
        public static readonly int
            ONE_LAYER_NETWORK_DIM = 6,        
            NEURONS_DIM = PATTERN_WIDTH*PATTERN_HEIGHT,
            FIRST_LAYER_DIM = 4,
            SECOND_LAYER_DIM = 3;
        
        public static readonly string
            DICTIONARY_FILE_NAME = "patterns.dict";
        
        public static readonly Size 
            PATTERN_LABEL_SIZE = new Size(25, 25);
        
        public static readonly double
            TEACHING_RATIO = 0.5;
    }
}
