﻿using ImageFilter.Properties;
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

        private void ApplyCircleFilter()
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

                    double d = Math.Sqrt((i - mouse_point.X - radius) * (i - mouse_point.X - radius) + (j - mouse_point.Y - radius) * (j - mouse_point.Y - radius));
                    if (d < radius / 2)
                    {
                        GetColor(i, j);
                    }
                }
            }
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

                    foreach (Polygon polygon in polygons)
                    {
                        if (IsPointInPolygon(new Point(i, j), polygon.apex.ToArray()))
                        {
                            GetColor(i, j);
                        }
                    }

                }
            }
        }

        private void GetColor(int i, int j)
        {
            int R = 0, G = 0, B = 0;
            if (NoFilterRadio.Checked)
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

        private void Image_Paint(object sender, PaintEventArgs e)
        {
            if (current_mode == BrushMode.Circle && isMouseClicked)
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

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_point = new Point(e.X - radius, e.Y - radius);
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
    }
}
