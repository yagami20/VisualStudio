using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WinFormAppCompuGrafica
{
    class ClassLazo:Vector
    {
        public double radio;
        public double t1 = 0, dt1 = 0.001;

        public override void Encender(Bitmap lienzo)
        {
            Vector vec = new Vector();
            double t = t1, dt = dt1;
            do
            {
                vec.X0 = radio * Math.Cos(3*t) + X0;
                vec.Y0 = radio * Math.Sin(2*t) + Y0;
                vec.color0 = color0;
                vec.Encender(lienzo);
                t = t + dt;

            } while (t <= 2 * Math.PI);
        }
    }
}
