using ImageFilter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageFilter
{
    public partial class MainForm : Form
    {
        private void PrepareMyFunctionChart()
        {
            MyFunctionChart.Series.Clear();
            MyFunctionChart.ChartAreas.Clear();

            ChartArea ChartArea0 = new ChartArea("Function");

            MyFunctionChart.ChartAreas.Add(ChartArea0);
            ChartArea0.AxisX.Minimum = 0;
            ChartArea0.AxisX.Maximum = 255;
            ChartArea0.AxisX.Interval = 255;
            ChartArea0.AxisY.Minimum = 0;
            ChartArea0.AxisY.Maximum = 255;
            ChartArea0.AxisY.Interval = 255;

            MyFunctionChart.Series.Add("Seria 1");

            MyFunctionChart.Series["Seria 1"].ChartType = SeriesChartType.Line;

            for (int i = 0; i < 256; i++)
            {
                MyFunctionChart.Series["Seria 1"].Points.AddXY(i, MyFunction(i));
            }

            MyFunctionChart.Series["Seria 1"].ChartArea = "Function";
        }

        private void PrepareCharts()
        {
            int[] R = new int[256];
            int[] G = new int[256];
            int[] B = new int[256];

            RChart.Series.Clear();
            GChart.Series.Clear();
            BChart.Series.Clear();

            RChart.ChartAreas.Clear();
            GChart.ChartAreas.Clear();
            BChart.ChartAreas.Clear();

            for (int i = 0; i < ImageBitmap.Width && i < PhotoWidth; i++)
            {
                for (int j = 0; j < ImageBitmap.Width && j < PhotoHeight; j++)
                {
                    R[newPhoto[i, j].R]++;
                    G[newPhoto[i, j].G]++;
                    B[newPhoto[i, j].B]++;
                }
            }

            ChartArea ChartArea0 = new ChartArea("Color R");
            ChartArea ChartArea1 = new ChartArea("Color G");
            ChartArea ChartArea2 = new ChartArea("Color B");

            RChart.ChartAreas.Add(ChartArea0);
            ChartArea0.AxisX.Minimum = 0;
            ChartArea0.AxisY.Maximum = R.Max() + 50;
            GChart.ChartAreas.Add(ChartArea1);
            ChartArea1.AxisX.Minimum = 0;
            ChartArea1.AxisY.Maximum = R.Max() + 50;
            BChart.ChartAreas.Add(ChartArea2);
            ChartArea2.AxisX.Minimum = 0;
            ChartArea2.AxisY.Maximum = R.Max() + 50;

            RChart.Series.Add("Seria 1");
            GChart.Series.Add("Seria 1");
            BChart.Series.Add("Seria 1");

            for (int i = 0; i < 256; i++)
            {
                RChart.Series["Seria 1"].Points.AddXY(i, R[i]);
                GChart.Series["Seria 1"].Points.AddXY(i, G[i]);
                BChart.Series["Seria 1"].Points.AddXY(i, B[i]);
            }

            RChart.Series["Seria 1"].ChartArea = "Color R";
            GChart.Series["Seria 1"].ChartArea = "Color G";
            BChart.Series["Seria 1"].ChartArea = "Color B";
        }
    }
}
