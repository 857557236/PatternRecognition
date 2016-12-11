using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace PatternRecognition.UI
{    
    public class LabelTable : Panel
    {
        private int rows = 0, 
                    columns = 0;
        
        public LabelTable() 
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                          ControlStyles.UserPaint | 
                          ControlStyles.OptimizedDoubleBuffer | 
                          ControlStyles.ResizeRedraw, true
            );
        }
    
        public LabelTable(int rows, int columns, Size labelSize, Color backColor)
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | 
                          ControlStyles.UserPaint | 
                          ControlStyles.OptimizedDoubleBuffer | 
                          ControlStyles.ResizeRedraw, true
            );
            
            this.rows = rows;
            this.columns = columns;
            int dx = labelSize.Width;
            int dy = labelSize.Height;            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Point location = new Point(dx*j, dy*i);
                    Label label = CreateLabel(labelSize, backColor, location);                
                    this.Controls.Add(label);
                }
            }
            this.Size = new Size(dx*columns, dy*rows);
        }
        
        public IList<Label> Labels
        {
            get
            {
                IList<Label> labels = new List<Label>();
                foreach (Control control in Controls)
                {
                    labels.Add(control as Label);
                }
                return labels;
            }
        }
        
        public Label this[int row, int column]
        {
            get
            {
                return this.Controls[row*this.columns + column] as Label;
            }
        }
        
        public int ColumnsCount
        {
            get
            {
                return columns;    
            }
        }
        
        public int RowsCount
        {
            get
            {
                return rows;    
            }
        }
        
        public void SetColor(Color color)
        {
            foreach (Control control in Controls)
            {
                control.BackColor = color;
            }
        }
        
        public void Clear()
        {
            foreach (Control control in Controls)
            {
                control.BackColor = Color.White;
            }
        }
        
        public void SetLabelMouseClickEventHandler(MouseEventHandler eventHandler)
        {
            foreach (Control control in Controls)
            {
                control.MouseClick += eventHandler;
            }
        }
        
        public Point GetPointByColor(Color color)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (this[i, j].BackColor == color) {
                        return new Point(j, i);
                    }
                }
            }
            return new Point(-1, -1);
        }
                
        public IList<Point> GetAllPointsByColor(Color color)
        {
            IList<Point> points = new List<Point>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (this[i, j].BackColor == color) {
                        points.Add(new Point(j, i));
                    }
                }
            }
            return points;
        }
        
        private static Label CreateLabel(Size size, Color backColor, Point location)
        {
            Label label = CreateLabel(size, backColor);
            label.Location = location;
            return label;
        }
        
        private static Label CreateLabel(Size size, Color backColor)
        {
            Label label = new Label();
            label.Size = size;
            label.BackColor = backColor;
            label.BorderStyle = BorderStyle.FixedSingle;
            return label;
        }
    }
}