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
    }
}
