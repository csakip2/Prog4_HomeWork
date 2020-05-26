using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    class PongLogic
    {
        PongModel model;
        public enum Direction { Left, Right }
        public event EventHandler RefreshScreen; // instead of NotifyPropertyChanged

        public static Random rnd = new Random();

        public PongLogic(PongModel model)
        {
            this.model = model;
        }

        public void MovePad(Direction d)
        {
            if (d == Direction.Left)
            {
                model.Pad.ChangeX(-10);
            }
            else
            {
                model.Pad.ChangeX(10);
            }
            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        public void JumpPad(double x)
        {
            model.Pad.SetXY(x, model.Pad.Area.Y);
            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        private bool MoveShape(MyShape shape)
        {
            bool faulted = false;
            shape.ChangeX(shape.Dx);
            shape.ChangeY(shape.Dy);

            if (shape.Area.Left < 0 || shape.Area.Right > Config.Width)
            {
                shape.Dx = -shape.Dx;
            }

            if (shape.Area.Top < 0 || shape.Area.IntersectsWith(model.Pad.Area))
            {
                shape.Dy = -shape.Dy;
            }
            if (shape.Area.Bottom > Config.Height)
            {
                shape.SetXY(shape.Area.X, Config.Height / 2);
                faulted = true;
            }

            RefreshScreen?.Invoke(this, EventArgs.Empty);
            return faulted;
        }

        public void MoveBall()
        {
            if (MoveShape(model.Ball)) model.Errors++;
            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        public void AddStar() // Phase 2
        {
            model.Stars.Add(new Star(Config.Width / 2, Config.Height / 2, 10, 10));
            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }
        public void MoveStars() // Phase 2
        {
            foreach (Star star in model.Stars)
            {
                if (MoveShape(star)) model.Errors++;
            }
            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

        private void MoveEnemy(Enemy enemy)
        { 
            int dir = rnd.Next(20);

            enemy.ChangeX(enemy.Dx);
            enemy.ChangeY(enemy.Dy);

            switch (dir)
            {
                case 0:
                    enemy.Dx = -enemy.Dx;
                    break;
                case 1:
                    enemy.Dy = enemy.Dy;
                    break;
            }

            if (enemy.Area.Left < 0 || enemy.Area.Right > Config.Width)
            {
                enemy.Dx = -enemy.Dx;
            }

            if (enemy.Area.Top < 0 || enemy.Area.IntersectsWith(model.Pad.Area) || enemy.Area.Bottom > Config.Height)
            {
                enemy.Dy = -enemy.Dy;
            }

            if (enemy.Area.IntersectsWith(model.Ball.Area))
            {
                enemy.Dead = true;
            }
        }

        public void MoveEnemies()
        {
            for (int i = 0; i < 3; i++)
            {          
                if (model.Enemies[i].Dead == false)
                {
                    MoveEnemy(model.Enemies[i]);
                }
                else
                {
                    model.Enemies[i] = new Enemy(Config.Width / 2, 10, Config.EnemySize, Config.EnemySize);
                }
            }
            RefreshScreen?.Invoke(this, EventArgs.Empty);
        }

    }
}
