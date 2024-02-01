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
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private int score;
        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        private float speed;
        private float posX;
        private float posY;
        private float currentMovement = 0;

        private static int width = 40;
        private static int height = 200;
        private SolidBrush color;

        private List<Keys> controlKeys;
        public List<Keys> Keys => controlKeys;

        public float PosX { get => posX; set => posX = value; }
        public float PosY { get => posY; set => posY = value; }
        public static int Height { get => height; set => height = value; }

        private int gameWidth;
        private int gameHeight;

        private bool isLeft;

        public Player(bool isLeft, string name, float speed, Color color, List<Keys> controlKeys, int gameWidth, int gameHeight) {
            this.isLeft = isLeft;
            this.name = name;
            this.score = 0;
            this.speed = speed;

            this.color = new SolidBrush(color);
            this.controlKeys = controlKeys;
            this.gameWidth = gameWidth;
            this.gameHeight = gameHeight;

            this.PosX = isLeft ? 40 : gameWidth - 40 - width;
            this.PosY = gameHeight / 2;
        }

        public void Draw(Graphics g)
        {
            g.FillRectangle(color, PosX, PosY - Height / 2, width, Height);
        }

        public void SetDirection(float dir)
        {
            currentMovement = dir;
        }

        public void Update()
        {
            float newY = PosY + currentMovement * speed;

            if (newY - Height / 2 > 0 && newY + Height / 2 < gameHeight)
                PosY = newY;
        }

        public bool ContainsPoint(Point point)
        {
            Rectangle rect = new Rectangle((int)posX, (int)(posY - height / 2), width, height);
            return rect.Contains(point);
        }
    }
}
