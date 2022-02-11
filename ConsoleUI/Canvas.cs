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
            Console.WindowHeight = 30;    
            Console.WindowWidth = 60;
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

            Console.CursorTop = (int)Math.Floor(point.Y * 14) + 14;
            Console.CursorLeft = (int)Math.Floor(point.X * 29) + 29;
            Console.Write('█');
            Console.CursorLeft = (int)Math.Floor(point.X * 29) + 30;
            Console.Write('█');
        }
    }
}
