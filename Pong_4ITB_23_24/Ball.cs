﻿using System;
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
        private Brush color = new SolidBrush(Color.Black);

        double x, y;

        private int gameWidth;
        private int gameHeight;

        private double speed;
        private double angle;
        private int size;

        private Random random = new Random();

        public Ball(int gameWidth, int gameHeight, double speed)
        {
            this.gameWidth = gameWidth;
            this.gameHeight = gameHeight;
            this.speed = speed;

            size = 60;
            angle = random.Next(20,40);
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

        internal bool FlyingLeft()
        {
            throw new NotImplementedException();
        }
    }
}
