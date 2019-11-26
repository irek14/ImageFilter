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

namespace ImageFilter
{
    public partial class MainForm : Form
    {
        private void MyFunctionPicture_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Brushes.Black);

            e.Graphics.DrawLine(pen, cartesianStart, new Point(cartesianStart.X, cartesianStart.Y - 256));
            e.Graphics.DrawLine(pen, cartesianStart, new Point(cartesianStart.X + 256, cartesianStart.Y));

            for (int i = 0; i < myPoints.Count - 1; i++)
            {
                e.Graphics.DrawLine(pen, myPoints[i], myPoints[i + 1]);
            }

            foreach (var point in myPoints)
            {
                if (chartPoint == point)
                {
                    e.Graphics.FillRectangle(Brushes.Red, point.X - 3, point.Y - 3, 6, 6);
                }
                else
                {
                    e.Graphics.FillRectangle(Brushes.Black, point.X - 3, point.Y - 3, 6, 6);
                }
            }
        }

        private void MyFunctionPicture_MouseDown(object sender, MouseEventArgs e)
        {
            chartPoint = GetPoint(new Point(e.X, e.Y));
            if (chartPoint != new Point(-1, -1))
            {
                MyFunctionPicture.Invalidate();
                Cursor = Cursors.SizeNS;
            }

        }

        private void MyFunctionPicture_MouseUp(object sender, MouseEventArgs e)
        {
            chartPoint = new Point(-1, -1);
            MyFunctionPicture.Invalidate();
            Cursor = Cursors.Default;
            InitializeMyFunction();
        }

        private void MyFunctionPicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (chartPoint == new Point(-1, -1))
                return;

            int newY = e.Y;

            if (newY < cartesianStart.Y - 255)
                newY = cartesianStart.Y - 255;

            if (newY > cartesianStart.Y)
                newY = cartesianStart.Y;

            for (int i = 0; i < myPoints.Count; i++)
            {
                if (myPoints[i] == chartPoint)
                {
                    Point newPoint = new Point(myPoints[i].X, newY);
                    myPoints[i] = newPoint;
                    chartPoint = newPoint;
                    MyFunctionPicture.Invalidate();
                    return;
                }
            }
        }

        private void InitializePointList()
        {
            myPoints.Add(new Point(cartesianStart.X, cartesianStart.Y));
            myPoints.Add(new Point(cartesianStart.X + 15, cartesianStart.Y - 10));
            myPoints.Add(new Point(cartesianStart.X + 30, cartesianStart.Y - 50));
            myPoints.Add(new Point(cartesianStart.X + 45, cartesianStart.Y - 80));
            myPoints.Add(new Point(cartesianStart.X + 60, cartesianStart.Y - 90));
            myPoints.Add(new Point(cartesianStart.X + 75, cartesianStart.Y - 85));
            myPoints.Add(new Point(cartesianStart.X + 90, cartesianStart.Y - 70));
            myPoints.Add(new Point(cartesianStart.X + 105, cartesianStart.Y - 60));
            myPoints.Add(new Point(cartesianStart.X + 120, cartesianStart.Y - 20));
            myPoints.Add(new Point(cartesianStart.X + 135, cartesianStart.Y - 10));
            myPoints.Add(new Point(cartesianStart.X + 150, cartesianStart.Y - 55));
            myPoints.Add(new Point(cartesianStart.X + 165, cartesianStart.Y - 80));
            myPoints.Add(new Point(cartesianStart.X + 180, cartesianStart.Y - 95));
            myPoints.Add(new Point(cartesianStart.X + 195, cartesianStart.Y - 105));
            myPoints.Add(new Point(cartesianStart.X + 210, cartesianStart.Y - 145));
            myPoints.Add(new Point(cartesianStart.X + 225, cartesianStart.Y - 160));
            myPoints.Add(new Point(cartesianStart.X + 240, cartesianStart.Y - 200));
            myPoints.Add(new Point(cartesianStart.X + 255, cartesianStart.Y - 240));
        }

        private Point GetPoint(Point p)
        {
            foreach (var point in myPoints)
            {
                if (CheckIfPoint(p, point))
                {
                    return point;
                }
            }
            return new Point(-1, -1);
        }

        private bool CheckIfPoint(Point p, Point vertex)
        {
            if (Math.Abs(p.X - vertex.X) <= 5 && Math.Abs(p.Y - vertex.Y) <= 5)
                return true;

            return false;
        }

        private void InitializeMyFunction()
        {
            int startValue = cartesianStart.Y - myPoints[0].Y;
            int endValue = 0;
            double currentValue = cartesianStart.Y - myPoints[0].Y;
            for (int i = 0; i < 17; i++)
            {
                endValue = cartesianStart.Y - myPoints[i + 1].Y;
                int startX = i * 15;
                for (int j = 0; j < 15; j++)
                {
                    myFunction[startX + j] = (int)currentValue;
                    currentValue += ((double)(endValue - startValue)) / 15.0;
                }
                startValue = (int)currentValue;
            }
            myFunction[255] = endValue;
        }
    }
}
