using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class PongModel
    {
        public int Errors { get; set; }
        public MyShape Pad { get; set; }
        public MyShape Ball { get; set; }

        public List<Star> Stars { get; set; }  // Phase 2 - No time?

        public Enemy[] Enemies { get; set; }

        public PongModel()
        {
            Pad = new MyShape(Config.Width / 2, Config.Height - 20, 100, 20);
            Ball = new MyShape(Config.Width / 2, Config.Height / 2, 20, 20);
            Stars = new List<Star>(); // Phase 2

            Enemies = new Enemy[3];
            for (int i = 0; i < 3; i++)
            {
                Enemies[i] = new Enemy(Config.Width / 2, 10, Config.EnemySize, Config.EnemySize);
            }

        }
    }
}
