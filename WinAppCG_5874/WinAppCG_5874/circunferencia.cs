using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppCG_5874
{
    class circunferencia:Vector
    {
        public double rad;
        public double t;
        public double tf;


        public double Xf;
        public double Yf;

        //Constructor sin Parametros
        public circunferencia() { }



        //Constructor con Parametros
        public circunferencia(double x, double y, double xf, double yf, double rad, Color color1)
        {

            this.x0 = x;
            this.y0 = y;
            this.t = xf;
            this.tf = yf;
            this.color0 = color1;
            this.rad = rad;
        }

        //Destructor 
        ~circunferencia() { }

        public override void encender(Bitmap lienzo)
        {
            double t=0,dt = 0.001;

            Vector vector = new Vector();

            do
            {
                vector.x0 = x0 + (rad * Math.Cos(t));
                vector.y0 = y0 + (rad * Math.Sin(t));
                vector.color0 = color0;
                vector.encender(lienzo);
                t = t + dt;
            } while (t <= 2*Math.PI);
        }

        //public virtual void encenderMetamorfosis(double wz, Bitmap lienzo)
        //{
        //    Vector v = new Vector();
        //    double t = 0, dt = 0.003;
        //    while (t <= 2 * Math.PI)
        //    {

        //        v.x0 = x0 + rad * Math.Cos(t * ((3 * (wz - 8) / -10) + ((wz + 2) / 10)));
        //        v.y0 = y0 + rad * Math.Sin(t * ((2 * (wz - 8) / -10) + ((wz + 2) / 10)));

        //        v.encender(lienzo);
        //        t += dt;

        //    }

        //}



        public void degradar(Bitmap lienzo)
        {
            Vector v = new Vector();
            double t = 0, dt;

            dt = 0.001;
            do
            {
                v.x0 = x0 + rad * Math.Cos(t);
                v.y0 = y0 + rad * Math.Sin(t);
                v.color0 = Color.FromArgb(255, (int)(20 * t), 0);
                v.encender(lienzo);

                t = t + dt;
            }
            while (t <= (2 * Math.PI));


        }
    }
}
