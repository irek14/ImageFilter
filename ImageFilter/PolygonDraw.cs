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
        private void PaintAllPoints(Brush brush, Polygon polygon, Graphics graph)
        {
            foreach (var apex in polygon.apex)
            {
                try
                {
                    graph.FillRectangle(brush, apex.X - 2, apex.Y - 2, 4, 4);
                }
                catch (Exception e)
                {

                }
            }
        }

        private bool GetNotCompletedPolygon()
        {
            foreach (var polygon in polygons)
            {
                for (int i = 0; i < polygon.segments.Count; i++)
                {
                    if (polygon.segments[i].p2 != polygon.segments[(i + 1) % polygon.segments.Count].p1)
                    {
                        current_polygon = polygon;
                        return false;
                    }
                }
            }
            return true;
        }


        private void CreateSegment(Point next_point)
        {
            if (current_point == next_point) return;

            if (CheckIfStartPoint(next_point))
                next_point = current_polygon.start_point;

            current_polygon.segments.Add(((Point)current_point, next_point));
            current_polygon.apex.Add(next_point);

            previous_point = null;

            current_point = next_point;

            if (next_point == current_polygon.start_point)
            {
                bool end = true;
                for (int i = 0; i < current_polygon.segments.Count; i++)
                {
                    if (current_polygon.segments[i].p2 != current_polygon.segments[(i + 1) % current_polygon.segments.Count].p1)
                    {
                        end = false;
                        break;
                    }
                }

                if (end)
                {
                    current_polygon.apex.RemoveAt(current_polygon.apex.Count - 1);
                    ResetVariables();
                }
            }
        }

        private void ResetVariables()
        {
            current_point = null;
            previous_point = null;
            current_mode = BrushMode.FirstPoint;
        }

        private bool CheckIfStartPoint(Point p1)
        {
            if (Math.Abs(current_polygon.start_point.X - p1.X) <= 5 && Math.Abs(current_polygon.start_point.Y - p1.Y) <= 5)
                return true;

            return false;
        }

        private bool CheckIfDrawEnd()
        {
            if (polygons.Count == 0)
                return true;

            Polygon last = polygons.Last();

            if(last.start_point == last.segments.Last().p2)
            {
                return true;
            }

            return false;
        }
    }
}
