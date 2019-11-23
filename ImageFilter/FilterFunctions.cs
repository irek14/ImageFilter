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
        int[] myFunction = new int[256];

        private int MyFunction(int x)
        {
            return myFunction[x];
        }

        private int Negation(int x)
        {
            return 255 - x;
        }

        private int ChangeBrightness(int x, int delta)
        {
            int result = x + delta;

            if (result < 0)
                result = 0;

            if (result > 255)
                result = 255;

            return result;
        }

        private int Contrast(int x, int delta1, int delta2)
        {
            if (x <= delta1)
                return 0;

            if (x >= delta2)
                return 255;

            return 255 / (delta2 - delta1) * (x - delta1);
        }

        private int GammCorrection(int x, double gamma)
        {
            double newX = (double)x / 255.0;
            double result = Math.Pow(newX, 1.0 / gamma) * 255.0;

            return (int)result;
        }
    }
}
