using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment01Question01
{
    public partial class Form1 : Form
    {
        Rotate rotateObject = new Rotate();
        OpenFileDialog ofd = new OpenFileDialog();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select Image File";
            ofd.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rotateObject.LoadOriginalImage(ofd.FileName);
                string picPath = ofd.FileName.ToString();
                pictureBox1.ImageLocation = picPath;
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image img = pictureBox1.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            img.Save("rotateImageBy90.jpg");
            pictureBox2.ImageLocation = "rotateImageBy90.jpg";
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ofd.Title = "Select Image File";
            ofd.Filter = "Images (*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|" + "All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                rotateObject.LoadOriginalImage(ofd.FileName);
                string picPath = ofd.FileName.ToString();
                pictureBox3.ImageLocation = picPath;
                pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            String sAngle = comboBox1.Text.ToString();
            float fAngle = float.Parse(sAngle);

            Image img = pictureBox3.Image;
            Bitmap bitmap = rotateObject.RotateImage(img, fAngle);
            bitmap.Save("rotateImageBy" + sAngle +".jpg");
            pictureBox4.ImageLocation = "rotateImageBy" + sAngle +".jpg";
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Select angle";
            comboBox1.Items.Add("20");
        }

    }
}
