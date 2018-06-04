using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Drawing;

namespace U4DonkeyKong
{
    class Barrel
    {
        DispatcherTimer GameTimer = new DispatcherTimer();
        Window window;
        Canvas canvas;
        int y_vel;
        Point point = new Point(0, 0);
        public Barrel(Window w, Canvas c)
        {
            window = w;
            canvas = c;
        }
        public void barrelmove()
        {
            point.X += 10;
            
        }
        public void update(Ellipse barrel)
        {
            Canvas.SetLeft(barrel, point.X);
            Canvas.SetTop(barrel, point.Y);
        }

        public Ellipse generate(Ellipse barrel)
        {
            barrel.Height = 25;
            barrel.Width = 25;
            barrel.Fill = Brushes.Aqua;
            Canvas.SetLeft(barrel, 50);
            Canvas.SetTop(barrel, 50);
            return barrel;
        }
        public void move()
        {
            if (point.X <= 800 & point.X >= 650)
            {
                Console.WriteLine(point.Y);
                if (point.Y < 100)
                {
                    y_vel += 3;
                    Console.WriteLine("sector 1");

                }
                if (point.Y > 100 & point.Y < 150)
                {
                    point.Y = 100;
                    y_vel = 0;
                }
            }
            if (point.X <= 150 & point.X >= 0 & point.Y >= 100 & point.Y <= 300)
            {
                Console.WriteLine(point.Y);
                if (point.Y < 200)
                {

                    y_vel += 3;
                    Console.WriteLine("sector 2");
                }

                if (point.Y > 200)
                {
                    point.Y = 200;
                    y_vel = 0;
                }
            }
            if (point.X <= 800 & point.X >= 650 & point.Y >= 170 & point.Y <= 400)
            {
                Console.WriteLine(point.Y);
                if (point.Y < 350)
                {
                    Console.WriteLine("sector 3");
                    y_vel += 3;
                }
                if (point.Y > 350)
                {
                    point.Y = 350;
                    y_vel = 0;
                }
            }
            if (point.X <= 150 & point.X >= 0 & point.Y >= 350 & point.Y <= 500)
            {
                Console.WriteLine(point.Y);
                if (point.Y < 450)
                {
                    Console.WriteLine("sector 3");
                    y_vel += 3;
                }

                if (point.Y > 450)
                {
                    point.Y = 450;
                    y_vel = 0;
                }

            }
            if (point.X <= 800 & point.X >= 650 & point.Y >= 400)
            {
                if (point.Y < 600)
                {
                    y_vel += 3;
                }
                if (point.Y > 600)
                {
                    point.Y = 600;
                    y_vel = 0;
                }
            }
            point.Y += y_vel;
        }
    }
}
