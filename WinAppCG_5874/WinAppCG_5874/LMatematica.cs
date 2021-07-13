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
    class LMatematica
    {
        //Limites de la pantalla que vamos a visualizar del picturebox
        // deben ser enteros (Coordenadas de computador)
        public int SPx = 0;
        public int SPy = 0;
        public int SQx = 600;
        public int SQy = 400;



        //Puntos reales para trabajar en el programa.
        //coordenadas de la pantalla real

        public static double Px = -9;
        public static double Py = -6;
        public static double Qx = 9;
        public static double Qy = 6;


        //Constructor sin Parametros
        public LMatematica() { }

        //Destructor 

        ~LMatematica() { }


        //PROCEDIMIENTO PANTALLA
        public void procedimientoPantalla(double x, double y, out int xP, out int yP)
        {
            xP = (int)((((SPx - SQx) / (Px - Qx)) * (x - Px)) + SPx);
            yP = (int)((((SQy - SPy) / (Py - Qy)) * (y - Py)) + SQy);

        }

        //PUNTOS REAlES DE LA PANTALLA
        public void procesoCarta(int xP, int yP, out double x, out double y)
        {
            x = (((xP - SPx) * (Px - Qx)) / (SPx - SQx)) + Px;
            y = (((yP - SQy) * (Py - Qy)) / (SQy - SPy)) + Py;

        }
    }
}
