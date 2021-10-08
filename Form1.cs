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
        public Puzzle()
        {
            InitializeComponent();
        }
        Image img;
        int imgPartIndex = 0;
        int[] usedParts;

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                img = new Bitmap(openFileDialog1.FileName);
                img = resizeImage(img, new Size(3 * 195, 3 * 175));
                pictureBox1.Image = img;

            }
            sliceImage(img);
        }
        private void sliceImage(Image img)
        {
            var imgArray = new Image[9];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var index = i * 3 + j;
                    imgArray[index] = new Bitmap(195, 175);
                    var graphics = Graphics.FromImage(imgArray[index]);
                    graphics.DrawImage(img, new Rectangle(0, 0, 195, 175), new Rectangle(i * 195, j * 175, 195, 175), GraphicsUnit.Pixel);
                    graphics.Dispose();
                }
            }
        }
/*        private void randomIndex()
        {
            Random r = new Random();
            do
            {
                imgPartIndex = r.Next(0, 9);
            }
            while (!usedParts.Contains(imgPartIndex)){

            }
        }
*/
    }
}
