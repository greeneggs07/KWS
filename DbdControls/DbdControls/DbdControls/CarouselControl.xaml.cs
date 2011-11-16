using System;
using System.IO;
using System.Windows.Media.Imaging;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace DbdControls
{
    /// <summary>
    /// Author:     Matthew Drake
    ///             Drake Barrineau Designs
    /// Updated:    August 10th, 2008
    /// </summary>

    public partial class CarouselControl : UserControl
    {

        public CarouselStations Stations { get; set; }
        public bool StartRotation = false;
        public string SelectedStation = string.Empty;
        public double Speed;

        private CarouselStations stations;
        private List<double> angles;
        private const double MAX_SPEED = 0.00950;
        private double distantOpacity;
        private List<ScaleTransform> scaleTransforms = new List<ScaleTransform>();
        private Dictionary<Image, string> urls;
        private System.Windows.Threading.DispatcherTimer dispTimer;
        private string urlBase;


        public CarouselControl(CarouselStations cs)
        {
            new CarouselControl(cs, 1);
        }

        public CarouselControl(CarouselStations cs, double distantOpacityValue)
        {
            InitializeComponent();

            // Set station click event and private properties
            foreach (CarouselStation station in cs)
            {
                station.MouseLeftButtonUp += new MouseButtonEventHandler(station_MouseLeftButtonUp);
            }
            stations = cs;
            distantOpacity = distantOpacityValue;

            // Wire up events
            this.Loaded += new RoutedEventHandler(CarouselControl_Loaded);
            this.MouseMove += new MouseEventHandler(CarouselControl_MouseMove);
            this.MouseLeftButtonDown += new MouseButtonEventHandler(CarouselControl_MouseLeftButtonDown);
        }

        void station_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Rotate to selected station, quickly..
            CarouselStation station = (CarouselStation)sender;
            station.Frozen = true;
            SelectedStation = station.StationId;
            Speed = 0.2;
            StartRotation = true;
            PositionItems();
        }

        void CarouselControl_Loaded(object sender, RoutedEventArgs e)
        {
            // Set public properties
            this.Stations = stations;

            // Set local properties
            Speed = -MAX_SPEED;
            StartRotation = false;
            urls = new Dictionary<Image, string>();
            angles = new List<double>();
            dispTimer = new System.Windows.Threading.DispatcherTimer();
            dispTimer.Interval = TimeSpan.FromMilliseconds(25);
            dispTimer.Tick += new EventHandler(dt_Tick);
            dispTimer.Stop();
            urlBase = GetURLBase();
            if (stations.Count > 0) BuildImages();
        }

        void CarouselControl_MouseMove(object sender, MouseEventArgs e)
        {
            Point pt = e.GetPosition(null);
            double root_xmouse = pt.X;
            double root_ymouse = pt.Y;
            if (SelectedStation.Length == 0)
            {
                Speed = ((root_xmouse - (this.Width / 2)) / (this.Width / 2)) * 0.0755;
                if (Speed < -MAX_SPEED) Speed = -MAX_SPEED;
                if (Speed > MAX_SPEED) Speed = MAX_SPEED;
            }
        }

        void CarouselControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StartRotation = !StartRotation;
        }

        protected void BuildImages()
        {
            //  Transformations are imposed on a station wrapper (Canvas in this case), 
            //  although they could probablly be done directly on the station UserControl instead.            
            for (int i = 0; i < stations.Count; ++i)
            {

                Canvas imgHolder = new Canvas();
                imgHolder.Children.Add(stations[i]);

                // Create new transformation object
                ScaleTransform stationHolderScaleTrans = new ScaleTransform();
                scaleTransforms.Add(stationHolderScaleTrans);
                stationHolderScaleTrans.ScaleX = 1;
                stationHolderScaleTrans.ScaleY = 1;
                stationHolderScaleTrans.CenterX = 75;
                stationHolderScaleTrans.CenterY = 75;

                imgHolder.RenderTransform = stationHolderScaleTrans;

                mainCanvas.Children.Add(imgHolder);

                angles.Add(i * ((Math.PI * 2) / stations.Count));

            }
            PositionItems();
            StartRotation = true;
            dispTimer.Start();
        }

        void dt_Tick(object sender, EventArgs e)
        {
            MoveItems();
        }

        void MoveItems()
        {
            if (StartRotation)
            {
                PositionItems();
            }
        }

        void PositionItems()
        {
            int radiusX = 300;
            int radiusY = 80;
            int centerX = Convert.ToInt32(this.Width / 2) - 100;
            int centerY = 220;
            Canvas imgCanvas;

            for (int i = 0; i < stations.Count; i++)
            {
                imgCanvas = (Canvas)mainCanvas.Children[i];

                // Change position
                double myX = (Math.Cos(angles[i]) * radiusX) + centerX;
                double myY = Math.Sin(angles[i]) * radiusY + centerY;
                imgCanvas.SetValue(Canvas.LeftProperty, myX);
                imgCanvas.SetValue(Canvas.TopProperty, myY);

                // Change distant opacity
                double opacity = (Math.Sin(angles[i]) + 1) / 2 * (1 - distantOpacity) + distantOpacity;
                imgCanvas.SetValue(Canvas.OpacityProperty, opacity);

                // Change size
                ScaleTransform stRef = scaleTransforms[i];
                double sc = (myY - stRef.ScaleY) / (centerY + radiusY - stRef.ScaleY);
                stRef.ScaleX = sc;
                stRef.ScaleY = sc;
                angles[i] += Speed;

                // Establish display order
                imgCanvas.SetValue(Canvas.ZIndexProperty, (int)myY);
            }

            // When a station is selected, stop rotation
            for (int i = 0; i < stations.Count; i++)
            {
                imgCanvas = (Canvas)mainCanvas.Children[i];
                if (stations[i].StationId == SelectedStation & imgCanvas.Opacity > 0.995) Speed = 0;
            }

        }

        string GetURLBase()
        {
            string str = System.Windows.Application.Current.Host.Source.OriginalString;
            return str.Substring(0, str.LastIndexOf("/")).Replace("ClientBin", string.Empty);
        }
    }
}
