using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Mvvm;

namespace TidyChartTest
{
    public class MainWndVM : BindableBase
    {
        private List<Point> _WaveDatas;
        /// <summary>
        /// 
        /// </summary>
        public List<Point> WaveDatas
        {
            get { return _WaveDatas; }
            set
            {
                OnPropertyChanged("WaveDatas");
                _WaveDatas = value;
            }
        }

        public MainWndVM()
        {
            WaveDatas = new List<Point>();
        }
    }
}
