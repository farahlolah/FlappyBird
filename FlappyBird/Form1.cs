using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 0;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimer(object sender, EventArgs e)
        {
            flappy.Top += gravity; // .Top detects when the picture box reaches the top of the window, += pushes the bird down when it reaches the top
            pipeTop.Left -= pipeSpeed; //.Left detects the left corner of the picture box, -= pushes the pipe to the left
            pipeBottom.Left -= pipeSpeed;
            scoreLabel.Text = "Score: " + score; // scoreLabel.Text allows you to change the text thats initially assigned to the label

            if (pipeTop.Left < -150) // if the left point of the picture box is at the -50 margin on the window
            {
                pipeTop.Left = 1050; // reassigns the left point of the picture box to 150 which is the width it initially was at 
                score++;
            }
            if (pipeBottom.Left < -120)
            {
                pipeBottom.Left = 1930;
                score++;
            }
            if (flappy.Bounds.IntersectsWith(pipeBottom.Bounds) || 
                flappy.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappy.Bounds.IntersectsWith(ground.Bounds) ||
                flappy.Top <-25) // .Bounds specifies the outer boundaries of the picture box specified before it, .IntersectsWith() monitors if it meets whatevers specified in the brackets
            {
                endGame();
            }

            if (score > 5)
            {
                pipeSpeed = 12;
            }
        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Space) // e.KeyCode detects when a certain key is pressed, Keys.Space tells the compiler that the space key is the one to be detected
            {
                gravity = -5;
            }
        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 5;
            }
        }

        private void endGame()
        {
            timer1.Stop();
            scoreLabel.Text += " Game Over!"; // += adds it to the end of the text thats already there
        }
    }
}
