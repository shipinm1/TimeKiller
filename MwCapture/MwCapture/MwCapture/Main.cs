using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MwCapture
{
    
    public partial class Main : Form
    {
        int y = 0;
        public Main()
        {
            InitializeComponent();
            Program1.SizeMode = PictureBoxSizeMode.StretchImage;
            //Program1.Dispose();
            Program2.SizeMode = PictureBoxSizeMode.StretchImage;
            Program3.SizeMode = PictureBoxSizeMode.StretchImage;
            
            
        }

        private Bitmap Get_source()
        {
            Size e = Screen.PrimaryScreen.Bounds.Size;
            Bitmap img = new Bitmap(e.Width, e.Height);
            using (Graphics g = Graphics.FromImage(img))
            {
                g.CopyFromScreen(0, 0, 0, 0, e);
            }
            //y += 1;
            //Debug.WriteLine(img.Size);
            return img;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Bitmap temp = Get_source();
            Program1.Image = temp;
            //Program1.Image = null;
            //temp.Dispose();
            Program2.Image = Get_source();
            Program3.Image = Get_source();
            //y += 1;
            //Debug.WriteLine(y);
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void pauseButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
