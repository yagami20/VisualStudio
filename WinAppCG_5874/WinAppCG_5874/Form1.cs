using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace WinAppCG_5874
{
    public partial class Form1 : Form
    {
        Bitmap lienzo = new Bitmap(600, 400);
        int clase, segmentos, repaso;  // OPCION PARA LOS COMBO BOX, CREAR UNA VARIABLE PARA CADA UNO POR EJEMPLO EXAMEN TRANAJO EN CLASE
       
        // var de mouseup, mousedown
        public int opdinamico;
        public double Px, Py, Qx, Qy;

        //vectores para almacenar datos de los vectores y para las curvas de ajuste
        public List<double> puntosx= new List<double>(); // guarda ka coordena de inicio x //desde donde damos clic hasta 
        public List <double> puntosy = new List<double>(); //guarda ka coordena de inicio y //desde donde damos clic hasta 

        // vectores para los puntos del triangulo
        //public List<double> vx = new List<double>();  
        //public List<double> vy = new List<double>();
        public int banderadown = -1, cont;

        //
        int xcor = -1, ycor = -1, xcor2 = -1, ycor2 = -1;
        bool primerclic = false, segundoclic=false;

        //
        Point m_postrazo;
        public Form1()
        {
            InitializeComponent();
        }
        private void cbxInterpolacion_SelectedIndexChanged(object sender, EventArgs e)
        {

            //INTERPOLACIONES
            //SI QUEREMOS QUE LA INTERPOLACION SE VEA PARA ABAJO SE DEBE PONER EN LA CONDICION DE  LOS FOR EN J
            //EJEMPLOS DE INTERPOLACION si ponemos en la condicion j debemos cambiar tambien en el setpixel
            int i, j;
            clase = cbxInterpolacion.SelectedIndex;

            //    Dos colores
            if (clase == 0)
            {
                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 400; j++)
                    {
                        if (i <= 300)
                            lienzo.SetPixel(i, j, Color.Red);

                        else
                            lienzo.SetPixel(i, j, Color.Yellow);
                    }
                }
                ventanaP.Image = lienzo;
            }

            //     Interpolacion(rojo, amarrillo)
            if (clase == 1)
            {
                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 400; j++)
                    {
                        lienzo.SetPixel(i, j, Color.FromArgb((int)(255), (int)(0.425 * i), (int)(0)));
                    }
                }
                ventanaP.Image = lienzo;
            }
            //   Interpolacion(clase)

            if (clase == 2)
            {
                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 400; j++)
                    {
                        lienzo.SetPixel(i, j, Color.FromArgb((int)(0), (int)(-0.095 * i + 255), (int)(0.425 * i)));
                    }
                }
                ventanaP.Image = lienzo;
            }

            //Interpolacion 3 colores(deber)

            if (clase == 3)
            {
                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 400; j++)
                    {
                        if (i <= 300)
                            lienzo.SetPixel(i, j, Color.FromArgb(((int)(0.85 * i)), ((int)((0.19 * i) + 198)), 0));
                        //lienzo.SetPixel(i,j, Color.FromArgb((int)(-0.6375 * (j - 400) + (0.6375 * (j))), (int)(0.6375 * (j)), (int)(0)));
                        // lienzo.SetPixel(i, j, Color.FromArgb((int)(-0.6375 * (j - 400) + (0.6375 * (j))), (int)(0.6375 * (j)), (int)(0)));


                        else
                            lienzo.SetPixel(i, j, Color.FromArgb((int)(-0.85 * (i - 600)), (int)((-0.85 * (i - 600)) + (0.66 * (i - 300))), 0));
                    }
                }
                ventanaP.Image = lienzo;
            }

            // InterpolacionR(rojo, amarrillo)
            if (clase == 4)
            {
                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 400; j++)
                    {
                        if (j <= 200)
                            lienzo.SetPixel(i, j, Color.Red);

                        else
                            lienzo.SetPixel(i, j, Color.Yellow);
                    }
                }
                ventanaP.Image = lienzo;
            }

            // InterpolacionR(rojo, amarrillo)
            if (clase == 5)
            {
                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 400; j++)
                    {
                        if (i <= 300)
                            lienzo.SetPixel(i, j, Color.FromArgb((int)(255 * (i - 0) / 300), (int)((200 * (i - 300) / -300)) + (int)((255 * (i - 0) / 300)), 0));
                        //    lienzo.SetPixel(i,j,Color.FromArgb((int)(0), (int)((20 * (i - 300) / -300)) + (int)((255 * (i) / 300)), (int)((255 * (i - 300) / -300)) + (int)((200 * (i) / 300))));
                        else
                            lienzo.SetPixel(i, j, Color.Yellow);
                    }
                }
                ventanaP.Image = lienzo;
            }
            // Interpolacion repaso 1
            //interpolar para que sea la interpolacion en el centro de las j cambiar en la condicion y en los for
            if (clase == 6)
            {
                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 400; j++)
                    {
                        if (j <= 300)
                            lienzo.SetPixel(i, j, Color.FromArgb((int)(255 * (j - 0) / 300), (int)((200 * (j - 300) / -300)) + (int)((255 * (j - 0) / 300)), 0));
                        //    lienzo.SetPixel(i,j,Color.FromArgb((int)(0), (int)((20 * (i - 300) / -300)) + (int)((255 * (i) / 300)), (int)((255 * (i - 300) / -300)) + (int)((200 * (i) / 300))));
                        else
                            lienzo.SetPixel(i, j, Color.FromArgb((int)(-0.85 * (j - 600)), (int)((-0.85 * (j - 600)) + (0.66 * (j - 300))), 0));

                    }
                }
                ventanaP.Image = lienzo;
            }

            // Interpolacion repaso 2
            //interpolar y que se vea un triangulo 
            if (clase == 7)
            {
                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 400; j++)
                    {
                        if (i <= 300)
                        {
                            if (i > j)//((i != j) && ((i + j) != 600))

                                lienzo.SetPixel(i, j, Color.FromArgb(0, (int)(255 - (10 * i / 300)), (int)(10 + (245 * i / 300))));
                        }
                        else
                        {
                            if (i > j)//(i != j) && ((i + j) != 600))

                                lienzo.SetPixel(i, j, Color.FromArgb((int)((255 * (i - 301)) / 298), (int)(((-245 * (i - 599)) / 298)), (int)(-((235 * i) - 146725) / 298)));

                        }
                    }
                }
                ventanaP.Image = lienzo;
            }


            // bandera del ecuador
            if (clase == 8)
            {
                for (i = 0; i < 600; i++)
                {
                    for (j = 0; j < 400; j++)
                    {
                        if (i <= 300)
                            lienzo.SetPixel(i, j, Color.FromArgb((int)(-0.85 * (i - 300)), (int)(-0.85 * (i - 300)), (int)(0.85 * i)));

                        else
                            lienzo.SetPixel(i, j, Color.FromArgb((int)(0.85 * (i - 300)), 0, (int)(-0.85 * (i - 600))));

                    }
                }
                ventanaP.Image = lienzo;
            }

            if (clase == 9)
            {
                for ( i = 0; i < 400; i++)
                {
                    for ( j = 0; j < 400; j++)
                    {
                        if (i < j)
                        {
                            lienzo.SetPixel(i, j, Color.FromArgb((int)(255), (int)(-0.6375 * (i - 400)), (int)(0)));
                            ventanaP.Image = lienzo;
                        }
                        else
                        {
                            lienzo.SetPixel(i, j, Color.FromArgb((int)(255), (int)(-0.6375 * (j - 400)), (int)(0)));
                            ventanaP.Image = lienzo;
                        }

                    }
                }



            }
            }

        private void encenderPixelesP_Click(object sender, EventArgs e)
        {
            Vector vec = new Vector();
            vec.x0 = 5;
            vec.y0 = 3;
            vec.color0 = Color.Blue;
            vec.encender(lienzo);
            ventanaP.Image = lienzo;

            Vector vec1 = new Vector();
            vec1.x0 = -5;
            vec1.y0 = 5;
            vec1.color0 = Color.Blue;
            vec1.encender(lienzo);
            ventanaP.Image = lienzo;

            Vector vec2 = new Vector();
            vec2.x0 = -2;
            vec2.y0 = -4;
            vec2.color0 = Color.Blue;
            vec2.encender(lienzo);
            ventanaP.Image = lienzo;

            Vector vec3 = new Vector();
            vec3.x0 = 8;
            vec3.y0 = -4;
            vec3.color0 = Color.Blue;
            vec3.encender(lienzo);
            ventanaP.Image = lienzo;

            Vector vec4 = new Vector();
            vec4.x0 = 0;
            vec4.y0 = 0;
            vec4.color0 = Color.Blue;
            vec4.encender(lienzo);
            ventanaP.Image = lienzo;
        }

        private void cbxSegmentos_SelectedIndexChanged(object sender, EventArgs e)
        {
            segmentos = cbxSegmentos.SelectedIndex;
            //  segmento

            if (segmentos == 0)
            {
                segmento sg = new segmento();
                sg.t = 0;
                sg.color0 = Color.FromArgb((int)(255), (int)(0.425 * 600), 0);
                sg.x0 = -1;
                sg.y0 = 3;
                sg.Xf = 5;
                sg.Yf = 2;

                sg.encender(lienzo);
                ventanaP.Image = lienzo;

            }
            //  segmento derecha izquierda

            if (segmentos == 1)
            {

                segmento sg = new segmento();
                sg.t = 0;
                sg.color0 = Color.Black;
                sg.x0 = -8;
                sg.y0 = 5;
                sg.Xf = 0;
                sg.Yf = 0;
                sg.encender(lienzo);
                ventanaP.Image = lienzo;
            }
            //     segmento derecha

            if (segmentos == 2)
            {
                segmento sg = new segmento();
                sg.t = 0;
                sg.color0 = Color.Black;
                sg.x0 = -4.5;
                sg.y0 = 0;
                sg.Xf = 9;
                sg.Yf = 0;
                sg.encender(lienzo);
                ventanaP.Image = lienzo;

            }

            //segmento abajo todo
            if (segmentos == 3)
            {
                segmento sg = new segmento();
                sg.t = 0;
                sg.color0 = Color.Black;
                sg.x0 = -7;
                sg.y0 = 0;
                sg.Xf = -7;
                sg.Yf = -3;

                sg.encender(lienzo);
                ventanaP.Image = lienzo;
            }


            //segmento cuadrante primer
            if (segmentos == 4)
            {
                segmento sg = new segmento();
                
                sg.x0 = 2;
                sg.y0 = 5;
                sg.Xf = 8;
                sg.Yf = 5;
                sg.color0 = Color.Black;

                sg.encender(lienzo);
                ventanaP.Image = lienzo;


            }

        }

        private void circunferencia_Click(object sender, EventArgs e)
        {
            circunferencia cr = new circunferencia();
            cr.rad = 1;
            cr.x0 = 1;
            cr.y0 = 4;
            cr.color0 = Color.Black;
            cr.encender(lienzo);
            ventanaP.Image = lienzo;
        }

        private void lazo_Click(object sender, EventArgs e)
        {
            lazo lz = new lazo();
            lz.x0 = 5;
            lz.y0 = 1;
            lz.rad = 3;
            lz.color0 = Color.Black;
            lz.encender(lienzo);
            ventanaP.Image = lienzo;
        }

        private void Creacionlazo_Click(object sender, EventArgs e)
        {
            lazo l = new lazo();
            double t = 0, dt = 0.01;
            double x0 = 0, y0 = 0;

            do
            {
                l.x0 = (5 * Math.Cos(3 * t)) + x0;
                l.y0 = (5 * Math.Sin(2 * t)) + y0;
                l.color0 = Color.Red;
                l.encender(lienzo);
                System.Threading.Thread.Sleep(4);
                ventanaP.Refresh();
                ventanaP.Image = lienzo;
                t = t + dt;
            } while (t <= (2*Math.PI ));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //derechaizquierda

            segmento sg1 = new segmento();

            sg1.x0 = -7;
            sg1.y0 = 4.38;
            sg1.color0 = Color.Black;

            sg1.Xf = 2;
            sg1.Yf = -2;
            sg1.encender(lienzo);
            ventanaP.Image = lienzo;

            circunferencia cr1 = new circunferencia();
            cr1.rad = 0.5;
            cr1.x0 = -7;
            cr1.y0 = 4.38;
            cr1.color0 = Color.Black;
            cr1.encender(lienzo);
            ventanaP.Image = lienzo;


            lazo lz1 = new lazo();
            lz1.x0 = 2;
            lz1.y0 = -2;
            lz1.rad = 0.5;
            lz1.color0 = Color.Black;
            lz1.encender(lienzo);
            ventanaP.Image = lienzo;

            //hacia abajo

            segmento sg2 = new segmento();

            
            sg2.x0 = -7;
            sg2.y0 = 3;
            sg2.Xf = -7;
            sg2.Yf = -3;
            sg2.color0 = Color.Black;
            sg2.encender(lienzo);
            ventanaP.Image = lienzo;

            circunferencia cr2 = new circunferencia();

            cr2.rad = 0.5;
            cr2.x0 = -7;
            cr2.y0 = -3.5;
            cr2.color0 = Color.Black;
            cr2.encender(lienzo);
            ventanaP.Image = lienzo;

            lazo lz2 = new lazo();
            lz2.rad = 0.5;
            lz2.x0 = -7;
            lz2.y0 = 0;
            lz2.color0 = Color.Black;
            lz2.encender(lienzo);
            ventanaP.Image = lienzo;

            //para la cruz

            segmento sg = new segmento();
            sg.color0 = Color.Black;
            sg.x0 = 3;
            sg.y0 = 4;

            sg.Xf = -3;
            sg.Yf = -5;
            sg.encender(lienzo);
            ventanaP.Image = lienzo;


            ///para encima

            segmento s = new segmento();

            s.x0 = 2;
            s.y0 = 5;
            s.Xf = 8;
            s.Yf = 5;
            s.color0 = Color.Black;
            s.encender(lienzo);
            ventanaP.Image = lienzo;
        }

        private void repasos_SelectedIndexChanged(object sender, EventArgs e)
        {
            repaso = repasos.SelectedIndex;
            //  segmento
            if (repaso == 0)
            {

                //primero hacer la circunferencia

                circunferencia cr = new circunferencia();
                cr.rad = 3;
                cr.x0 = -5;
                cr.y0 = 2;
                cr.tf = cr.tf = (2 * Math.PI);
                cr.color0 = Color.Black;
                cr.encender(lienzo);
                ventanaP.Image = lienzo;

                //despues los segmentos

                segmento sg = new segmento();
                sg.t = 0;
                sg.color0 = Color.Black;
                sg.x0 = cr.x0;    //-5
                sg.y0 = cr.y0 + 3;    //5 
                sg.Xf = cr.x0 - 3;    //-8
                sg.Yf = cr.y0;    //2 
                sg.encender(lienzo);
                ventanaP.Image = lienzo;

                sg.color0 = Color.Black;
                sg.x0 = cr.x0;    //-5
                sg.y0 = cr.y0 + 3;    //5 
                sg.Xf = cr.x0 + 3;    //-2
                sg.Yf = cr.y0;    //2
                sg.t = 0;
                sg.encender(lienzo);
                ventanaP.Image = lienzo;

                sg.color0 = Color.Black;
                sg.x0 = cr.x0 - 3;    //-8
                sg.y0 = cr.y0;    //2
                sg.Xf = cr.x0 + 3;    //-2
                sg.Yf = cr.y0;    //2
                sg.t = 0;
                sg.encender(lienzo);
                ventanaP.Image = lienzo;

            }

            if (repaso == 1)//lazo
            {

                CurvasV lz = new CurvasV();
                lz.opcion = 0;
                lz.x0 = 5;
                lz.y0 = 1;
                lz.rad = 1;

                lz.color0 = Color.Black;
                lz.encenderCurva(lienzo);
                ventanaP.Image = lienzo;
            }


            if (repaso == 2)//margarita
            {
                CurvasV c = new CurvasV();
                c.opcion = 1;
                c.x0 = -5;
                c.y0 = 1;
                c.rad = 1;
                c.color0 = Color.Red;

                c.encenderCurva(lienzo);
                ventanaP.Image = lienzo;
            }


            if (repaso == 3)//asteroide
            {
                CurvasV va = new CurvasV();
                va.opcion = 2;
                va.x0 = -2;
                va.y0 = 1;
                va.rad = 1;

                va.color0 = Color.Red;
                va.encenderCurva(lienzo);
                ventanaP.Image = lienzo;

            }

            if (repaso == 4)//lenmiscat
            {
                CurvasV c = new CurvasV();
                c.opcion = 3;
                c.x0 = 4;
                c.y0 = 1;
                c.rad = 1;
                c.color0 = Color.Red;
                c.encenderCurva(lienzo);
                ventanaP.Image = lienzo;
            }

            if (repaso == 5)//rombo
            {
                CurvasV c = new CurvasV();
                c.opcion = 4;
                c.x0 = 6;
                c.y0 = 3;
                c.rad = 1;

                c.color0 = Color.Red;
                c.encenderCurva(lienzo);
                ventanaP.Image = lienzo;
            }


            if (repaso == 6)
            {
                segmento sg1 = new segmento();
                sg1.t = 0;
                sg1.x0 = -7;
                sg1.y0 = 4.38;
                sg1.Xf = 2;
                sg1.Yf = -2;
                sg1.degradar(lienzo);
                ventanaP.Image = lienzo;


                circunferencia cr1 = new circunferencia();
                cr1.rad = 0.5;
                cr1.x0 = -7;
                cr1.y0 = 4.38;
                cr1.color0 = Color.Black;
                cr1.degradar(lienzo);
                ventanaP.Image = lienzo;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CurvasV c = new CurvasV();
            lenmiscata c1 = new lenmiscata();

            c1.x0 = 4;
            c1.y0 = -2;
            c1.rad = 1;

            c1.color0 = Color.Red;
            c1.encender(lienzo);
            ventanaP.Image = lienzo;

            //MARGARITA primer plano
            c.x0 = 3;
            c.y0 = 3;
            c.rad = 1;
            c.opcion = 1;
            c.color0 = Color.Black;
            c.encenderCurva(lienzo);
            ventanaP.Image = lienzo;

            //LAZO segundo plano

            c.x0 = -5;
            c.y0 = 3;
            c.rad = 1;
            c.opcion = 0;
            c.color0 = Color.Black;
            c.encenderCurva(lienzo);
            ventanaP.Image = lienzo;


            //ASTROIDE tercero
            c.x0 = -7;
            c.y0 = -3;
            c.rad = 1;
            c.opcion = 2;
            c.color0 = Color.Black;
            c.encenderCurva(lienzo);
            ventanaP.Image = lienzo;

            //ROMBO centro
            c.x0 = 0;
            c.y0 = 0;
            c.rad = 1;
            c.opcion = 4;
            c.color0 = Color.Black;
            c.encenderCurva(lienzo);
            ventanaP.Image = lienzo;

        }

        private void plano_Click(object sender, EventArgs e)
        {
            segmento sg = new segmento();
            sg.t = 0;
            sg.color0 = Color.Black;
            sg.x0 = -9;
            sg.y0 = 0;
            sg.Xf = 9;
            sg.Yf = 0;
            sg.encender(lienzo);
            ventanaP.Image = lienzo;

            segmento sg1 = new segmento();
            sg.t = 0;
            sg1.color0 = Color.Black;
            sg1.x0 = 0;
            sg1.y0 = 6;
            sg1.Xf = 0;
            sg1.Yf = -6;
            sg1.encender(lienzo);
            ventanaP.Image = lienzo;
        }

        private void pacman_Click(object sender, EventArgs e)
        {
            circunferencia pac = new circunferencia();

            //t y tf son los radianes
            //x0 y y0 son las coordenadas donde quiero que se ubbique el pacman

            ///cuerpo del pacman
            pac.rad = 2.3;
            pac.t = Math.PI / 6;
            pac.tf = (11 * Math.PI) / 6;
            pac.x0 = 0;
            pac.y0 = 0;

            pac.color0 = Color.Black;
            pac.encender(lienzo);
            ventanaP.Image = lienzo;


            //lineas del pacman

            segmento sg = new segmento();
            sg.t = 0;
            sg.color0 = Color.Black;
            sg.x0 = 0;
            sg.y0 = 0;
            sg.Xf = 2;
            sg.Yf = 1.1;
            sg.encender(lienzo);
            ventanaP.Image = lienzo;

            //lineas del pacman
            sg.t = 0;
            sg.color0 = Color.Black;
            sg.x0 = 0;
            sg.y0 = 0;
            sg.Xf = 2;
            sg.Yf = -1.1;
            sg.encender(lienzo);
            ventanaP.Image = lienzo;

            ///ojo del pacman
            pac.rad = 0.5;
            pac.t = 0;
            pac.tf = (2 * Math.PI);
            pac.x0 = -0.5;
            pac.y0 = 0.9;

            pac.color0 = Color.Black;
            pac.encender(lienzo);
            ventanaP.Image = lienzo;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            circunferencia pac = new circunferencia();

            //t y tf son los radianes
            //x0 y y0 son las coordenadas donde quiero que se ubbique el pacman

            ///cuerpo del pacman
            pac.rad = 2.3;
            pac.t = 0;
            pac.tf = (5 * Math.PI) / 6;
            pac.x0 = 0;
            pac.y0 = 0;
            pac.color0 = Color.Black;
            pac.encender(lienzo);
            ventanaP.Image = lienzo;


            ///cuerpo del pacman
            pac.rad = 2.3;
            pac.t = (7 * Math.PI) / 6;
            pac.tf = (2 * Math.PI); ;
            pac.x0 = 0;
            pac.y0 = 0;
            pac.color0 = Color.Black;
            pac.encender(lienzo);
            ventanaP.Image = lienzo;

            //lineas del pacman

            segmento sg = new segmento();
            sg.t = 0;
            sg.color0 = Color.Black;
            sg.x0 = 0;
            sg.y0 = 0;
            sg.Xf = -2;
            sg.Yf = 1.1;
            sg.encender(lienzo);
            ventanaP.Image = lienzo;

            //lineas del pacman
            sg.t = 0;
            sg.color0 = Color.Black;
            sg.x0 = 0;
            sg.y0 = 0;
            sg.Xf = -2;
            sg.Yf = -1.1;
            sg.encender(lienzo);
            ventanaP.Image = lienzo;

            ///ojo del pacman
            pac.rad = 0.5;
            pac.t = 0;
            pac.tf = (2 * Math.PI);
            pac.x0 = -0.5;
            pac.y0 = 1;

            pac.color0 = Color.Black;
            pac.encender(lienzo);
            ventanaP.Image = lienzo;
        }

        //polinomio de taylor con 3 termiminos sen^2(x)  x=2
        private void btntaylor_Click(object sender, EventArgs e)
        {
            double x = -2;//posicion de la pantalla
            double dx = 0.005;//para que se note la linea
            Vector vec = new Vector();

            do
            {
                vec.x0 = x;

                vec.y0 = ((Math.Pow(Math.Sin(2), 2)) + (2 * (Math.Sin(2)) * (Math.Cos(2)) * (x - 2)) + ((2 * (Math.Pow(Math.Cos(2), 2)) - (Math.Pow(Math.Sin(2), 2))) / 2) * (Math.Pow((x - 2), 2)));
                // vec.y0 = ((Math.Pow(Math.Sin(2), 2)) + 0.069 + 0.99);
                // vec.y0 = (2 + (Math.Pow((x), 2))/4);
                x = x + dx;
                vec.color0 = Color.Blue; // siempre se deben poner
                vec.encender(lienzo);    //siempre se deben poner
                ventanaP.Image = lienzo;  //siempre se deben poner
            } while (x <= 2);
        }

        private void seno_Click(object sender, EventArgs e)
        {
            double x = -6;//inicion del intervalo [-6,6]
            double dx = 0.00005;//para que se note la linea
            Vector vec = new Vector();

            do
            {
                vec.x0 = x;
                vec.y0 = Math.Pow(Math.Sin(x), 2);
                x = x + dx;
                vec.color0 = Color.Blue; // siempre se deben poner
                vec.encender(lienzo);    //siempre se deben poner
                ventanaP.Image = lienzo;  //siempre se deben poner
            } while (x <= 6);
        }

        private void cociente_Click(object sender, EventArgs e)
        {
            //t es igual que x
            Vector V = new Vector();
            Vector W = new Vector();
            double t = -6, dt = 0.005;
            do
            {
                V.x0 = t;
                V.y0 = 1 / (t + 1);
                V.color0 = Color.Green;
                V.encender(lienzo);


                W.x0 = t;
                W.y0 = 1 - t + Math.Pow(t, 2) - Math.Pow(t, 3) + Math.Pow(t, 4);
                W.color0 = Color.Red;
                W.encender(lienzo);
                t = t + dt;
                ventanaP.Image = lienzo;

            } while (t <= 6);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            Vector v = new Vector();
            Vector w = new Vector();
            double t = -6, dt = 0.01;
            do
            {
                v.x0 = t;

                v.y0 = Math.Sqrt(Math.Pow(t, 2) + 1);
                v.color0 = Color.Green;
                v.encender(lienzo);

                w.x0 = t;
                w.y0 = 1 + ((0 * t) / 1) + (1 * Math.Pow(t, 2) / 2) - (3 * Math.Pow(t, 4) / 24);
                //w.Y0 = 1 + ((0 * t) / 1) + (1 * Math.Pow(t, 2) / 2) + (1 * Math.Pow(t, 4) / 24);
                w.color0 = Color.Red;
                w.encender(lienzo);
                t = t + dt;
                ventanaP.Image = lienzo;

            }
            while (t <= 14);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            Vector v = new Vector();
            Vector w = new Vector();
            double t = -6, dt = 0.01;
            do
            {
                v.x0 = t;

                v.y0 = Math.Pow(2, t);
                v.color0 = Color.Green;
                v.encender(lienzo);
                ventanaP.Image = lienzo;

                w.x0 = t;
                w.y0 = (1 + (Math.Log(2) * t) + (Math.Pow(Math.Log(2), 2) * Math.Pow(t, 2)) / 2 + (Math.Pow(Math.Log(2), 3) * Math.Pow(t, 3)) / 6 + (Math.Pow(Math.Log(2), 4) * Math.Pow(t, 4)) / 24 + (Math.Pow(Math.Log(2), 5) * Math.Pow(t, 5)) / 120);
                //w.Y0 = 1 + (Math.Log(2) * t) + ((Math.Pow(Math.Log(2), 2) / 2) * Math.Pow(t, 2)) + ((Math.Pow(Math.Log(2), 3) / 6) * Math.Pow(t, 3)) + ((Math.Pow(Math.Log(2), 4) / 24) * Math.Pow(t, 4));
                w.color0 = Color.Red;
                w.encender(lienzo);

                ventanaP.Image = lienzo;
                t = t + dt;
            } while (t <= 6);
        }

        private void button47_Click(object sender, EventArgs e)
        {
            Vector v = new Vector();
            Vector w = new Vector();
            double t = -1, dt = 0.01;
            do
            {
                v.x0 = t;
                w.y0 = t;
                v.y0 = Math.Log(t + 1);
                v.color0 = Color.Green;
                v.encender(lienzo);
                ventanaP.Image = lienzo;

                w.y0 = t - (Math.Pow(t, 2) / 2) + (Math.Pow(t, 3) / 6) - (Math.Pow(t, 4) / 24);
                w.color0 = Color.Red;
                w.encender(lienzo);
                w.encender(lienzo);
                ventanaP.Image = lienzo;
                t = t + dt;
            } while (t <= 1);
        }

        private void button36_Click(object sender, EventArgs e)
        {

            Vector v = new Vector();
            Vector w = new Vector();
            double t = -1, dt = 0.01;
            do
            {
                v.x0 = t;
                w.x0 = t;
                v.y0 = -Math.Exp(Math.Pow(t, 2));
                v.color0 = Color.Green;
                v.encender(lienzo);
                ventanaP.Image = lienzo;
                w.y0 = -1 - Math.Pow(t, 2);
                w.color0 = Color.Red;
                w.encender(lienzo);

                ventanaP.Image = lienzo;
                t = t + dt;
            } while (t <= 1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //union de la funcion de sen y del polinomio
            double x = -6;//inicion del intervalo [-6,6]
            double dx = 0.00005;//para que se note la linea
            Vector vec = new Vector();

            do
            {
                vec.x0 = x;
                vec.y0 = Math.Pow(Math.Sin(x), 2);
                x = x + dx;
                vec.color0 = Color.Blue; // siempre se deben poner
                vec.encender(lienzo);    //siempre se deben poner
                ventanaP.Image = lienzo;  //siempre se deben poner
            } while (x <= 6);

            x = -5;//posicion de la pantalla para el polinomio
            dx = 0.005;//para que se note la linea
            do
            {
                vec.x0 = x;
                //vec.y0 = (Math.Pow(Math.Sin(2),2)) + ((2*(Math.Sin(2) * Math.Cos(2))*(x-2))/ 1) + (((2 * ( (Math.Pow(Math.Cos(2),2)) - (Math.Pow(Math.Sin(2),2)) ) * (Math.Pow(x-2),2)) / 2);
                vec.y0 = ((Math.Pow(Math.Sin(2), 2)) + (2 * (Math.Sin(2)) * (Math.Cos(2)) * (x - 2)) + ((2 * (Math.Pow(Math.Cos(2), 2)) - (Math.Pow(Math.Sin(2), 2))) / 2) * (Math.Pow((x - 2), 2)));


                x = x + dx;
                vec.color0 = Color.Blue; // siempre se deben poner
                vec.encender(lienzo);    //siempre se deben poner
                ventanaP.Image = lienzo;  //siempre se deben poner
            } while (x <= 5);

        }

        private void button45_Click(object sender, EventArgs e)
        {
            double x = -8;
            double dx = 0.002;
            do
            {
                Vector v = new Vector();
                v.x0 = x;
                v.y0 = Math.Cos(x);
                v.color0 = Color.Green;
                v.encender(lienzo);

                v.color0 = Color.Blue;
                v.y0 = 1 - 0 - Math.Pow(x, 2) / 2 + 0 + Math.Pow(x, 4) / 24 - 0;
                v.encender(lienzo);

                x = x + dx;
                ventanaP.Image = lienzo;
            } while (x <= 8);
        }

        private void button48_Click(object sender, EventArgs e)
        {
            double x = -1;
            double dx = 0.002;
            do
            {
                Vector v = new Vector();
                v.x0 = x;
                v.y0 = Math.Tan(x);
                v.color0 = Color.Green;
                v.encender(lienzo);

                v.color0 = Color.Blue;
                v.y0 = 0 + x + 0 + Math.Pow(x, 3) / 3 + 0 + 2 * Math.Pow(x, 5) / 15;
                v.encender(lienzo);

                x = x + dx;
                ventanaP.Image = lienzo;
            } while (x <= 1);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            double x = -1;
            double dx = 0.002;
            do
            {
                Vector v = new Vector();
                v.x0 = x;
                v.y0 = Math.Sin(x);
                v.color0 = Color.Green;
                v.encender(lienzo);

                v.color0 = Color.Blue;
                v.y0 = 0 + x - 0 - (Math.Pow(x, 3)) / 6 + 0 + (Math.Pow(x, 5)) / 120;
                v.encender(lienzo);

                x = x + dx;
                ventanaP.Image = lienzo;
            } while (x <= 5);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            double x = -1;
            double dx = 0.002;
            do
            {
                Vector v = new Vector();
                v.x0 = x;
                v.y0 = Math.Pow(0.5, x);
                v.color0 = Color.Green;
                v.encender(lienzo);

                v.color0 = Color.Blue;
                v.y0 = 1 - x * Math.Log(2) + (0.5 * Math.Pow(x, 2) * Math.Pow(Math.Log(2), 2)) - (0.166 * Math.Pow(x, 3) * Math.Pow(Math.Log(2), 3)) + (0.0416 * Math.Pow(x, 4) * Math.Pow(Math.Log(2), 4)) - (0.00833 * Math.Pow(x, 5) * Math.Pow(Math.Log(2), 5));
                v.encender(lienzo);

                x = x + dx;
                ventanaP.Image = lienzo;
            } while (x <= 1);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            double x = -5;
            double dx = 0.002;
            do
            {
                Vector v = new Vector();
                v.x0 = x;
                v.y0 = Math.Pow(0.5, x);
                v.color0 = Color.Green;
                v.encender(lienzo);

                v.color0 = Color.Blue;
                v.y0 = 1 - x * Math.Log(2) + (0.5 * Math.Pow(x, 2) * Math.Pow(Math.Log(2), 2)) - (0.166 * Math.Pow(x, 3) * Math.Pow(Math.Log(2), 3)) + (0.0416 * Math.Pow(x, 4) * Math.Pow(Math.Log(2), 4)) - (0.00833 * Math.Pow(x, 5) * Math.Pow(Math.Log(2), 5));
                v.encender(lienzo);

                x = x + dx;
                ventanaP.Image = lienzo;
            } while (x <= 5);
        }

        private void button46_Click(object sender, EventArgs e)
        {
            double x = -1;
            double dx = 0.002;
            do
            {
                Vector v = new Vector();
                v.x0 = x;
                v.y0 = Math.Log(x + 1);
                v.color0 = Color.Green;
                v.encender(lienzo);

                v.color0 = Color.Blue;
                v.y0 = 0 + x - Math.Pow(x, 2) / 2 + Math.Pow(x, 3) / 3 - Math.Pow(x, 4) / 4 + Math.Pow(x, 5) / 5;
                v.encender(lienzo);

                x = x + dx;
                ventanaP.Image = lienzo;
            } while (x <= 1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int r2 = 3;
            for (int i = 0; i < 15; i++)
            {
                poligono p = new poligono();

                p.x0 = 3;
                p.y0 = -1;
                p.rad = r2;
                p.nl = 5;
                r2 = r2 + 1;

                p.color0 = Color.Black;
                p.encender(lienzo);
                ventanaP.Image = lienzo;


            }

        }

        private void encenderP_Click(object sender, EventArgs e)
        {
            //GRAFICAR UN PIXEL EN LA PANTALLA 
            lienzo.SetPixel(0, 0, Color.BlueViolet); //para ponerle el color en el pixel
            ventanaP.Image = lienzo;
        }

        private void button8_Click(object sender, EventArgs e)
        {
       
                

        }

        private void button5_Click(object sender, EventArgs e)
        {
            int r2 = 1 ;
            for (int i = 0; i < 10; i++)
            {
                poligono p = new poligono();

                p.x0 = 3;
                p.y0 = -1;
                p.rad = r2;
                p.nl = 5;
                r2 = r2 + 1;
                p.color0 = Color.Black;
                p.encender(lienzo);
                ventanaP.Image = lienzo;

            }

            segmento sg = new segmento();
            
            sg.x0 = 3;
            sg.y0 = -1;
            sg.Xf = 3;
            sg.Yf = 3;
            sg.color0 = Color.Black;
            sg.encender(lienzo);
            ventanaP.Image = lienzo;
            
            sg.color0 = Color.Black;
            sg.x0 = 3;
            sg.y0 = -1;
            sg.Xf = -0.5;
            sg.Yf = 1;
            sg.encender(lienzo);
            ventanaP.Image = lienzo;

          
            sg.x0 = 3;
            sg.y0 = -1;
            sg.Xf = -0.5;
            sg.Yf = -3;
            sg.color0 = Color.Black;
            sg.encender(lienzo);
            ventanaP.Image = lienzo;


            sg.color0 = Color.Black;
            sg.x0 = 3;
            sg.y0 = -1;
            sg.Xf = -0.5;
            sg.Yf = -3;
            sg.encender(lienzo);
            ventanaP.Image = lienzo;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           switch (cbxdinamico.SelectedIndex)
                {
                    case 0:
                    { //segmento
                        opdinamico = 0;
                        break;
                     }

                case 1:
                    { //circunferencia
                        opdinamico = 1;
                        break;
                    }


                case 2:
                    { //lazo
                        opdinamico = 2;
                        break;
                    }


                case 3:
                    { //poligono
                        opdinamico = 3;
                        break;
                    }                    
            }

        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (puntosx != null && puntosy != null && cont == 3)
            {
                segmento s = new segmento();
                s.triangulo(lienzo, puntosx[0], puntosy[0], puntosx[1], puntosy[1], puntosx[2], puntosy[2]);
                ventanaP.Image = lienzo;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxdinamico.SelectedIndex)
            {
                case 0:
                    { //segmento
                        opdinamico = 0;
                        break;
                    }

                case 1:
                    { //circunferencia
                        opdinamico = 1;
                        break;
                    }


                case 2:
                    { //lazo
                        opdinamico = 2;
                        break;
                    }

                 case 3:
                    { //poligono
                        opdinamico = 3;
                        break;
                    }


            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            opdinamico = 3;
        }

        private void nlados_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (puntosx != null && puntosy != null && cont == 3)
            {
                segmento s = new segmento();
                s.color0 = Color.White;
                s.triangulo(lienzo, puntosx[0], puntosy[0], puntosx[1], puntosy[1], puntosx[2], puntosy[2]);
                ventanaP.Image = lienzo;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            opdinamico = 4;
            //vx.Clear();
            //vy.Clear();
            puntosx.Clear();
            puntosy.Clear();
            cont = 0;
            banderadown = 1;

            
        }

        private void ventanaP_MouseUp(object sender, MouseEventArgs e)
        {
            //mouseup permite coger la coordenadas finales

            if (xcor != -1 && ycor != -1)
            {
                xcor2 = e.X;
                ycor2 = e.Y;
                LMatematica lm = new LMatematica();
                lm.procesoCarta(xcor, ycor, out Px, out Py);
                lm.procesoCarta(xcor2, ycor2, out Qx, out Qy);

                segundoclic = true;
                primerclic = false;

                double distancia;//circunferencia
                segmento s = new segmento();
                circunferencia cr = new circunferencia();
                lazo lz = new lazo();
                poligono p = new poligono();

                switch (opdinamico)
                {
                    case 0:
                        {//segmento
                            s.x0 = Px;
                            s.y0 = Py;
                            s.Xf = Qx;
                            s.Yf = Qy;
                            s.color0 = Color.Black;
                            s.encender(lienzo);
                            ventanaP.Image = lienzo;
                            break;
                        }
                    case 1:
                        {//circunferencia
                            distancia = Math.Sqrt(Math.Pow((Qx - Px), 2 + Math.Pow((Qy - Py), 2)));
                            cr.rad = distancia;
                            cr.x0 = Px;
                            cr.y0 = Py;
                            cr.color0 = Color.Black;
                            cr.encender(lienzo);
                            ventanaP.Image = lienzo;
                            break;
                        }
                    case 2:
                        {//lazo
                            distancia = Math.Sqrt(Math.Pow((Qx - Px), 2 + Math.Pow((Qy - Py), 2)));
                            lz.x0 = Px;
                            lz.y0 = Py;
                            lz.Xf = Qx; //
                            lz.Yf = Qy; //
                            lz.rad = distancia;
                            lz.color0 = Color.Black;
                            lz.encender(lienzo);
                            ventanaP.Image = lienzo;
                            break;
                        }
                    case 3:
                        {//poligono
                            distancia = Math.Sqrt(Math.Pow((Qx - Px), 2 + Math.Pow((Qy - Py), 2)));
                            int nLados = int.Parse(nlados.Text);

                            p.x0 = Px;
                            p.y0 = Py;
                            p.rad = distancia;
                            p.nl = nLados;
                            p.color0 = Color.Black;
                            p.encender(lienzo);
                            ventanaP.Image = lienzo;

                            break;

                        }
                  }

            }
        }

        private void ventanaP_MouseDown(object sender, MouseEventArgs e)
        {
            m_postrazo = e.Location;
            LMatematica lm = new LMatematica();
            int xPC = e.X;
            int yPc = e.Y;
            xcor = xPC;
            ycor = yPc;
            double x, y;

            lm.procesoCarta(xPC, yPc, out x, out y);

            switch (opdinamico)
            {

                case 4:
                    {
                        puntosx.Add(x);
                        puntosy.Add(y);
                        cont++;

                        circunferencia c = new circunferencia();
                        c.x0 = x;
                        c.y0 = y;
                        c.rad = 0.15;
                        c.color0 = Color.Black;
                        c.encender(lienzo);
                        ventanaP.Image = lienzo;
                        break;
                    }
        }
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 600; i++)
            {
                for (int j = 0; j < 400; j++)
                {
                    lienzo.SetPixel(i, j, Color.White); //pintar  todo el cuador de gray
                }
            }
            ventanaP.Image = lienzo;
        }

        private void button4_Click(object sender, EventArgs e)
        {
        
                poligono p = new poligono();
                p.x0 = 0;
                p.y0 = 0;
                p.rad = 3;
                p.nl = 10;
                p.color0 = Color.Black;
                p.encender(lienzo);
                ventanaP.Image = lienzo;
            
        }
    }

       

       
    }

