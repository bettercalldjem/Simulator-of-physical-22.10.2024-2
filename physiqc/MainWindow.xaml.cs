using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace PhysicsSimulator
{
    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        private DispatcherTimer _timer;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new MainViewModel();
            DataContext = _viewModel;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(16);
            _timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _viewModel.Update(0.016);
            DrawObjects();
        }

        private void DrawObjects()
        {
            SimulationCanvas.Children.Clear();
            foreach (var obj in _viewModel.PhysicsEngine.Objects)
            {
                Ellipse ellipse = new Ellipse
                {
                    Fill = new SolidColorBrush(obj.Color),
                    Width = 20,
                    Height = 20
                };
                Canvas.SetLeft(ellipse, obj.Position.X);
                Canvas.SetTop(ellipse, obj.Position.Y);
                SimulationCanvas.Children.Add(ellipse);
            }
        }

        private void AddBall_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddObject(1.0, new Point(100, 100), new Vector(0, 0), Colors.Red);
        }

        private void AddSquare_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddObject(1.0, new Point(200, 100), new Vector(0, 0), Colors.Blue);
        }

        private void StartSimulation_Click(object sender, RoutedEventArgs e)
        {
            _timer.Start();
        }

        private void PauseSimulation_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
        }

        private void ResetSimulation_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.PhysicsEngine.Objects.Clear();
            SimulationCanvas.Children.Clear();
        }

        private void GravitySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _viewModel.Gravity = e.NewValue;
        }
    }
}
