using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace DbdControls
{
    /// <summary>
    /// Author:     Matthew Drake
    ///             Drake Barrineau Designs
    ///             mdrake@cssiinc.com or matthew@drakebarrineau.com
    /// Updated:    August 15th, 2008
    /// </summary>

    public partial class CarouselStation : UserControl
    {
        
        // Public properties
        public string Title { get; set; }         // Title that appears on top of section image [optional]
        public string StationId { get; set; }     // Short station name
        public string Description { get; set; }   // Full text description of the station [optional]
        public string VariableText { get; set; }  // Short lower left text of section image [optional]
        public object StationTag { get; set; }    // An Object to attach to the station of any contents
        public bool Frozen { get; set; }          // Freezes the station in it's last state

        // Local variables
        private string _title;
        private string _stationId;
        private string _relativeImagePath;        // Relative path to images (main, glow, drop shadow, selected)
        private string _description;
        private string _variableText;
        private object _tag;

        public CarouselStation(string title, string stationId, string relativeImagePath, string description, string variableText, object tag)
        {
            InitializeComponent();

            // Set local variables
            _title = title;
            _stationId = stationId;
            _relativeImagePath = relativeImagePath;
            _description = description;
            _variableText = variableText;
            _tag = tag;

            // Wire up station events
            this.Loaded += new RoutedEventHandler(CarouselStation_Loaded);
            this.MouseEnter += new MouseEventHandler(CarouselStation_MouseEnter);
            this.MouseLeave += new MouseEventHandler(CarouselStation_MouseLeave);
            this.MouseLeftButtonDown += new MouseButtonEventHandler(CarouselStation_MouseLeftButtonDown);
            this.MouseLeftButtonUp += new MouseButtonEventHandler(CarouselStation_MouseLeftButtonUp);
        }

        void CarouselStation_Loaded(object sender, EventArgs e)
        {
            // Set public properties
            this.Title = _title;
            this.StationId = _stationId;
            this.Description = _description;
            this.VariableText = _variableText;
            this.StationTag = _tag;

            // Set text attributes
            TextTitle.Text = _title;
            TextDrop.Text = _title;
            VariableTextBlock.Text = _variableText;

            string _urlBase = GetURLBase();

            // Set image sources
            ImageMain.Source = new BitmapImage(new Uri(_urlBase + _relativeImagePath));
            ImageRefl.Source = new BitmapImage(new Uri(_urlBase + _relativeImagePath));

            // Effects below require additional files with filename suffixes (*glow", "*drop", "*down")
            // to display during mouse events.  The "drop" is the drop shadow behind the main image.
            ImageGlow.Source = new BitmapImage(new Uri(_urlBase + _relativeImagePath.Replace(".", "glow.")));
            ImageDown.Source = new BitmapImage(new Uri(_urlBase + _relativeImagePath.Replace(".", "down.")));
            ImageDrop.Source = new BitmapImage(new Uri(_urlBase + _relativeImagePath.Replace(".", "drop.")));
        }

        void CarouselStation_MouseEnter(object sender, MouseEventArgs e)
        {
            MouseOver.Begin();
        }

        public void CarouselStation_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!Frozen)
            {
                MouseOut.Begin();
                ImageDown.Opacity = 0;
            }
        }

        void CarouselStation_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ImageGlow.Opacity = 0;
            ImageDown.Opacity = 1;
        }

        void CarouselStation_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ImageGlow.Opacity = 1;
            MouseOut.Begin();
        }

        string GetURLBase()
        {
            string str = System.Windows.Application.Current.Host.Source.OriginalString;
            return str.Substring(0, str.LastIndexOf("/")).Replace("ClientBin", string.Empty);
        }
    }

    public class CarouselStations : List<CarouselStation> { }
}
