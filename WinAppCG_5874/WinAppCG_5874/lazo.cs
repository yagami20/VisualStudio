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
    class lazo:circunferencia
    {
        //Destructor
        ~lazo() { }
        public override void encender(Bitmap lienzo)
        {
            double t = 0, dt = 0.001;

            do
            {
                Vector vector = new Vector();
                vector.x0 = x0 + rad * Math.Cos(3 * t);
                vector.y0 = y0 + rad * Math.Sin(2 * t);
                vector.color0 = color0;
                vector.encender(lienzo);
                t = t + dt;
            } while (t <= (Math.PI * 2));
        }
    }
}
