using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    public partial class Puzzle : Form
    {
        Image img;
        Image[] imgarray;
        List<int> idxarray = new List<int>();
        public Puzzle()
        {
            InitializeComponent();
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear_pBox();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                img = Image.FromFile(openFileDialog1.FileName);

            }
            pictureBox10.Image = resizeImage(img, new Size(375, 452));
            img = resizeImage(img, new Size(3 * 175, 3 * 192));
            sliceImage();
            idxarray.Clear();
            Losuj();
        }

        private void sliceImage()
        {
            imgarray = new Image[9];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var index = i * 3 + j;
                    imgarray[index] = new Bitmap(75, 82);
                    var graphics = Graphics.FromImage(imgarray[index]);
                    graphics.DrawImage(img, new Rectangle(0, 0, 75, 82), new Rectangle(i * 175, j * 192, 175, 192), GraphicsUnit.Pixel);
                }
            }
        }

        private void Losuj()
        {
            Random r = new Random();
            int idx;
            do
            {
                idx = r.Next(9);
            }
            while (idxarray.Contains(idx) && idxarray.Count < 9);
            idxarray.Add(idx);
            pictureBox11.Image = imgarray[idx];
        }

        private void picturebox_Click(object sender, EventArgs e)
        {
            PictureBox tmp = (PictureBox)sender;
            if (tmp.Image == null)
            {
                tmp.Image = pictureBox11.Image;
                if (idxarray.Count < 9)
                {
                    Losuj();

                }
                else
                {
                    pictureBox11.Image = null;
                    if(pictureBox1.Image == imgarray[0] && pictureBox2.Image == imgarray[1] && pictureBox3.Image == imgarray[2] && pictureBox4.Image == imgarray[3] && pictureBox5.Image == imgarray[4] && pictureBox6.Image == imgarray[5] && pictureBox7.Image == imgarray[6] && pictureBox8.Image == imgarray[7] && pictureBox9.Image == imgarray[8])
                    {
                        MessageBox.Show("Brawo! Udało Ci się poprawnie ułożyć puzzle!");
                    }
                    else
                    {
                        MessageBox.Show("Niestety, nie udało Ci się poprawnie ułożyć puzzli. Spróbuj ponownie!");
                        clear_pBox();
                        idxarray.Clear();
                        Losuj();
                    }
                }
            }
        }
        private void clear_pBox()
        {
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            pictureBox3.Image = null;
            pictureBox4.Image = null;
            pictureBox5.Image = null;
            pictureBox6.Image = null;
            pictureBox7.Image = null;
            pictureBox8.Image = null;
            pictureBox9.Image = null;
        }
        private void Puzzle_Load(object sender, EventArgs e)
        {
            this.pictureBox1.Click += new System.EventHandler(this.picturebox_Click);
            this.pictureBox2.Click += new System.EventHandler(this.picturebox_Click);
            this.pictureBox3.Click += new System.EventHandler(this.picturebox_Click);
            this.pictureBox4.Click += new System.EventHandler(this.picturebox_Click);
            this.pictureBox5.Click += new System.EventHandler(this.picturebox_Click);
            this.pictureBox6.Click += new System.EventHandler(this.picturebox_Click);
            this.pictureBox7.Click += new System.EventHandler(this.picturebox_Click);
            this.pictureBox8.Click += new System.EventHandler(this.picturebox_Click);
            this.pictureBox9.Click += new System.EventHandler(this.picturebox_Click);
        }
    }
}
