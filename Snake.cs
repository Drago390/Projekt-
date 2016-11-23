using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Snake
{
    public class Snake
    {
        private Rectangle[] snakeRec;
        private SolidBrush brush;
        private int x, y, width, height;


        public Rectangle[] SnakeRec
        {
            get { return snakeRec; }
        }
        public Snake()
        {
            //Rozmiar grafiki węża
            snakeRec = new Rectangle[2];
            brush = new SolidBrush(Color.Blue);
            x = 20;//dlugość węza
            y = 30; //odleglosc od gornej scianki
            width = 10;//ilosc zamalowanych pól
            height = 10;
            //Tworzenie węża
            for (int i = 0; i < snakeRec.Length; i++)
            {
                snakeRec[i] = new Rectangle(x, y, width, height);
                x -= 5;//ile kwadratów zamalować
            }
        }
        public void drawSnake(Graphics paper)
        {
            foreach (Rectangle rec in snakeRec)
            {
                paper.FillRectangle(brush, rec);
            }

        }
        public void drawSnake()
        {
            for (int i = snakeRec.Length - 1; i > 0; i--)
            {
                snakeRec[i] = snakeRec[i - 1];
            }
        }
        public void moveDown()
        {
            drawSnake();
            snakeRec[0].Y += 10;
        }
        public void moveUp()
        {
            drawSnake();
            snakeRec[0].Y -= 10;
        }
        public void moveLeft()
        {
            drawSnake();
            snakeRec[0].X -= 10;
        }
        public void moveRight()
        {
            drawSnake();
            snakeRec[0].X += 10;
        }

        public void growSnake()
        {
            List<Rectangle> rec = snakeRec.ToList();
            rec.Add(new Rectangle(snakeRec[snakeRec.Length - 1].X, snakeRec[snakeRec.Length - 1].Y, width, height));
            snakeRec = rec.ToArray();
        }

    }
}
