using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        Graphics g;
        private Bitmap map;
        private List<Bitmap> bit;
        
        
        List<int> delX = new List<int>();
        List<int> delY = new List<int>();
        List<int> delNum = new List<int>();
        List<double> size = new List<double>();
        
        int i = -1;
        int j = 0;
        int n = 3;
        double q = 1;
        double R = 15, r = 50;   // радиусы
        double alpha = 0;        // поворот
        bool check = true;


        public Form1()
        {
            InitializeComponent();
            SetSize();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        private void SetSize()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            map = new Bitmap(rectangle.Width, rectangle.Height);
            g = Graphics.FromImage(map);
            bit = new List<Bitmap>();
            bit.Add(new Bitmap(map));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            g = Graphics.FromImage(map);
            delX.Add(e.X);
            delY.Add(e.Y);
            i++;
            PointF[] points = new PointF[2 * n + 1];
            double a = alpha, da = Math.PI / n, l;
            for (int k = 0; k < 2 * n + 1; k++)
            {
                l = (k % 2 == 0 ? r : R) *q;
                points[k] = new PointF((float)(e.X + l * Math.Cos(a)), (float)(e.Y + l * Math.Sin(a)));
                a += da;
            }

            g.FillPolygon(Brushes.Pink, points);
            g.DrawLines(Pens.DeepPink, points);
            
            size.Add(q);

            pictureBox1.Image = map;
            bit.Add(new Bitmap(map));

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (bit.Count - 1 <= 0)
            {

            }
            else
            {
                bit.RemoveAt(bit.Count - 1);
                map = (Bitmap)bit[bit.Count - 1].Clone();
                j = i;
                if (!check)
                {
                    for (int p = 0; p <= delNum.Count - 1; p++)
                    {
                        if (!(j == delNum[p]))
                        {
                            
                        }
                        else
                        {
                            j = delNum[p] - 1;
                        }
                    }
                }
                else
                {
                    check = false;
                }
                delNum.Add(j);


                pictureBox1.Image = map;

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            q = 0.3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            q = 0.7;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            q = 1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            q = 1.5;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            q = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (delNum.Count - 1 < 0) 
            {

            }
            else
            {
                g = Graphics.FromImage(map);


                PointF[] points = new PointF[2 * n + 1];
                double a = alpha, da = Math.PI / n, l;
                for (int k = 0; k < 2 * n + 1; k++)
                {
                    l = (k % 2 == 0 ? r : R)*size[delNum[delNum.Count-1]];
                    points[k] = new PointF((float)(delX[delNum[delNum.Count - 1]] + l *Math.Cos(a)), (float)(delY[delNum[delNum.Count - 1]] + l * Math.Sin(a)));
                    a += da;
                }
                g.FillPolygon(Brushes.Pink, points);
                g.DrawLines(Pens.DeepPink, points);
                
                


                delNum.RemoveAt(delNum.Count - 1);
                
              
                pictureBox1.Image = map;
                bit.Add(new Bitmap(map));
            }
        }
    }
}
