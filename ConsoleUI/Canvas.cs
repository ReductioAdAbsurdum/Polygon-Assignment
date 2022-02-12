using LogicCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    internal class Canvas
    {

        public Canvas()
        {
            Console.WindowHeight = 60;    
            Console.WindowWidth = 120;
            Console.Clear();
        }

        public void DrawPolygon(Polygon polygon) 
        {
            foreach (Vector2D vertix in polygon.GetVertices())
            {
                DrawPoint(vertix, ConsoleColor.Blue);
            }
        }

        public void DrawPoint(Vector2D point, ConsoleColor color) 
        {
            Console.ForegroundColor = color;

            Console.CursorTop = (int)Math.Floor(point.Y * 14) + 20;
            Console.CursorLeft = (int)Math.Floor(point.X * 29) + 44;
            Console.Write('█');
            Console.CursorLeft = (int)Math.Floor(point.X * 29) + 45;
            Console.Write('█');
        }
    }
}
