using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace Pong
{
    class PongControl : FrameworkElement
    {
        PongModel model;
        PongLogic logic;
        PongRenderer renderer;
        DispatcherTimer tickTimer;

        public PongControl()
        {
            Loaded += GameScreen_Loaded; // += <TAB><RET>
            // PongControl ctrl = new PongControl();
            // someWindow.Content = ctrl; ... XAML
        }

        private void GameScreen_Loaded(object sender, RoutedEventArgs e)
        {
            model = new PongModel();
            logic = new PongLogic(model);
            renderer = new PongRenderer(model);

            Window win = Window.GetWindow(this);
            if (win != null) // if (!IsInDesignMode)
            {

                tickTimer = new DispatcherTimer();
                tickTimer.Interval = TimeSpan.FromMilliseconds(25);
                tickTimer.Tick += timer_Tick;
                tickTimer.Start();

                win.KeyDown += Win_KeyDown; // += <TAB><RET>
                MouseLeftButtonDown += PongControl_MouseLeftButtonDown; // += <TAB><RET>
                MouseMove += PongControl_MouseMove;
            }

            logic.RefreshScreen += (obj, args) => InvalidateVisual();
            InvalidateVisual();
        }

        private void PongControl_MouseMove(object sender, MouseEventArgs e)
        {
            logic.JumpPad(e.GetPosition(this).X);
        }

        private void PongControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            logic.JumpPad(e.GetPosition(this).X);
        }

        private void Win_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left: logic.MovePad(PongLogic.Direction.Left); break;
                case Key.Right: logic.MovePad(PongLogic.Direction.Right); break;
                case Key.Space: logic.AddStar(); break; // phase 2
            }
        }

        void timer_Tick(object sender, EventArgs e)
        {
            logic.MoveBall();
            logic.MoveStars(); // phase 2
            logic.MoveEnemies();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            if (renderer != null) renderer.DrawThings(drawingContext);
        }
    }
}
