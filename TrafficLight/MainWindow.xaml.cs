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

namespace TrafficLight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer;
        private bool isRedOn = false;
        private bool isOrangeOn = false;
        private bool isGreenOn = false;
        Ellipse red;
        Ellipse orange;
        Ellipse green;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(3000);
            timer.Tick += Timer_Tick;

            red = new Ellipse();
            red.Fill = Brushes.White;
            red.Width = 60;
            red.Height = 60;
            Canvas.SetLeft(red, 274);
            Canvas.SetTop(red, 60);
            lightCanvas.Children.Add(red);

            orange = new Ellipse();
            orange.Fill = Brushes.White;
            orange.Width = 60;
            orange.Height = 60;
            Canvas.SetLeft(orange, 274);
            Canvas.SetTop(orange, 130);
            lightCanvas.Children.Add(orange);

            green = new Ellipse();
            green.Fill = Brushes.White;
            green.Width = 60;
            green.Height = 60;
            Canvas.SetLeft(green, 274);
            Canvas.SetTop(green, 200);
            lightCanvas.Children.Add(green);

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (isRedOn == false && isOrangeOn == false && isGreenOn == true)
            {
                isRedOn = false;
                isOrangeOn = false;
                isGreenOn = false;
                red.Fill = Brushes.White;
                orange.Fill = Brushes.White;
                green.Fill = Brushes.White;

            }
            if (isRedOn == false && isOrangeOn == false && isGreenOn == false)
            {
                red.Fill = Brushes.Red;
                isRedOn = true;

            }
            else if (isRedOn == true && isOrangeOn == false && isGreenOn == false)
            {
                red.Fill = Brushes.White;
                orange.Fill = Brushes.Orange;
                green.Fill = Brushes.White;
                isRedOn = false;
                isOrangeOn = true;
                isGreenOn = false;

            }
            else if (isRedOn == false && isOrangeOn == true && isGreenOn == false)
            {
                red.Fill = Brushes.White;
                orange.Fill = Brushes.White;
                green.Fill = Brushes.Green;
                isRedOn = false;
                isOrangeOn = false;
                isGreenOn = true;
            }
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }
    }
}
