using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pong
{
    class MyShape
    {
        Rect area;
        public Rect Area
        {
            get { return area; } // NO! get;
        }

        public int Dx { get; set; }
        public int Dy { get; set; }

        public MyShape(double x, double y, double w, double h)
        {
            area = new Rect(x, y, w, h);
            Dx = 5;
            Dy = 5;
        }
        public void ChangeX(double diff)
        {
            // Area.X += diff; // Not a variable!
            // Area = new Rect(Area.X+diff, xxxx) // Slow!
            area.X += diff;
        }
        public void ChangeY(double diff)
        {
            area.Y += diff;
        }
        public void SetXY(double x, double y)
        {
            area.X = x;
            area.Y = y;
        }
    }
}
