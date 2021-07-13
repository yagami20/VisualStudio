using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormAppCompuGrafica
{
    class LMatematica
    {
        //limites de la pantalla que vamos a visualizar del picturebox
        public static int Sx1 = 0;
        public static int Sx2 = 600;
        public static int Sy1 = 0;
        public static int Sy2 = 400;
        //coordenadas de la pantalla real
        public static double x1 = -9;
        public static double x2 = 9;
        public static double y1 = -6;
        public static double y2 = 6;
        //procedimiento pantalla
        public static void ProcedimientoPantalla(double x, double y, out int xP, out int yP)
        {
            xP = (int)(((Sx1 - Sx2) / (x1 - x2)) * (x - x1)) + Sx1;
            yP = (int)(((Sy1 - Sy2) / (y2 - y1)) * (y - y2)) + Sy1;
        }
        //puntos reales de la pantalla
        public static void ProcesoCarta(int px, int py, out double x, out double y)
        {
            x = (((px - Sx2) * (x1 - x2)) / (Sx1 - Sx2)) + x2;
            y = (((py - Sy2) * (y2 - y1)) / (Sy1 - Sy2)) + y1;
        }
    }
}
