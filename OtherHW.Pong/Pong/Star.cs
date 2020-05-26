using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Pong
{
    class Star : MyShape
    {
        double n;
        double r;
        public Star(double x, double y, double r, double n)
            : base(x, y, 2 * r, 2 * r)
        {
            this.n = n;
            this.r = r;
        }

        public Geometry GetGeometry()
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < n; i++)
            {
                double angle = i * 2 * Math.PI / n;
                Point P = new Point(r * Math.Cos(angle), r * Math.Sin(angle));
                if (i % 2 == 1)
                {
                    P.X *= 0.2;
                    P.Y *= 0.2;
                }
                P.X += r + Area.X;
                P.Y += r + Area.Y;

                points.Add(P);
            }

            StreamGeometry streamGeometry = new StreamGeometry();
            using (StreamGeometryContext geometryContext = streamGeometry.Open())
            {
                geometryContext.BeginFigure(points[0], true, true);
                geometryContext.PolyLineTo(points, true, true);
            }

            return streamGeometry;
        }
    }
}
