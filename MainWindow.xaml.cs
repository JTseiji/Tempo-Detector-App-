using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tempo_Detector_2
{
    public partial class MainWindow : Window
    {
        //the time intervals in milliseconds between taps
        private readonly List<double> _tapIntervals = new List<double>();

        //the most recent tap 
        private DateTime _lastTapTime;

        //the number of recent taps including the rolling average
        private const int TapsToAverage = 4;

        public MainWindow()
        {
            InitializeComponent();
            ResetCalculation();
        }

        private void TapButton_Click(object sender, RoutedEventArgs e)
        {
            // now = the current time
            DateTime now = DateTime.Now;

            if (_lastTapTime != DateTime.MinValue)
            {
                //interval is the time between the last tap and the current tap
                double interval = (now - _lastTapTime).TotalMilliseconds;
                //adding that time to the list
                _tapIntervals.Add(interval);
            }

            //update the list of taps to grab the next calculation
            _lastTapTime = now;

            //keeping the list from growing indefinitely.  
            while (_tapIntervals.Count > TapsToAverage)
            {
                //removing the oldest interval from the front of the list
                _tapIntervals.RemoveAt(0);
            }

            //we need at least 1 interval (2 taps) to calculate a tempo
            if (_tapIntervals.Any())
            {
                //whatever is inside of the list, average it
                double averageInterval = _tapIntervals.Average();

                if (averageInterval > 0)
                {
                    // bpm = 60000 ms per minute / average interval time
                    double bpm = 60000 / averageInterval;

                    // display BPM value correctly
                    BPMTextBlock.Text = $"BPM: {bpm:F1}";

                    // Update the BPM text color based on tempo
                    UpdateBpmColor(bpm);
                }
            }
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            ResetCalculation();
        }

        private void ResetCalculation()
        {
            _tapIntervals.Clear();
            _lastTapTime = DateTime.MinValue;
            BPMTextBlock.Text = "Tap to start";
            BPMTextBlock.Foreground = new SolidColorBrush(Colors.White); // reset to default
        }

        // New method to update text color based on BPM
        private void UpdateBpmColor(double bpm)
        {
            //Range of bpm
            double minBpm = 60; //minimum bpm
            double maxBpm = 180; //maximum bpm

            //Clamp bpm to the range 
            if (bpm < minBpm)
            {
                bpm = minBpm;
            }
            else if (bpm > maxBpm)
            {
                bpm = maxBpm;
            }

            // Normalize between 0 and 1
            double t = (bpm - minBpm) / (maxBpm - minBpm);

            Color color;

            if (t < 0.5)
            {
                // Blend from Blue to Green
                double blend = t / 0.5;
                byte r = 0;
                byte g = (byte)(255 * blend);
                byte b = (byte)(255 * (1 - blend));
                color = Color.FromRgb(r, g, b);
            }
            else
            {
                // Blend from Green to Red 
                double blend = (t - 0.5) / 0.5;
                byte r = (byte)(255 * blend);
                byte g = (byte)(255 * (1 - blend));
                byte b = 0;
                color = Color.FromRgb(r, g, b);
            }

            BPMTextBlock.Foreground = new SolidColorBrush(color);
        }
    }
}