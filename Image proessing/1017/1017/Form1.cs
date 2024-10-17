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

namespace _1017
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
            Bitmap bmpOrg = new Bitmap("mjq.png");
            Bitmap bmpGray = new Bitmap(bmpOrg.Width, bmpOrg.Height, PixelFormat.Format8bppIndexed);

            unsafe // must set allow unsafe code in project, for direct access pixels
            {
                BitmapData bmpOrgData = bmpOrg.LockBits(new Rectangle(0, 0, bmpOrg.Width,bmpOrg.Height),ImageLockMode.ReadOnly, bmpOrg.PixelFormat);
                BitmapData bmpGrayData = bmpGray.LockBits(new Rectangle(0, 0, bmpGray.Width, bmpGray.Height),
                    ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmpOrg.PixelFormat) / 8; // get bytes per pixel
                int nHeight = bmpOrgData.Height;
                int nWidth = bmpOrgData.Width;

            }
        }
    }
}
