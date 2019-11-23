using ImageFilter.Properties;
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
        const int PhotoWidth = 467;
        const int PhotoHeight = 731;
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

        bool[,] IsAlreadyChange = new bool[PhotoWidth, PhotoHeight];
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

            InitializeMyFunction();

            InitializeImage();
            PrepareMyFunctionChart();
            Image.Invalidate();
        }

        private void InitializeMyFunction()
        {
            Random rnd = new Random(456);
            int startValue = 0;
            int endValue = rnd.Next(50,70);
            double currentValue = 0;
            for (int i = 0; i < 17; i++)
            {
                int startX = i * 15;
                for(int j=0; j<15; j++)
                {
                    myFunction[startX + j] = (int)currentValue;
                    currentValue += ((double)(endValue - startValue))/15.0;
                }
                startValue = (int)currentValue;

                if(i<5 || i>=10)
                {
                    int minValue = endValue + 10;
                    int maxValue = endValue + 50;
                    if (minValue > 255)
                        minValue = 255;
                    if (maxValue > 255)
                        maxValue = 255;

                    endValue = rnd.Next(minValue, maxValue);
                }
                else
                {
                    int minValue = endValue - 50;
                    int maxValue = endValue - 10;
                    if (minValue < 0)
                        minValue = 0;
                    if (maxValue < 0)
                        maxValue = 0;

                    endValue = rnd.Next(minValue, maxValue);
                }
            }
        }

        private void InitializeImage()
        {
            photo = new Color[PhotoWidth, PhotoHeight];
            newPhoto = new Color[PhotoWidth, PhotoHeight];

            for (int i = 0; i < PhotoWidth; i++)
            {
                for (int j = 0; j < PhotoHeight; j++)
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
            for(int i=0; i<PhotoWidth; i++)
            {
                for(int j=0; j<PhotoHeight; j++)
                {
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
                R = ChangeBrightness(newPhoto[i, j].R, 40);
                G = ChangeBrightness(newPhoto[i, j].G, 40);
                B = ChangeBrightness(newPhoto[i, j].B, 40);
            }
            else if (ContrastRadio.Checked)
            {
                R = Contrast(newPhoto[i, j].R, 50, 200);
                G = Contrast(newPhoto[i, j].G, 50, 200);
                B = Contrast(newPhoto[i, j].B, 50, 200);
            }
            else if (GammaRadio.Checked)
            {
                R = GammCorrection(newPhoto[i, j].R, 0.7);
                G = GammCorrection(newPhoto[i, j].G, 0.7);
                B = GammCorrection(newPhoto[i, j].B, 0.7);
            }

            newPhoto[i, j] = Color.FromArgb(R, G, B);
            IsAlreadyChange[i, j] = true;
        }

        private void ApplyPolygonFilter()
        {
            for (int i = 0; i < PhotoWidth; i++)
            {
                for (int j = 0; j < PhotoHeight; j++)
                {
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

            using (Bitmap processedBitmap = new Bitmap(PhotoWidth, PhotoHeight))
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
                    e.Graphics.DrawEllipse(new Pen(Brushes.Black), mouse_point.X + radius/2, mouse_point.Y + radius/2, radius, radius);

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
                IsAlreadyChange = new bool[PhotoWidth, PhotoHeight];
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

            current_mode = BrushMode.FirstPoint;
        }

        private void CircleBrushButton_Click(object sender, EventArgs e)
        {
            if (!CheckIfDrawEnd())
            {
                MessageBox.Show("Żeby zmienić tryb należy najpierw dokończyć rysowanie", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            current_mode = BrushMode.Circle;
        }

        private void DeletePolygonButton_Click(object sender, EventArgs e)
        {
            if (!CheckIfDrawEnd())
            {
                MessageBox.Show("Żeby zmienić tryb należy najpierw dokończyć rysowanie", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

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
    }
}
