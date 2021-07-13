using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WinFormAppCompuGrafica
{
    class ClasspPoligono : ClassCircunferencia
    {
        public int nl = 0;
        public double alfa = 0, beta = 0;

        public override void Encender(Bitmap lienzo)
        {
            Segmento objS = new Segmento();
            double alfa, beta;
            int i;
            alfa = 2 * Math.PI / nl;
            beta = 0;
            objS.color0 = color0;
            for (i = 1; i <= nl; i++)
            {
                objS.X0 = X0 + radio * Math.Sin(beta);
                objS.Y0 = Y0 + radio * Math.Cos(beta);
                objS.xf = X0 + radio * Math.Sin(beta + alfa);
                objS.yf = Y0 + radio * Math.Cos(beta + alfa);
                objS.Encender(lienzo);
                beta = beta + alfa;
            }
        }
    }
}
