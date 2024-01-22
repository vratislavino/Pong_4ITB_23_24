using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong_4ITB_23_24
{
    public class Player : IDrawable, IMoveable
    {
        private string name;
        private int score;

        private float speed;
        private float posX;
        private float posY;
        private float currentMovement = 0;

        private static int width = 40;
        private static int height = 200;
        private SolidBrush color;

        private List<Keys> controlKeys;
        public List<Keys> Keys => controlKeys;

        private int gameWidth;
        private int gameHeight;

        public Player(bool isLeft, string name, float speed, Color color, List<Keys> controlKeys, int gameWidth, int gameHeight) {
            this.name = name;
            this.score = 0;
            this.speed = speed;

            this.color = new SolidBrush(color);
            this.controlKeys = controlKeys;
            this.gameWidth = gameWidth;
            this.gameHeight = gameHeight;

            this.posX = isLeft ? 40 : gameWidth - 40 - width;
            this.posY = gameHeight / 2;
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(color, posX, posY - height / 2, width, height);
        }

        public void SetDirection(float dir)
        {
            currentMovement = dir;
        }

        public void Update()
        {
            float newY = posY + currentMovement * speed;

            if (newY - height / 2 > 0 && newY + height / 2 < gameHeight)
                posY = newY;
        }

        internal bool CollidesWith(Ball ball)
        {
            // Check kolize - jen jeden bod na míčku levý/pravý
            return false;
        }
    }
}
