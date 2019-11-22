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

        BrushMode current_mode = BrushMode.Circle;
        int radius = 60;

        enum BrushMode { Circle, FirstPoint, DrawPolygon, DeletePolygon };

        public MainForm()
        {
            InitializeComponent();

            InitializeImage();
            Image.Invalidate();
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

            for (int i=0; i<ImageBitmap.Width && i<PhotoWidth; i++)
            {
                for(int j=0; j<ImageBitmap.Width && j<PhotoHeight; j++)
                {
                    R[newPhoto[i, j].R]++;
                    G[newPhoto[i, j].G]++;
                    B[newPhoto[i, j].B]++;
                }
            }

            Chart Chart0 = new Chart();
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

                RChart.Series["Seria 1"].ChartArea = "Color R";
                GChart.Series["Seria 1"].ChartArea = "Color G";
                BChart.Series["Seria 1"].ChartArea = "Color B";
            }
        }

        private void ChartTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Image_Paint(object sender, PaintEventArgs e)
        {
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
                    e.Graphics.DrawEllipse(new Pen(Brushes.Black), mouse_point.X, mouse_point.Y, radius, radius);

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
            mouse_point = new Point(e.X-radius/2, e.Y-radius/2);
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
                    polygons.Remove(toDelete);
                }
            }

            Image.Invalidate();
        }

    }
}
