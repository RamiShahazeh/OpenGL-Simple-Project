using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;
using OpenTK.Input;

namespace OpenGL
{
    class Program : GameWindow
    {
        public static string TITLE = " Graphics Lab 1";

        public static int WIDTH = 400;
        public static int HEIGHT = 400;
        public static float x_rotate = 0;
        public static double x_translate = 0;
        public static double y_translate = 0;
        public static double scale = 1;

        public Program() : base(WIDTH, HEIGHT, GraphicsMode.Default, TITLE) { }


        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);

        }


        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

        }


        protected override void OnUpdateFrame(FrameEventArgs e)
        {

            if(Keyboard[Key.A])
            {
                Console.WriteLine("A is Pressed");
            }

            if (Mouse[MouseButton.Right])
            {
                x_rotate -= 0.1f;
            }

            if (Mouse[MouseButton.Left])
            {
                x_rotate += 0.1f;
            }

            if (Keyboard[Key.Left])
            {
                x_translate -= 0.001;
            }

            if (Keyboard[Key.Right])
            {
                x_translate += 0.001;
            }
            if (Keyboard[Key.Up])
            {
                y_translate += 0.001;
            }
            if (Keyboard[Key.Down])
            {
                y_translate -= 0.001;
            }

            if (Keyboard[Key.Plus])
            {
                scale += 0.001;
            }
            if (Keyboard[Key.Minus])
            {
                scale -= 0.001;
            }
            if(Mouse[MouseButton.Left])
            {
                Console.WriteLine("(" + Mouse.X + "," + Mouse.Y + ")");
            }

            base.OnUpdateFrame(e);
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.ClearColor(Color4.LightBlue);
            GL.LoadIdentity();

            GL.Clear(ClearBufferMask.ColorBufferBit);

            /* Second Homework */
/*
            GL.Rotate(x_rotate, Vector3.UnitZ);
            GL.Translate(x_translate, y_translate, 0);
            GL.Scale(scale, scale, 0);

            GL.Begin(BeginMode.Lines);


            GL.Color3(0.0,1.0,0.0);
            GL.Vertex3(-0.8, 0.8, 0);

            GL.Color3(1.0, 1.0,1.0);
            GL.Vertex3(0.0, 0.8, 0);

            GL.End();*/
             

           /* first homework */

            DrawRec(0.45f, 0, Color4.Brown);
            DrawTri(0.5f, 0.4f, Color4.Green);
            DrawCircle(-0.5f, 0.5f, 0.4f, Color4.Yellow);


            SwapBuffers();
        }
        public static void DrawCircle(float x, float y, float radius, Color4 c)
        {
            GL.Begin(BeginMode.TriangleFan);
            GL.Color4(c);

            GL.Vertex2(x, y);
            for (int i = 0; i < 360; i++)
            {
                GL.Vertex2(x + Math.Cos(i) * radius, y + Math.Sin(i) * radius);
            }

            GL.End();
        }

        public static void DrawTri(float x, float y, Color4 c)
        {
            GL.Begin(BeginMode.Triangles);
            GL.Color4(c);

            GL.Vertex2(x, y);
            x = x - 0.4f;
            y = y - 0.4f;
            GL.Vertex2(x, y);
            x = x + 0.8f;
            GL.Vertex2(x, y);

            GL.End();
        }


        public static void DrawRec (float x, float y, Color4 c)
        {
            GL.Begin(BeginMode.Quads);
            GL.Color4(c);

            GL.Vertex2(x, y);

            x = x + 0.1f;

            GL.Vertex2(x, y);

            y = y - 0.5f;

            GL.Vertex2(x, y);

            x = x - 0.1f;

            GL.Vertex2(x, y);

            GL.End();

        
        }

        static void Main(string[] args)
        {
            Program myGameWin = new Program();
            myGameWin.Run();

        }



    }
}


