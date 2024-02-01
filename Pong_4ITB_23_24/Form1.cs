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
    public partial class Form1 : Form
    {
        private float ballSpeed;
        private float playerSpeed;

        private const int POINTS_TO_WIN = 3;

        public Form1(List<string> names, float ballSpeed, float playerSpeed) {
            InitializeComponent();
            this.ballSpeed = ballSpeed;
            this.playerSpeed = playerSpeed;

            label1.Text = names.ElementAt(0);
            label2.Text = names.ElementAt(1);
            label3.Text = "0:0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            game1.SetupPlayers(label1.Text, label2.Text, playerSpeed);
            game1.SetupGame(ballSpeed);
            game1.RoundStarted += OnRoundStarted;
            game1.RoundEnded += OnRoundEnded;
        }

        private void OnRoundEnded(Player player)
        {
            label4.Visible = true;
            label3.Text = $"{game1.player1.Score}:{game1.player2.Score}";

            if(player.Score == POINTS_TO_WIN)
            {
                game1.Dispose();
                var res = MessageBox.Show(player.Name + " vyhrál. Chcete hrát znovu?",
                    "VÝHRA", MessageBoxButtons.YesNo);
                if(res == DialogResult.Yes) {
                    Application.Restart();
                } else
                {
                    Application.Exit();
                }
            }
        }

        private void OnRoundStarted()
        {
            label4.Visible = false;
        }
    }
}
