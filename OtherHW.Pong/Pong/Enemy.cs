using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class Enemy : MyShape
    {
        public bool Dead { get; set; }
        public Enemy(double x, double y, double w, double h) : base(x, y, w, h)
        {
            Dead = false;
        }
    }
}
