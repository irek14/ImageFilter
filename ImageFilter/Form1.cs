﻿using ImageFilter.Properties;
using LiveCharts;
using LiveCharts.Wpf;
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
        Color[,] photo;
        Color[,] newPhoto;

        Bitmap ImageBitmap = new Bitmap(Resources.Teppan);
        Point mouse_point = new Point(-1, -1);
        List<Polygon> polygons = new List<Polygon>();
        bool drawCurrentLine = false;
        Polygon current_polygon;
        (Point, Point) current_line;
        Point? current_point = null;
        Point? previous_point = null;

        bool[,] IsAlreadyChange;
        bool isMouseClicked = false;

        BrushMode current_mode = BrushMode.Circle;
        int radius = 50;

        enum BrushMode { Circle, FirstPoint, DrawPolygon, DeletePolygon };

        public bool IsPointInPolygon(Point point, Point[] polygon)
        {
            int polygonLength = polygon.Length, i = 0;
            bool inside = false;
            // x, y for tested point.
            float pointX = point.X, pointY = point.Y;
            // start / end point for the current polygon segment.
            float startX, startY, endX, endY;
            Point endPoint = polygon[polygonLength - 1];
            endX = endPoint.X;
            endY = endPoint.Y;
            while (i < polygonLength)
            {
                startX = endX; startY = endY;
                endPoint = polygon[i++];
                endX = endPoint.X; endY = endPoint.Y;
                //
                inside ^= (endY > pointY ^ startY > pointY) /* ? pointY inside [startY;endY] segment ? */
                          && /* if so, test if it is under the segment */
                          ((pointX - endX) < (pointY - endY) * (startX - endX) / (startY - endY));
            }
            return inside;
        }

        public MainForm()
        {
            InitializeComponent();

            InitializePointList();
            InitializeMyFunction();
            MyFunctionPicture.Invalidate();

            IsAlreadyChange = new bool[Image.Width, Image.Height];

            InitializeImage();
            Image.Invalidate();
        }

        Point cartesianStart = new Point(45, 265);
        List<Point> myPoints = new List<Point>();
        Point chartPoint = new Point(-1, -1);

        private void InitializePointList()
        {
            myPoints.Add(new Point(cartesianStart.X, cartesianStart.Y));
            myPoints.Add(new Point(cartesianStart.X+15, cartesianStart.Y-10));
            myPoints.Add(new Point(cartesianStart.X+30, cartesianStart.Y-50));
            myPoints.Add(new Point(cartesianStart.X+45, cartesianStart.Y-80));
            myPoints.Add(new Point(cartesianStart.X+60, cartesianStart.Y-90));
            myPoints.Add(new Point(cartesianStart.X+75, cartesianStart.Y-85));
            myPoints.Add(new Point(cartesianStart.X+90, cartesianStart.Y-70));
            myPoints.Add(new Point(cartesianStart.X+105, cartesianStart.Y-60));
            myPoints.Add(new Point(cartesianStart.X+120, cartesianStart.Y-20));
            myPoints.Add(new Point(cartesianStart.X+135, cartesianStart.Y-10));
            myPoints.Add(new Point(cartesianStart.X+150, cartesianStart.Y-55));
            myPoints.Add(new Point(cartesianStart.X+165, cartesianStart.Y-80));
            myPoints.Add(new Point(cartesianStart.X+180, cartesianStart.Y-95));
            myPoints.Add(new Point(cartesianStart.X+195, cartesianStart.Y-105));
            myPoints.Add(new Point(cartesianStart.X+210, cartesianStart.Y-145));
            myPoints.Add(new Point(cartesianStart.X+225, cartesianStart.Y-160));
            myPoints.Add(new Point(cartesianStart.X+240, cartesianStart.Y-200));
            myPoints.Add(new Point(cartesianStart.X+255, cartesianStart.Y-240));
        }

        private void MyFunctionPicture_Paint(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Brushes.Black);

            e.Graphics.DrawLine(pen, cartesianStart, new Point(cartesianStart.X, cartesianStart.Y - 256));
            e.Graphics.DrawLine(pen, cartesianStart, new Point(cartesianStart.X + 256, cartesianStart.Y));

            for (int i = 0; i < myPoints.Count-1; i++)
            {
                e.Graphics.DrawLine(pen, myPoints[i], myPoints[i + 1]); 
            }

            foreach(var point in myPoints)
            {
                if(chartPoint == point)
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
            if(chartPoint != new Point(-1,-1))
            {
                MyFunctionPicture.Invalidate();
                Cursor = Cursors.SizeNS;
            }
            
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
            return new Point(-1,-1);
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
            int endValue=0;
            double currentValue = cartesianStart.Y - myPoints[0].Y;
            for (int i = 0; i < 17; i++)
            {
                endValue = cartesianStart.Y - myPoints[i+1].Y;
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

        private void InitializeImage()
        {
            photo = new Color[Image.Width, Image.Height];
            newPhoto = new Color[Image.Width, Image.Height];

            for (int i = 0; i < Image.Width; i++)
            {
                for (int j = 0; j < Image.Height; j++)
                {
                    if (i < ImageBitmap.Width && j < ImageBitmap.Height)
                    {
                        Color pixel = ImageBitmap.GetPixel(i, j);
                        photo[i, j] = pixel;
                        newPhoto[i, j] = pixel;
                    }
                    else
                    {
                        photo[i, j] = Color.White;
                        newPhoto[i, j] = Color.White;
                    }                        
                }
            }
        }

        private void ChartTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ApplyCircleFilter()
        {
            for(int i=0; i<ImageBitmap.Width; i++)
            {
                if (Image.Width <= i)
                    break;

                for (int j = 0; j < ImageBitmap.Height; j++)
                {
                    if (Image.Height <= j)
                        break;

                    if (IsAlreadyChange[i, j])
                        continue;

                    double d = Math.Sqrt((i - mouse_point.X - radius) * (i - mouse_point.X - radius) + (j - mouse_point.Y - radius) * (j - mouse_point.Y - radius));
                    if (d < radius/2)
                    {
                        GetColor(i, j);
                    }
                }
            }
        }

        private void GetColor(int i, int j)
        {
            int R = 0, G = 0, B = 0;
            if(NoFilterRadio.Checked)
            {
                R = newPhoto[i, j].R;
                G = newPhoto[i, j].G;
                B = newPhoto[i, j].B;
            }
            else if (MyFunctionRadio.Checked)
            {
                R = MyFunction(newPhoto[i, j].R);
                G = MyFunction(newPhoto[i, j].G);
                B = MyFunction(newPhoto[i, j].B);
            }
            else if (NegationRadio.Checked)
            {
                R = Negation(newPhoto[i, j].R);
                G = Negation(newPhoto[i, j].G);
                B = Negation(newPhoto[i, j].B);
            }
            else if (BrightnessRadio.Checked)
            {
                R = ChangeBrightness(newPhoto[i, j].R, int.Parse(BrigthnessDelta.Value.ToString()));
                G = ChangeBrightness(newPhoto[i, j].G, int.Parse(BrigthnessDelta.Value.ToString()));
                B = ChangeBrightness(newPhoto[i, j].B, int.Parse(BrigthnessDelta.Value.ToString()));
            }
            else if (ContrastRadio.Checked)
            {
                R = Contrast(newPhoto[i, j].R, int.Parse(ContrastFirstDelta.Value.ToString()), int.Parse(ContrastSecondDelta.Value.ToString()));
                G = Contrast(newPhoto[i, j].G, int.Parse(ContrastFirstDelta.Value.ToString()), int.Parse(ContrastSecondDelta.Value.ToString()));
                B = Contrast(newPhoto[i, j].B, int.Parse(ContrastFirstDelta.Value.ToString()), int.Parse(ContrastSecondDelta.Value.ToString()));
            }
            else if (GammaRadio.Checked)
            {
                R = GammCorrection(newPhoto[i, j].R, double.Parse(GammaCoefficient.Value.ToString()));
                G = GammCorrection(newPhoto[i, j].G, double.Parse(GammaCoefficient.Value.ToString()));
                B = GammCorrection(newPhoto[i, j].B, double.Parse(GammaCoefficient.Value.ToString()));
            }

            newPhoto[i, j] = Color.FromArgb(R, G, B);

            if (!NoFilterRadio.Checked)
                IsAlreadyChange[i, j] = true;
        }

        private void ApplyPolygonFilter()
        {
            for (int i = 0; i < ImageBitmap.Width; i++)
            {
                if (Image.Width <= i)
                    break;

                for (int j = 0; j < ImageBitmap.Height; j++)
                {
                    if (Image.Height <= j)
                        break;

                    if (IsAlreadyChange[i, j])
                        continue;

                    foreach(Polygon polygon in polygons)
                    {
                        if (IsPointInPolygon(new Point(i,j),polygon.apex.ToArray()))
                        {
                            GetColor(i,j);
                        }
                    }

                }
            }
        }

        private void Image_Paint(object sender, PaintEventArgs e)
        {
            if(current_mode == BrushMode.Circle && isMouseClicked)
            {
                ApplyCircleFilter();
            }

            using (Bitmap processedBitmap = new Bitmap(newPhoto.GetLength(0), newPhoto.GetLength(1)))
            {
                unsafe
                {
                    BitmapData bitmapData = processedBitmap.LockBits(new Rectangle(0, 0, processedBitmap.Width, processedBitmap.Height), ImageLockMode.ReadWrite, processedBitmap.PixelFormat);

                    int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(processedBitmap.PixelFormat) / 8;
                    int heightInPixels = bitmapData.Height;
                    int widthInBytes = bitmapData.Width * bytesPerPixel;
                    byte* PtrFirstPixel = (byte*)bitmapData.Scan0;

                    Parallel.For(0, heightInPixels, y =>
                    {
                        byte* currentLine = PtrFirstPixel + (y * bitmapData.Stride);
                        for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                        {
                            currentLine[x] = newPhoto[x / 4, y].B;
                            currentLine[x + 1] = newPhoto[x / 4, y].G;
                            currentLine[x + 2] = newPhoto[x / 4, y].R;
                            currentLine[x + 3] = newPhoto[x / 4, y].A;
                        }
                    });
                    processedBitmap.UnlockBits(bitmapData);
                }

                e.Graphics.DrawImage(processedBitmap, 0, 0);

                if (drawCurrentLine)
                    e.Graphics.DrawLine(new Pen(Brushes.Black), current_line.Item1, current_line.Item2);
                foreach (Polygon polygon in polygons)
                {
                    PaintAllPoints(Brushes.Black, polygon, e.Graphics);
                    foreach (var segment in polygon.segments)
                        e.Graphics.DrawLine(new Pen(Brushes.Black), segment.p1, segment.p2);
                }

                if (mouse_point.X != -1 && current_mode == BrushMode.Circle)
                    e.Graphics.DrawEllipse(new Pen(Brushes.Black), mouse_point.X + radius / 2, mouse_point.Y + radius / 2, radius, radius);

                PrepareCharts();
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            choofdlog.FilterIndex = 1;
            choofdlog.Multiselect = false;

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                ImageBitmap = new Bitmap(choofdlog.FileName);
                IsAlreadyChange = new bool[Image.Width, Image.Height];
                polygons.Clear();
                InitializeImage();
                Image.Invalidate();
            }
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_point = new Point(e.X-radius, e.Y-radius);
            Cursor = Cursors.Hand;

            if (current_mode == BrushMode.FirstPoint && e.Button == MouseButtons.Left)
            {
                current_mode = BrushMode.DrawPolygon;
                Point point = new Point(e.Location.X, e.Location.Y);

                current_polygon = new Polygon(point);
                polygons.Add(current_polygon);
                current_point = point;
            }

            else if (current_mode == BrushMode.DrawPolygon && e.Button == MouseButtons.Left)
            {
                previous_point = new Point(e.Location.X, e.Location.Y);
                current_line = ((Point)current_point, (Point)previous_point);
                drawCurrentLine = true;
            }

            Image.Invalidate();
        }

        private void Image_MouseUp(object sender, MouseEventArgs e)
        {
            if (current_mode == BrushMode.DrawPolygon)
            {
                Point next_point = new Point(e.Location.X, e.Location.Y);
                CreateSegment(next_point);
                drawCurrentLine = false;
            }
            else if (current_mode == BrushMode.DeletePolygon)
            {
                (Polygon toDelete, (Point, Point) segment) = GetPolygonWithPointOnSegment(new Point(e.Location.X, e.Location.Y));
                if (toDelete != null)
                {
                    RepairAlreadyChangeTable(toDelete);
                    polygons.Remove(toDelete);
                }
            }
            else if (current_mode == BrushMode.Circle)
            {
                isMouseClicked = false;
                IsAlreadyChange = new bool[Image.Width, Image.Height];
            }

            Image.Invalidate();
        }

        private void Image_MouseDown(object sender, MouseEventArgs e)
        {
            mouse_point = new Point(e.X - radius, e.Y - radius);

            if (current_mode == BrushMode.Circle)
            {
                isMouseClicked = true;
            }

            Image.Invalidate();
        }

        private void Image_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            mouse_point = new Point(-1, -1);

            Image.Invalidate();
        }

        private void AddPolygonButton_Click(object sender, EventArgs e)
        {
            if(!CheckIfDrawEnd())
            {
                MessageBox.Show("Żeby zmienić tryb należy najpierw dokończyć rysowanie", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ModeLabel.Text = "Tryb: Dodaj wielokąt";
            current_mode = BrushMode.FirstPoint;
        }

        private void CircleBrushButton_Click(object sender, EventArgs e)
        {
            if (!CheckIfDrawEnd())
            {
                MessageBox.Show("Żeby zmienić tryb należy najpierw dokończyć rysowanie", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ModeLabel.Text = "Tryb: Pędzel kołowy";
            current_mode = BrushMode.Circle;
        }

        private void DeletePolygonButton_Click(object sender, EventArgs e)
        {
            if (!CheckIfDrawEnd())
            {
                MessageBox.Show("Żeby zmienić tryb należy najpierw dokończyć rysowanie", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ModeLabel.Text = "Tryb: Usuń wielokąt";
            current_mode = BrushMode.DeletePolygon;
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!CheckIfDrawEnd())
            {
                MessageBox.Show("Żeby zasotosować filtry najpierw należy zakończyć rysowanie", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ApplyPolygonFilter();

            Image.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

            for(int i=0; i<myPoints.Count; i++)
            {
                if(myPoints[i] == chartPoint)
                {
                    Point newPoint = new Point(myPoints[i].X, newY);
                    myPoints[i] = newPoint;
                    chartPoint = newPoint;
                    MyFunctionPicture.Invalidate();
                    return;
                }
            }
        }
    }
}
