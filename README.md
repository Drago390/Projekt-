Form 1.cs
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        Random randPlansza = new Random();
        Graphics paper;
        Snake snake = new Snake();
        Plansza plansza;

        bool left = false;
        bool right = false;
        bool up = false;
        bool down = false;

        int score = 0;

        public Form1()
        {
            InitializeComponent();
            plansza = new Plansza(randPlansza);

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //wprowadzenia grafiki weża do gry.
            paper = e.Graphics;
            plansza.rysowanie(paper);
            snake.drawSnake(paper);

            for (int i = 0; i < snake.SnakeRec.Length; i++)
            {
                if (snake.SnakeRec[i].IntersectsWith(plansza.pRec))
                {
                    plansza.Miejsce(randPlansza);
                }
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                timer1.Enabled = true;
                SpaceBar.Text = " ";
                down = false;
                up = false;
                right = true;
                down = false;
            }
            if (e.KeyData == Keys.Down && up == false)
            {
                down = true;
                up = false;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Up && down == false)
            {
                down = false;
                up = true;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Right && left == false)
            {
                down = false;
                up = false;
                right = true;
                left = false;
            }
            if (e.KeyData == Keys.Left && right == false)
            {
                down = false;
                up = false;
                right = false;
                left = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            snakeScore.Text = Convert.ToString(score);
            if (down) { snake.moveDown(); }
            if (up) { snake.moveUp(); }
            if (right) { snake.moveRight(); }
            if (left) { snake.moveLeft(); }
            for (int i = 0; i < snake.SnakeRec.Length; i++)
            {
                if (snake.SnakeRec[i].IntersectsWith(plansza.pRec))
                {
                    score += 1;
                    snake.growSnake();
                    plansza.Miejsce(randPlansza);
                }
            }
            collision();

            this.Invalidate();
        }
        public void collision()
        {
            for (int i = 2; i < snake.SnakeRec.Length; i++)
            {
               if (snake.SnakeRec[0].IntersectsWith(snake.SnakeRec[i]))
                {
                    restart();
                }
            }
            if(snake.SnakeRec[0].X < 0 || snake.SnakeRec[0].X > 335)
            {
                restart();
            }
            if (snake.SnakeRec[0].Y < 0 || snake.SnakeRec[0].Y > 385)
            {
                restart();
            }

        }

        public void restart()
        {
            timer1.Enabled = false;
            MessageBox.Show("Snake wziął i umarł");
            snakeScore.Text = "0";
            score = 0;
            SpaceBar.Text = "Nacisnij spacje";
            snake = new Snake();
            
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
