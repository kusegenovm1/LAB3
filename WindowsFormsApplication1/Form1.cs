using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private int xMin = -10;
        private int xMax = 10;
        private int yMin = -10;
        private int yMax = 10;

        private int dx, dy;
        private int x0, y0;

        private float x11, x12, y11, y12;
        private int x1, x2, y1, y2;

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private int arrowSize = 7;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxXmin.Text, out xMin)) MessageBox.Show("Некорректное значение X min");
            if (!int.TryParse(textBoxXmax.Text, out xMax)) MessageBox.Show("Некорректное значение X max");
            if (!int.TryParse(textBoxYmin.Text, out yMin)) MessageBox.Show("Некорректное значение Y min");
            if (!int.TryParse(textBoxYmax.Text, out yMax)) MessageBox.Show("Некорректное значение Y max");
            if (!int.TryParse(textBox2.Text, out x1)) MessageBox.Show("Некорректное значение X1");
            if (!int.TryParse(textBox4.Text, out y1)) MessageBox.Show("Некорректное значение Y1");
            if (!int.TryParse(textBox1.Text, out x2)) MessageBox.Show("Некорректное значение X2");
            if (!int.TryParse(textBox3.Text, out y2)) MessageBox.Show("Некорректное значение Y2");
            panel1.Refresh();
        }


        private void panel1_Resize(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            dx = panel1.Width / (xMax - xMin);
            dy = panel1.Height / (yMax - yMin);
            x0 = -dx * xMin; //300
            y0 = dy * yMax; //300

            // сетка вертикальная
            for (int x = xMin; x <= xMax; x++)
            {
                e.Graphics.DrawLine(Pens.LightGray, x0 + x * dx, 0, x0 + x * dx, panel1.Height);
            }
            // сетка горизонтальная
            for (int y = yMin; y <= yMax; y++)
            {
                e.Graphics.DrawLine(Pens.LightGray, 0, y0 - y * dy, panel1.Width, y0 - y * dy);
            }


            // Draw line to screen.
            // e.Graphics.DrawLine(Pens.Black, point1, point2);
            //e.Graphics.DrawLine(Pens.Red, x1 * dx - xMax, y1 * dy + yMin, x2 * dx - xMax, y2 * dy + yMin);


            /*for (float i = -panel1.Width; i < panel1.Width; i++)
            {
                //y=x^2
                x11 = x12;
                y11 = y12;
                x12 = i;
                y12 = x12 * x12;


                e.Graphics.DrawLine(Pens.Green, x0 + x11 * dx, y0 - y11 * dy, x0 + x12 * dx, y0 - y12 * dy);
            }

            e.Graphics.DrawLine(Pens.Red, x0 + x1 * dx, y0 - y1 * dy, x0 + x2 * dx, y0 - y2 * dy);*/

            //textBox5 - угол F           (ничего)
            //textBox6 - радиус r         (ничего)
            //- оборотов - o 

            double xp, yp, F, r, pi, p, sh;
            int o;

            o = 2;
            pi = 3.1415926535;
            r = 0;
            F = 0;
            //F = p;
            double x11 = 0;
            double x12 = 0;
            double y11 = 0;
            double y12 = 0;

            sh = (o * pi)/(o * 180);

            for (int i = 0; i < o*180; i++)
            {
                r = (r + sh);          //(r + sh) - это число p
                F = i;

                xp = r * Math.Cos(F * Math.PI / 180);
                yp = r * Math.Sin(F * Math.PI / 180);

                x11 = x12;
                y11 = y12;
                x12 = xp;
                y12 = yp;
                e.Graphics.DrawLine(Pens.Aqua, (float)(x0 + x11 * dx), (float)(y0 - y11 * dy), (float)(x0 + x12 * dx), (float)(y0 - y12 * dy));
               
            }


            F = double.Parse(textBox5.Text);
            r = double.Parse(textBox6.Text);
            xp = r * Math.Cos(F * Math.PI / 180);
            yp = r * Math.Sin(F * Math.PI / 180);
            e.Graphics.DrawLine(Pens.Aqua, x0 + x1 * dx, y0 - y1 * dy, (float)(x0 + xp * dx), (float)(y0 - yp * dy));


            // ось абсцисс
            e.Graphics.DrawLine(Pens.Black, 0, y0, panel1.Width, y0); //y 
            // ось ординат
            e.Graphics.DrawLine(Pens.Black, x0, 0, x0, panel1.Height); //x

            // стрелки
            e.Graphics.FillPolygon(Brushes.Black, new PointF[] { new PointF(panel1.Width, y0), new PointF(panel1.Width - arrowSize, y0 - arrowSize), new PointF(panel1.Width - arrowSize, y0 + arrowSize) });
            e.Graphics.FillPolygon(Brushes.Black, new PointF[] { new PointF(x0, 0), new PointF(x0 - arrowSize, arrowSize), new PointF(x0 + arrowSize, arrowSize) });

            // линия через две точки

            // подписи
            Font f = new Font("Arial", 12);
            e.Graphics.DrawString("Y", f, Brushes.Black, x0 + 10, 0);
            e.Graphics.DrawString("X", f, Brushes.Black, panel1.Width - 25, y0 + 10);

        }
    }
}


