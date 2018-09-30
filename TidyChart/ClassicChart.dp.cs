using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace TidyChart
{
    public partial class ClassicChart
    {

        /// <summary>
        /// Color of wave line
        /// </summary>
        public Brush WaveForeground
        {
            get { return (Brush)GetValue(WaveForegroundProperty); }
            set { SetValue(WaveForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WaveForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WaveForegroundProperty =
            DependencyProperty.Register("WaveForeground", typeof(Brush), typeof(ClassicChart), new PropertyMetadata(new SolidColorBrush(Colors.Green)));

        
        /// <summary>
        /// Min value of axis Y
        /// </summary>
        public double MinYAxis
        {
            get { return (double)GetValue(MinYAxisProperty); }
            set { SetValue(MinYAxisProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinYAxis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinYAxisProperty =
            DependencyProperty.Register("MinYAxis", typeof(double), typeof(ClassicChart), new PropertyMetadata(0.0));


        /// <summary>
        /// Max value of axis Y
        /// </summary>
        public double MaxYAxis
        {
            get { return (double)GetValue(MaxYAxisProperty); }
            set { SetValue(MaxYAxisProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxYAxis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxYAxisProperty =
            DependencyProperty.Register("MaxYAxis", typeof(double), typeof(ClassicChart), new PropertyMetadata(10.0));



        /// <summary>
        /// Min value of axis X
        /// </summary>
        public double MinXAxis
        {
            get { return (double)GetValue(MinXAxisProperty); }
            set { SetValue(MinXAxisProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinXAxis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinXAxisProperty =
            DependencyProperty.Register("MinXAxis", typeof(double), typeof(ClassicChart), new PropertyMetadata(0.0));


        /// <summary>
        /// Max value of axis X
        /// </summary>
        public double MaxXAxis
        {
            get { return (double)GetValue(MaxXAxisProperty); }
            set { SetValue(MaxXAxisProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxXAxis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxXAxisProperty =
            DependencyProperty.Register("MaxXAxis", typeof(double), typeof(ClassicChart), new PropertyMetadata(10.0));



        /// <summary>
        /// Data source
        /// </summary>
        public List<Point> DataSource
        {
            get { return (List<Point>)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataSourceProperty =
            DependencyProperty.Register("DataSource", typeof(List<Point>), typeof(ClassicChart), new PropertyMetadata(null));


        /// <summary>
        /// Auto calculate axis scale. when true, MinXAxis MaxXAxis MinYAxis MaxYAxis are calculated automatically, according to the DataSource.
        /// </summary>
        public bool AutoAxis
        {
            get { return (bool)GetValue(AutoAxisProperty); }
            set { SetValue(AutoAxisProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AutoAxis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AutoAxisProperty =
            DependencyProperty.Register("AutoAxis", typeof(bool), typeof(ClassicChart), new PropertyMetadata(true));


        /// <summary>
        /// Thickness of wave line.
        /// </summary>
        public double WaveThickness
        {
            get { return (double)GetValue(WaveThicknessProperty); }
            set { SetValue(WaveThicknessProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WaveThickness.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WaveThicknessProperty =
            DependencyProperty.Register("WaveThickness", typeof(double), typeof(ClassicChart), new PropertyMetadata(1.0));


        /// <summary>
        /// true ---- show grid; false ---- do not show grid.
        /// </summary>
        public bool ShowGrid
        {
            get { return (bool)GetValue(ShowGridProperty); }
            set { SetValue(ShowGridProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowGrid.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowGridProperty =
            DependencyProperty.Register("ShowGrid", typeof(bool), typeof(ClassicChart), new PropertyMetadata(true));


        /// <summary>
        /// true --- auto to updating the ui;false ---- manual.
        /// </summary>
        public bool AutoUpdateUi
        {
            get { return (bool)GetValue(AutoUpdateUiProperty); }
            set { SetValue(AutoUpdateUiProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AutoUpdateUi.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AutoUpdateUiProperty =
            DependencyProperty.Register("AutoUpdateUi", typeof(bool), typeof(ClassicChart), new PropertyMetadata(false));


        /// <summary>
        /// AutoUpdate interval, ms.
        /// </summary>
        public int UpdateInterval
        {
            get { return (int)GetValue(UpdateIntervalProperty); }
            set { SetValue(UpdateIntervalProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UpdateInterval.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UpdateIntervalProperty =
            DependencyProperty.Register("UpdateInterval", typeof(int), typeof(ClassicChart), new PropertyMetadata(200));



        public string LegendTitle
        {
            get { return (string)GetValue(LegendTitleProperty); }
            set { SetValue(LegendTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LegendTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LegendTitleProperty =
            DependencyProperty.Register("LegendTitle", typeof(string), typeof(ClassicChart), new PropertyMetadata(""));


    }
}
