using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong_4ITB_23_24
{
    public partial class Game : UserControl
    {
        Player player1;
        Player player2;
        Ball ball;

        public Game() {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public void SetupPlayers(string p1Name, string p2Name, float speed)
        {
            player1 = new Player(true, p1Name, speed, Color.Red, new List<Keys>() { Keys.W, Keys.S }, Width, Height);
            player2 = new Player(false, p2Name, speed, Color.Blue, new List<Keys>() { Keys.I, Keys.K }, Width, Height);
        }

        public void SetupGame(float ballSpeed)
        {
            ball = new Ball(Width, Height, ballSpeed);
        }

        private void Game_KeyDown(object sender, KeyEventArgs e) {
            if(e.KeyCode == Keys.Space && !updateTimer.Enabled) { 
                updateTimer.Enabled = true;
            }
            if (!updateTimer.Enabled) return;

            if(player1.Keys.Contains(e.KeyCode))
            {
                if (player1.Keys.IndexOf(e.KeyCode) == 0)
                    player1.SetDirection(-1);
                else
                    player1.SetDirection(1);
            }

            if (player2.Keys.Contains(e.KeyCode))
            {
                if (player2.Keys.IndexOf(e.KeyCode) == 0)
                    player2.SetDirection(-1);
                else
                    player2.SetDirection(1);
            }
        }

        private void Game_KeyUp(object sender, KeyEventArgs e) {
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            DoMovement();
            CheckCollisions();
            Refresh();
        }

        private void CheckCollisions() {

            CheckWallCollisions();
            if(ball.FlyingLeft())
                CheckCollisionsWithPlayer(player1);
            else
                CheckCollisionsWithPlayer(player2);
        }

        private void CheckCollisionsWithPlayer(Player player)
        {
            if (player.CollidesWith(ball))
            {
                double newAngle = Remap(ball.LeftPoint.Y, player.PosY - Player.Height / 2, player.PosY + Player.Height / 2,
                    -70, 70);

                ball.ChangeAngle(newAngle);
                // výpočet směru podle playera
            }
        }

        private double Remap(double value, double from1, double to1, double from2, double to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        private void CheckWallCollisions()
        {
            if(ball.TopPoint.Y < 0 || ball.BottomPoint.Y > Height)
            {
                ball.ChangeAngle(360 - ball.Angle);
            } 
        }

        private void DoMovement() {
            player1.Update();
            player2.Update();
            ball.Update();
        }

        private void Game_Paint(object sender, PaintEventArgs e)
        {
            player1.Draw(e.Graphics);
            player2.Draw(e.Graphics);
            ball.Draw(e.Graphics);
        }
    }
}
