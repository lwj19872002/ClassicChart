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


        public Brush WaveForeground
        {
            get { return (Brush)GetValue(WaveForegroundProperty); }
            set { SetValue(WaveForegroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WaveForeground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WaveForegroundProperty =
            DependencyProperty.Register("WaveForeground", typeof(Brush), typeof(ClassicChart), new PropertyMetadata(new SolidColorBrush(Colors.Green)));




        public double MinYAxis
        {
            get { return (double)GetValue(MinYAxisProperty); }
            set { SetValue(MinYAxisProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinYAxis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinYAxisProperty =
            DependencyProperty.Register("MinYAxis", typeof(double), typeof(ClassicChart), new PropertyMetadata(0.0));



        public double MaxYAxis
        {
            get { return (double)GetValue(MaxYAxisProperty); }
            set { SetValue(MaxYAxisProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxYAxis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxYAxisProperty =
            DependencyProperty.Register("MaxYAxis", typeof(double), typeof(ClassicChart), new PropertyMetadata(10.0));




        public double MinXAxis
        {
            get { return (double)GetValue(MinXAxisProperty); }
            set { SetValue(MinXAxisProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MinXAxis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinXAxisProperty =
            DependencyProperty.Register("MinXAxis", typeof(double), typeof(ClassicChart), new PropertyMetadata(0.0));



        public double MaxXAxis
        {
            get { return (double)GetValue(MaxXAxisProperty); }
            set { SetValue(MaxXAxisProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaxXAxis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaxXAxisProperty =
            DependencyProperty.Register("MaxXAxis", typeof(double), typeof(ClassicChart), new PropertyMetadata(10.0));




        public List<Point> DataSource
        {
            get { return (List<Point>)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DataSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataSourceProperty =
            DependencyProperty.Register("DataSource", typeof(List<Point>), typeof(ClassicChart), new PropertyMetadata(null));



        public bool AutoAxis
        {
            get { return (bool)GetValue(AutoAxisProperty); }
            set { SetValue(AutoAxisProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AutoAxis.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AutoAxisProperty =
            DependencyProperty.Register("AutoAxis", typeof(bool), typeof(ClassicChart), new PropertyMetadata(true));


    }
}
