using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Snake
{
    public class Plansza
    {
        private int x, y, width, height;
        private SolidBrush brush;
        public Rectangle pRec;
        //Resp elementu do zbierania
        public Plansza(Random randPlansza)
        {
            
            x = randPlansza.Next(0, 20) * 10;
            y = randPlansza.Next(0, 29) * 10;

            brush = new SolidBrush(Color.Black);

            width = 10;
            height = 10;
            pRec = new Rectangle(x, y, width, height);

        }

        public void Miejsce(Random randPlansza)
        {
            x = randPlansza.Next(0, 20) * 10;
            y = randPlansza.Next(0, 29) * 10;
        }

        public void rysowanie(Graphics paper)
        {
            pRec.X = x;
            pRec.Y = y;
            paper.FillRectangle(brush, pRec);
        }
    }
}
