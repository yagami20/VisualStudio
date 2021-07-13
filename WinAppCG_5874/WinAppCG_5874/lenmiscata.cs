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
    class lenmiscata:Vector
    {
        public double rad, t = 0, dt = 0.01;

        public override void encender(Bitmap lienzo)
        {

            do
            {
                Vector V = new Vector();
                V.x0 = rad * (((6 * Math.Cos(t)) - (Math.Cos(t * 6))) / 4) + x0;
                V.y0 = rad * ((6 * Math.Sin(t) - Math.Sin(t * 6)) / 4) + y0;
                V.color0 = color0;
                V.encender(lienzo);
                t = t + dt;
            } while (t <= (2 * Math.PI));


        }
    }
}
