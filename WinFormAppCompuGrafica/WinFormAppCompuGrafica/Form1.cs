using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormAppCompuGrafica
{
    public partial class Ventana : Form
    {
        public Ventana()
        {
            InitializeComponent();
            lienzo = new Bitmap(600, 400);

            map[0] = Color.Black;
            map[1] = Color.Navy;
            map[2] = Color.Green;
            map[3] = Color.Aqua;
            map[4] = Color.Red;
            map[5] = Color.Purple;
            map[6] = Color.Maroon;
            map[7] = Color.LightGray;
            map[8] = Color.DarkGray;
            map[9] = Color.Blue;
            map[10] = Color.Lime;
            map[11] = Color.Silver;
            map[12] = Color.Teal;
            map[13] = Color.Fuchsia;
            map[14] = Color.Yellow;
            map[15] = Color.White;            
        }

        Bitmap lienzo;

        //Definicion de la Paletas
        Color[] map = new Color[16];
        Color[] map1 = new Color[16];
        Color[] map2 = new Color[16];
        Color[] map3 = new Color[16];
        Color[] map4 = new Color[16];
        Color[] map5 = new Color[16];

        //variables dinamicas
        public double px, py, qx, qy, p;
        public int Caso;
        int contadorSier = 0;


        private void btnEncenderPixel_Click(object sender, EventArgs e)
        {
            int x = 300, y = 200;

            lienzo.SetPixel(x, y, Color.Yellow);
            VentanaP.Image = lienzo;

        }

        private void VentanaP_Click(object sender, EventArgs e)
        {

        }

       

        

        private void button1_Click(object sender, EventArgs e)
        {
            int i, j;
            for (i = 0; i < 300; i++)
            {
                for (j = 0; j < 400; j++)
                {
                    lienzo.SetPixel(i, j, Color.Red);
                    VentanaP.Image = lienzo;
                }
            }
            for (i = 300; i < 600; i++)
            {
                for (j = 0; j < 400; j++)
                {
                    lienzo.SetPixel(i, j, Color.Yellow);
                    VentanaP.Image = lienzo;
                }
            }
        }

        private void bttDegradacionColor_Click(object sender, EventArgs e)
        {
            int i, j;
            for (i = 0; i < 600; i++)
            {
                for (j = 0; j < 400; j++)
                {
                    lienzo.SetPixel(i, j, Color.FromArgb(255, (int)(0.425 * i), 0));
                    VentanaP.Image = lienzo;
                }
            }
        }

        private void bttDeber_Click(object sender, EventArgs e)
        {
            int i, j;
            for (i = 0; i < 600; i++)
            {
                for (j = 0; j < 400; j++)
                {
                    lienzo.SetPixel(i, j, Color.FromArgb(0, (int)(-0.425 * (i - 600) + 0.33 * (i)), (int)(0.425 * i)));
                    VentanaP.Image = lienzo;
                }
            }
        }

        private void bttnDeber2_Click(object sender, EventArgs e)
        {
            int i, j;
            for (i = 0; i < 300; i++)
            {
                for (j = 0; j < 400; j++)
                {
                    lienzo.SetPixel(i, j, Color.FromArgb(0, (int)(0.425 * i), (int)(-0.33 * (i - 600) + 0.425 * (i))));
                    VentanaP.Image = lienzo;

                }
            }

            for (i = 300; i < 600; i++)
            {
                for (j = 0; j < 400; j++)
                {
                    lienzo.SetPixel(i, j, Color.FromArgb(0, (int)(-0.425 * (i - 600)), (int)(-0.425 * (i - 600) + 0.3333 * (i))));
                    VentanaP.Image = lienzo;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i, j;
            for (i = 0; i < 600; i++)
            {
                for (j = 0; j < 400; j++)
                {
                    {
                        if (i <= 450)
                        {

                            lienzo.SetPixel(i, j, Color.FromArgb((int)(-0.41111 * (i - 450)), (int)(-0.23778 * (i - 450)), (int)(0.13333 * (i + 450))));
                            VentanaP.Image = lienzo;
                        }
                        else
                        {
                            lienzo.SetPixel(i, j, Color.FromArgb((int)(0.89333 * (i - 150)), (int)(-0.71333 * (i - 150)), (int)(-0.60667 * (i - 150))));
                            VentanaP.Image = lienzo;
                        }
                    
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Vector v = new Vector();
            v.X0 = 0;
            v.Y0 = 0;
            v.color0 = Color.Red;
            v.Encender(lienzo);
            VentanaP.Image = lienzo;
            v.X0 = 5;
            v.Y0 = 3;
            v.color0 = Color.Red;
            v.Encender(lienzo);
            VentanaP.Image = lienzo;
            v.X0 = -2;
            v.Y0 = -1;
            v.color0 = Color.Red;
            v.Encender(lienzo);
            VentanaP.Image = lienzo;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Segmento s = new Segmento();
            s.X0 = -9;
            s.Y0 = 0;
            s.xf = 9;
            s.yf = 0;
            s.color0 = Color.Red;
            s.Encender(lienzo);

            s.X0 = 0;
            s.Y0 = -6;
            s.xf = 0;
            s.yf = 6;
            s.color0 = Color.Red;
            s.Encender(lienzo);

            s.X0 = 5;
            s.Y0 = 4;
            s.xf = -5;
            s.yf = -4;
            s.color0 = Color.Blue;
            s.Encender(lienzo);

            s.X0 = -5;
            s.Y0 = 4;
            s.xf = 5;
            s.yf = -4;
            s.color0 = Color.Blue;
            s.Encender(lienzo);

            s.X0 = -6;
            s.Y0 = 4;
            s.xf = -6;
            s.yf = -4;
            s.color0 = Color.Blue;
            s.Encender(lienzo);
            VentanaP.Image = lienzo;
        }

        private void button5_Click(object sender, EventArgs e)
        {

            ClassCircunferencia c = new ClassCircunferencia();
            c.X0 = 1;
            c.Y0 = 1;
            c.color0 = Color.Aquamarine;
            c.radio = 1;
            c.Encender(lienzo);
            VentanaP.Image = lienzo;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Segmento s = new Segmento();
            s.X0 = -9;
            s.Y0 = 0;
            s.xf = 9;
            s.yf = 0;
            s.color0 = Color.Red;
            s.Encender(lienzo);
            VentanaP.Image = lienzo;

        }

        private void VentanaP_MouseMove(object sender, MouseEventArgs e)
        {
            Point mouseDownLocation = new Point(e.X, e.Y);
            LMatematica.ProcesoCarta(mouseDownLocation.X, mouseDownLocation.Y, out qx, out qy);
            double x, y;
            x = Math.Round(qx, 2);
            y = Math.Round(qy, 2);
        }

        private void VentanaP_MouseDown(object sender, MouseEventArgs e)
        {
            LMatematica.ProcesoCarta(e.X, e.Y, out px, out py);
        }

        private void cbPoligono_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ClassLazo c = new ClassLazo();
            c.X0 = 1;
            c.Y0 = 1;
            c.color0 = Color.Aquamarine;
            c.radio = 1;
            c.Encender(lienzo);
            VentanaP.Image = lienzo;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ClasspPoligono P0 = new ClasspPoligono();
            P0.X0 = 3;
            P0.Y0 = -1;
            P0.radio = 4;
            P0.nl = 5;
            P0.color0 = Color.Aquamarine;
            P0.Encender(lienzo);
            VentanaP.Image = lienzo;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void VentanaP_MouseUp(object sender, MouseEventArgs e)
        {
            Point mouseDownLocation = new Point(e.X, e.Y);
            LMatematica.ProcesoCarta(mouseDownLocation.X, mouseDownLocation.Y, out qx, out qy);
            p = Math.Pow((Math.Pow((px - qx), 2) + Math.Pow((py - qy), 2)), 0.5);


            LMatematica.ProcesoCarta(e.X, e.Y, out qx, out qy);

            if (chRecta.Checked == true)
            {
                Segmento seg = new Segmento();
                seg.X0 = px;
                seg.Y0 = py;
                seg.xf = qx;
                seg.yf = qy;
                seg.color0 = Color.Blue;
                seg.Encender(lienzo);
                VentanaP.Image = lienzo;

            }

            if (chCircunferencia.Checked == true)
            {
                ClassCircunferencia c = new ClassCircunferencia();
                c.X0 = px;
                c.Y0 = py;
                c.radio = p;
                c.color0 = Color.BlueViolet;
                c.Encender(lienzo);
                VentanaP.Image = lienzo;

            }

            if (chLazo.Checked == true)
            {
                ClassLazo c = new ClassLazo();
                c.X0 = px;
                c.Y0 = py;
                c.color0 = Color.Aquamarine;
                c.radio = p;
                c.Encender(lienzo);
                VentanaP.Image = lienzo;

            }

            if (cbPoligono.Text == "5 lados")
            {
                ClasspPoligono P0 = new ClasspPoligono();
                P0.X0 = px;
                P0.Y0 = py;
                P0.radio = p;
                P0.nl = 5;
                P0.color0 = Color.Aquamarine;
                P0.Encender(lienzo);
                VentanaP.Image = lienzo;
            }

            if (cbPoligono.Text == "6 lados")
            {
                ClasspPoligono P0 = new ClasspPoligono();
                P0.X0 = px;
                P0.Y0 = py;
                P0.radio = p;
                P0.nl = 6;
                P0.color0 = Color.Aquamarine;
                P0.Encender(lienzo);
                VentanaP.Image = lienzo;
            }

            if (cbPoligono.Text == "7 lados ")
            {
                ClasspPoligono P0 = new ClasspPoligono();
                P0.X0 = px;
                P0.Y0 = py;
                P0.radio = p;
                P0.nl = 7;
                P0.color0 = Color.Aquamarine;
                P0.Encender(lienzo);
                VentanaP.Image = lienzo;
            }

            if (cbPoligono.Text == "8 lados ")
            {
                ClasspPoligono P0 = new ClasspPoligono();
                P0.X0 = px;
                P0.Y0 = py;
                P0.radio = p;
                P0.nl = 8;
                P0.color0 = Color.Aquamarine;
                P0.Encender(lienzo);
                VentanaP.Image = lienzo;
            }

            if (cbPoligono.Text == "9 lados")
            {
                ClasspPoligono P0 = new ClasspPoligono();
                P0.X0 = px;
                P0.Y0 = py;
                P0.radio = p;
                P0.nl = 9;
                P0.color0 = Color.Aquamarine;
                P0.Encender(lienzo);
                VentanaP.Image = lienzo;
            }

            if (cbPoligono.Text == "10 lados")
            {
                ClasspPoligono P0 = new ClasspPoligono();
                P0.X0 = px;
                P0.Y0 = py;
                P0.radio = p;
                P0.nl = 10;
                P0.color0 = Color.Aquamarine;
                P0.Encender(lienzo);
                VentanaP.Image = lienzo;
            }
        }
    }
}
