using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WinFormAppCompuGrafica
{
    class ClassCircunferencia:Vector
    {
        public double radio;
        public double t1 = 0, dt1 = 0.001;

        public override void Encender(Bitmap lienzo)
        {
            Vector vec = new Vector();
            double t = t1, dt = dt1;
            do
            {
                vec.X0 = radio * Math.Cos(t) + X0;
                vec.Y0 = radio * Math.Sin(t) + Y0;
                vec.color0 = color0;
                vec.Encender(lienzo);
                t = t + dt;

            } while (t <= 2 * Math.PI);
        }
        public void Encender1(Bitmap lienzo)
        {
            Vector vec = new Vector();
            double t = (Math.PI / 6), dt = 0.01;
            do
            {
                vec.X0 = radio * Math.Cos(t) + X0;
                vec.Y0 = radio * Math.Sin(t) + Y0;
                vec.color0 = color0;
                vec.Encender(lienzo);
                t = t + dt;

            } while (t <= 1.83 * Math.PI);
        }
    }
}
