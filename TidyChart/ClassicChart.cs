using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TidyChart
{
    public partial class ClassicChart : Canvas
    {
        private const int AxisYWidth = 20;
        private const int AxisXHeight = 10;
        private const int AxisLineThickness = 2;
        private const int AxisScaleNum = 6;

        private List<Visual> _visuals;
        private DrawingVisual _waveLayer;
        private DrawingVisual _backgroundLayer;

        public ClassicChart()
        {
            _visuals = new List<Visual>();
            
            _backgroundLayer = new DrawingVisual();
            _waveLayer = new DrawingVisual();
            AddVisual(_backgroundLayer);
            AddVisual(_waveLayer);
        }
        
        private void DrawBackGround(DrawingVisual dv)
        {
            Pen axisLinePen = new Pen(new SolidColorBrush(Colors.Black), AxisLineThickness);
            
            DrawingContext dc = dv.RenderOpen();

            double minX = MinXAxis;
            double maxX = MaxXAxis;
            double minY = MinYAxis;
            double maxY = MaxYAxis;
            if (AutoAxis)
            {
                if(DataSource != null)
                {
                    minX = DataSource.Min(x => x.X);
                    maxX = DataSource.Max(x => x.X);
                    minY = DataSource.Min(x => x.Y);
                    maxY = DataSource.Max(x => x.Y);
                }
            }

            double waveWidth = this.ActualWidth - AxisYWidth - AxisLineThickness;
            double waveHeight = this.ActualHeight - AxisXHeight - AxisLineThickness;

            // 绘制边界线
            dc.DrawLine(axisLinePen, new Point(AxisYWidth, 0), new Point(AxisYWidth, waveHeight));
            dc.DrawLine(axisLinePen, new Point(AxisYWidth, waveHeight), new Point(this.ActualWidth, waveHeight));

            // 绘制刻线
            double axisXScale = waveWidth / AxisScaleNum;
            double axisYScale = waveHeight / AxisScaleNum;
            for (int i = 0; i < AxisScaleNum + 1; i++)
            {
                // Draw Axis X
                dc.DrawLine(axisLinePen, new Point(AxisYWidth + i * axisXScale, waveHeight), 
                            new Point(AxisYWidth + i * axisXScale, waveHeight + 5));
                // Draw scale value of X
                double curScaleValue = minX + i * ((maxX - minX) / AxisScaleNum);
                string str = string.Format("{0:0}", curScaleValue);
                FormattedText ft = new FormattedText(str, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight,
                                                      new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal),
                                                      8, new SolidColorBrush(Colors.Black));
                if (i == AxisScaleNum)
                {
                    // 最后一个刻度值绘制在刻度线左边
                    dc.DrawText(ft, new Point(AxisYWidth + i * axisXScale - 20, waveHeight + 1));
                }
                else
                {
                    dc.DrawText(ft, new Point(AxisYWidth + i * axisXScale + 2, waveHeight + 1));
                }
                
                // Draw Axis Y
                dc.DrawLine(axisLinePen, new Point(AxisYWidth, waveHeight - i * axisYScale),
                            new Point(AxisYWidth - 5, waveHeight - i * axisYScale));
                // Draw scale value of Y
                curScaleValue = minY + i * ((maxY - minY) / AxisScaleNum);
                str = string.Format("{0:0}", curScaleValue);
                ft = new FormattedText(str, CultureInfo.GetCultureInfo("en-us"), FlowDirection.LeftToRight,
                                       new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal),
                                       8, new SolidColorBrush(Colors.Black));
                if (i == 0)
                {
                    // 第一个刻度值绘制在刻度线上方
                    dc.DrawText(ft, new Point(AxisYWidth - 19, waveHeight - 9));
                }
                else
                {
                    dc.DrawText(ft, new Point(AxisYWidth - 19, waveHeight - i * axisYScale + 1));
                }
            }
            dc.Close();
        }

        private void DrawWaveLayer(DrawingVisual dv)
        {
            if (DataSource == null)
            {
                return;
            }
            double minX = MinXAxis;
            double maxX = MaxXAxis;
            double minY = MinYAxis;
            double maxY = MaxYAxis;
            if (AutoAxis)
            {
                minX = DataSource.Min(x => x.X);
                maxX = DataSource.Max(x => x.X);
                minY = DataSource.Min(x => x.Y);
                maxY = DataSource.Max(x => x.Y);
            }

            double waveWidth = this.ActualWidth - AxisYWidth - AxisLineThickness;
            double waveHeight = this.ActualHeight - AxisXHeight - AxisLineThickness;

            Pen p = new Pen(WaveForeground, WaveThickness);
            DrawingContext dc = dv.RenderOpen();

            for (int i = 1; i < (DataSource.Count); i++)
            {
                Point startP = new Point(waveWidth * ((DataSource[i - 1].X - minX) / (maxX - minX)) + AxisYWidth + AxisLineThickness,
                                            waveHeight * ((DataSource[i - 1].Y - minY) / (maxY - minY)));
                Point endP = new Point(waveWidth * ((DataSource[i].X - minX) / (maxX - minX)) + AxisYWidth + AxisLineThickness,
                                            waveHeight * ((DataSource[i].Y - minY) / (maxY - minY)));

                dc.DrawLine(p, startP, endP);
            }

            dc.Close();
        }

        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);

            DrawBackGround(_backgroundLayer);
            DrawWaveLayer(_waveLayer);
        }

        public void UpdateAllUIDatas()
        {
            DrawBackGround(_backgroundLayer);
            DrawWaveLayer(_waveLayer);
        }

        public void AddVisual(Visual visual)
        {
            this._visuals.Add(visual);
            base.AddVisualChild(visual);
            base.AddLogicalChild(visual);
        }

        public void RemoveVisual(Visual visual)
        {
            this._visuals.Remove(visual);
            base.RemoveVisualChild(visual);
            base.RemoveLogicalChild(visual);
        }

        protected override int VisualChildrenCount => this._visuals.Count;

        protected override Visual GetVisualChild(int index)
        {
            return this._visuals[index];
        }
    }
}
