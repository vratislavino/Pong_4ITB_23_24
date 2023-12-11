using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong_4ITB_23_24
{
    public class Player
    {
        private string name;
        private int score;

        private float speed;
        private float posX;
        private float posY;

        private static int width = 40;
        private static int height = 200;
        private SolidBrush color;

        private List<Keys> controlKeys;

        private int gameWidth;
        private int gameHeight;

        public Player(string name, float speed, Color color, List<Keys> controlKeys, int gameWidth, int gameHeight) {
            this.name = name;
            this.score = 0;
            this.speed = speed;

            this.color = new SolidBrush(color);
            this.controlKeys = controlKeys;
            this.gameWidth = gameWidth;
            this.gameHeight = gameHeight;
        }
    }
}
