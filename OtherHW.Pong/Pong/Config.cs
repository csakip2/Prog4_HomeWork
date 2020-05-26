using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Pong
{
    public static class Config
    {
        public static double Width = 700;
        public static double Height = 300;
        public static int BorderSize = 4;
        public static Brush BorderColor = Brushes.DarkGray;
        public static Brush BgColor = Brushes.Cyan;

        public static Brush BallBg = Brushes.Yellow;
        public static Brush BallLine = Brushes.Red;
        public static Brush PadBg = Brushes.Brown;
        public static Brush PadLine = Brushes.Black;
        public static Brush EnemyBg = Brushes.Blue;
        public static Brush EnemyLine = Brushes.Black;

        public static int BallSize = 20;
        public static int PadWidth = 100;
        public static int PadHeight = 20;
        public static int EnemySize = 20;
    }
}
