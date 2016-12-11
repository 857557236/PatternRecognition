using System;
using System.Windows.Forms;
using System.Collections.Generic;

using Commons = PatternRecognition.PatternRecognitionCommons;

namespace PatternRecognition.UI
{
    public static class UIExtensions
    {
        public static void LoadPattern(this LabelTable labelTable, double[] pattern)
        {
            int rows = labelTable.RowsCount, columns = labelTable.ColumnsCount;
            if (pattern.Length != rows*columns)
                throw new ArgumentException("Pattern not loaded - misaligned dimensions.");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    double val = pattern[i*columns+j];
                    labelTable[i, j].BackColor = (val == 1.0) ? Commons.PATTERN_COLOR : Commons.BACK_COLOR;
                }
            }
        }
    }
}
