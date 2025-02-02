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

        private (Polygon, (Point, Point)) GetPolygonWithPointOnSegment(Point p)
        {
            foreach (var polygon in polygons)
            {
                foreach (var segment in polygon.segments)
                {
                    if (GetDistanceFromLine(segment, p) <= 3 && IsPointBetween(p, segment))
                        return (polygon, segment);
                }
            }
            return (null, (new Point(), new Point()));
        }

        private double GetDistanceFromLine((Point a, Point b) segment, Point p)
        {
            return Math.Abs((segment.b.X - segment.a.X) * (segment.a.Y - p.Y) - (segment.a.X - p.X) * (segment.b.Y - segment.a.Y)) /
                    Math.Sqrt(Math.Pow(segment.b.X - segment.a.X, 2) + Math.Pow(segment.b.Y - segment.a.Y, 2));
        }

        private bool IsPointBetween(Point p, (Point p1, Point p2) segment)
        {
            int minX = segment.p2.X, maxX = segment.p1.X, minY = segment.p2.Y, maxY = segment.p1.Y;

            if (segment.p2.X > segment.p1.X)
            {
                minX = segment.p1.X;
                maxX = segment.p2.X;
            }

            if (segment.p2.Y > segment.p1.Y)
            {
                minY = segment.p1.Y;
                maxY = segment.p2.Y;
            }

            return p.X >= minX - 3 && p.X <= maxX + 3 && p.Y >= minY - 3 && p.Y <= maxY + 3;
        }

        private void RepairAlreadyChangeTable(Polygon polygon)
        {
            var apex = polygon.apex.ToArray();
            for (int i = 0; i < Image.Width; i++)
            {
                for (int j = 0; j < Image.Height; j++)
                {
                    if (IsPointInPolygon(new Point(i, j), apex))
                    {
                        IsAlreadyChange[i, j] = false;
                    }
                }
            }
        }
    }
}
