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

namespace DonkeyKong
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        enum GameState { Title, SplashScreen, GameOn, GameOver, WinScreen }
        GameState gameState;
        Player player;
        U4DonkeyKong.Barrel barrrel;
        Point mouse_pos = new Point();
        //ImageBrush brush = new ImageBrush(new BitmapImage(new Uri(@"E:/Donkey Kong/Donkey Kong/bin/Debug/Untitledbutcorners.png")));
        Rectangle player_sprite = new Rectangle();
        Ellipse barrel = new Ellipse();
        DispatcherTimer GameTimer = new DispatcherTimer();
        //BitmapImage bitmap = new BitmapImage(new Uri(@"E:/Donkey Kong/Donkey Kong/bin/Debug/Shane'sGreatestWork(SomeGarbargeMapOrWhatever).png"));

        int score = 0;
        int level = 1;
        int counter = 0;
        bool playerisgenerated = false;
        bool barrelisgenerated = false;

        public MainWindow()
        {

            InitializeComponent();

            Map map = new Map(canvas, this);
            gameState = GameState.SplashScreen;
            GameTimer.Tick += GameTimer_Tick;
            GameTimer.Interval = new TimeSpan(170000);
            GameTimer.Start();
            map.drawMap();
            player = new Player(this, canvas);
            barrrel = new U4DonkeyKong.Barrel(this, canvas);

        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {

            for (int i = canvas.Children.Count - 13; i >= 13; i--)
            {
                canvas.Children.RemoveAt(i);
            }
            if (gameState == GameState.Title)
            {
                this.Title = "Title Screen";
            }
            if (gameState == GameState.SplashScreen)
            {

                this.Title = "SplashScreen";
                counter++;

                if (playerisgenerated == false)
                {
                    player.generate(player_sprite);
                    canvas.Children.Add(player_sprite);
                    playerisgenerated = true;
                }
                if (playerisgenerated == true)
                {
                    player.fall();
                    player.update(player_sprite);
                }
                if (barrelisgenerated == false)
                {
                    barrrel.generate(barrel);
                    canvas.Children.Add(barrel);
                    barrelisgenerated = true;
                }
                if(barrelisgenerated == true)
                {
                    barrel.move();
                }


            }
            if (gameState == GameState.GameOn)
            {

            }
            if (gameState == GameState.GameOver)
            {

            }
            if (gameState == GameState.WinScreen)
            {

            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            //Console.WriteLine(".");
            player.move();
            player.jump();

        }

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show(e.GetPosition(canvas).ToString());
        }
    }
}
