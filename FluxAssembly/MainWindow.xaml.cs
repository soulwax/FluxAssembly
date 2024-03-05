using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace FluxAssembly
{
    public partial class MainWindow : Window
    {
        private int frameCounter;
        private DateTime lastTime;

        public MainWindow()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            this.Background = Brushes.Black;  // Setting up a black background

            lastTime = DateTime.Now; // Save the current time when the game starts.

            DispatcherTimer updateTimer = new DispatcherTimer();
            updateTimer.Tick += Update;
            updateTimer.Interval = TimeSpan.FromMilliseconds(1000 / 60);    // Logic update at 60 FPS
            updateTimer.Start();

            DispatcherTimer renderTimer = new DispatcherTimer();
            renderTimer.Tick += Render;
            renderTimer.Interval = TimeSpan.FromMilliseconds(1000 / 60);   // Rendering at 60 FPS
            renderTimer.Start();

            DispatcherTimer fpstimer = new DispatcherTimer();
            fpstimer.Tick += PrintFPS;
            fpstimer.Interval = TimeSpan.FromMilliseconds(1000);   // Print FPS every second
            fpstimer.Start();
        }

        private void Update(object sender, EventArgs e)
        {
            // update game state here
            // You can call your game engine's update function(s) here.
        }

        private void Render(object sender, EventArgs e)
        {
            // render game here
            // You can call your game engine's render function(s) here.
            
            frameCounter++;   // Increase frame counter each time a frame is rendered
        }

        private void PrintFPS(object sender, EventArgs e)
        {
            // Print the number of frames rendered in the last second
            Console.WriteLine($"FPS: {frameCounter}");

            // Reset counter and timestamp
            frameCounter = 0;
        }
    }
}