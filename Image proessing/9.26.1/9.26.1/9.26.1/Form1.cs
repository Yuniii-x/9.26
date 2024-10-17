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

namespace _9._26._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //Read & Create a new bitmap
            Bitmap bmpOrg = new Bitmap("lena.jpg");
            Bitmap bmpGray = new Bitmap(bmpOrg.Width, bmpOrg.Height, PixelFormat.Format24bppRgb);

            int nHeight = bmpOrg.Height;  // get image width & height
            int nWidth = bmpOrg.Width;

            for (int y = 0; y < nHeight; y++)  // process each scan line
            {
                for(int x = 0; x < nWidth; x++)  //process each pixel in the Current scan line
                {
                    Color Cpix = bmpOrg.GetPixel(x, y);
                    int GrayValue;  //the Gary value of a pixel

                    GrayValue = (int)(Cpix.R *0.2999 + Cpix.G*0.587 + Cpix.B*0.114) ; //Convert BGR to gray
                    bmpGray.SetPixel(x,y,Color.FromArgb(GrayValue, GrayValue,GrayValue));
                }
            }

            pictureBox1.Image = bmpOrg;  //dispaly bitmaps
            pictureBox2.Image = bmpGray;

            bmpGray.Save("Gray24Lena.png", ImageFormat.Png);  //save the gray image
        }
    }
}
