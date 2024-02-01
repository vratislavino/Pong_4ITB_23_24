using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Pong_4ITB_23_24
{
    public class Ball : IDrawable, IMoveable
    {
        public event Action<bool> BallLost;

        private Brush color = new SolidBrush(Color.Black);

        double x, y;

        public Point TopPoint => new Point((int)x, (int)(y - size / 2));
        public Point BottomPoint => new Point((int)x, (int)(y + size / 2));
        public Point LeftPoint => new Point((int)(x - size / 2), (int)y);
        public Point RightPoint => new Point((int)(x + size / 2), (int)y);

        private int gameWidth;
        private int gameHeight;

        private double speed;
        private double angle;
        public double Angle => angle;
        private int size;

        private Random random = new Random();

        public Ball(int gameWidth, int gameHeight, double speed)
        {
            this.gameWidth = gameWidth;
            this.gameHeight = gameHeight;
            size = 60;
            this.speed = speed;

        }

        public void Reset()
        {
            angle = random.Next(20, 40);
            angle *= (random.Next(2) == 1 ? -1 : 1);
            angle += (random.Next(2) == 1 ? 180 : 0);

            x = gameWidth / 2;
            y = gameHeight / 2;
        }

        public void Draw(Graphics g)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.FillEllipse(color, (int)(x - size / 2), (int)(y - size / 2), size, size);
        }

        public void Update()
        {
            double dx, dy;
            double angleRad = angle * (Math.PI / 180);
            dx = speed * Math.Cos(angleRad);
            dy = speed * Math.Sin(angleRad);

            x += dx;
            y += dy;
        }

        public void ChangeAngle(double newAngle)
        {
            angle = newAngle;
        }

        internal void CheckWin()
        {
            if(LeftPoint.X < 0)
            {
                BallLost?.Invoke(true);
                return;
            }

            if(RightPoint.X > gameWidth) {
                BallLost?.Invoke(false);
                return;
            }
        }
    }
}
