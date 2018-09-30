using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TidyChartTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWndVM _vm;
        private Timer _timer;

        public MainWindow()
        {
            InitializeComponent();

            _vm = new MainWndVM();

            DataContext = _vm;

            _timer = new Timer(200);
            _timer.Elapsed += _timer_Elapsed;
            //_timer.Start();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            NewSomeDatas();
        }

        private void NewSomeDatas()
        {
            Random rd = new Random();
            int num = rd.Next(400, 500);
            try
            {
                this.Dispatcher.Invoke(() =>
                {
                    _vm.WaveDatas.Clear();
                    for (int i = 0; i < num; i++)
                    {
                        _vm.WaveDatas.Add(new Point(i, rd.Next(-200, 200)));
                    }

                    this.chart.UpdateAllUIDatas();
                });

            }
            catch {

            }
        }


        private void btnDraw_Click(object sender, RoutedEventArgs e)
        {
            NewSomeDatas();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            _vm.WaveDatas.Clear();
            this.chart.UpdateAllUIDatas();
        }
    }
}
