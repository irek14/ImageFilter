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

        private void ChartTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void AddPolygonButton_Click(object sender, EventArgs e)
        {
            if(!CheckIfDrawEnd())
            {
                MessageBox.Show("Żeby zmienić tryb należy najpierw dokończyć rysowanie", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IsAlreadyChange = new bool[Image.Width, Image.Height];
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
    }
}
