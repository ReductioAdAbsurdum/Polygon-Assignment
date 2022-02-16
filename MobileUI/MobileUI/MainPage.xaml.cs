using PolygonApp.Droid.Logic.Backend;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace PolygonApp
{
    public partial class MainPage : ContentPage
    {
        private enum DrawMode 
        {
            Dot,
            Vertice
        }

        private double canvasBorderX = 1070;
        private double canvasBorderY = 1310;
        private DrawMode drawMode = DrawMode.Vertice;
        private Polygon polygon = new Polygon();
        private List<Vector2D> verticesHistory = new List<Vector2D>();
        private List<Vector2D> dots = new List<Vector2D>();


        public MainPage()
        {
            InitializeComponent();
        }

        private void dotMode_button_Clicked(object sender, EventArgs e)
        {

            drawMode = DrawMode.Dot;
            dotMode_button.BackgroundColor = Color.Yellow;

            verticeMode_button.BackgroundColor = Color.LightGray;
        }
        private void verticeMode_button_Clicked(object sender, EventArgs e)
        {
            drawMode = DrawMode.Vertice;
            verticeMode_button.BackgroundColor = Color.Yellow;

            dotMode_button.BackgroundColor = Color.LightGray;
        }

        private void undo_button_Clicked(object sender, EventArgs e)
        {
            int count = verticesHistory.Count;

            if (count == 0) 
            {
                return;
            }

            polygon.RemoveVertice(verticesHistory[count - 1]);
            verticesHistory.RemoveAt(count - 1);

            canvasView.InvalidateSurface();
        }
        private void clear_button_Clicked(object sender, EventArgs e)
        {
            polygon.ClearVertices();
            dots.Clear();
            
            canvasView.InvalidateSurface();
        }


        private void canvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKSurface surface = e.Surface;           
            SKCanvas canvas = surface.Canvas;
           
            SKPaint goodDotPaint = new SKPaint()
            {
                Color = SKColors.Green
            };
            SKPaint badDotPaint = new SKPaint()
            {
                Color = SKColors.Red
            };
            SKPaint verticePaint = new SKPaint()
            {
                Color = SKColors.Blue
            };
            SKPaint linePaint = new SKPaint()
            {
                Color = SKColors.Black,
                StrokeWidth = 3
                
            };
            SKPaint badLinePaint = new SKPaint() 
            {
                Color = SKColors.Red,
                StrokeWidth = 3
            };

            canvas.Clear(SKColors.LightGray);

            


            // Draws lines of polygon
            Vector2D[] vertices = polygon.GetVertices();
            for (int i = 0; i < vertices.Length - 1; i++)
            {
                if (polygon.IsConvex())
                {
                    canvas.DrawLine(new SKPoint((float)vertices[i].X, (float)vertices[i].Y), new SKPoint((float)vertices[i + 1].X, (float)vertices[i + 1].Y), linePaint);
                }
                else 
                {
                    canvas.DrawLine(new SKPoint((float)vertices[i].X, (float)vertices[i].Y), new SKPoint((float)vertices[i + 1].X, (float)vertices[i + 1].Y), badLinePaint);
                }
            }
            if (vertices.Length > 2)
            {
                if (polygon.IsConvex())
                {
                    canvas.DrawLine(new SKPoint((float)vertices[vertices.Length - 1].X, (float)vertices[vertices.Length - 1].Y), new SKPoint((float)vertices[0].X, (float)vertices[0].Y), linePaint);
                }
                else 
                {
                    canvas.DrawLine(new SKPoint((float)vertices[vertices.Length - 1].X, (float)vertices[vertices.Length - 1].Y), new SKPoint((float)vertices[0].X, (float)vertices[0].Y), badLinePaint);
                }
            }

            // Draws vertices of polygon
            foreach (Vector2D v in vertices)
            {
                canvas.DrawCircle((float)v.X, (float)v.Y, 7, verticePaint);
            }

            //Draws all dots
            foreach (Vector2D dot in dots)
            {
                if (Evaluator.IsInside(polygon, dot))
                {
                    canvas.DrawCircle((float)dot.X, (float)dot.Y, 7, goodDotPaint);
                }
                else 
                {
                    canvas.DrawCircle((float)dot.X, (float)dot.Y, 7, badDotPaint);
                }
            }

        }

        private void canvasView_Touch(object sender, SKTouchEventArgs e)
        {
            if (e.Location.X < 0 || e.Location.Y < 0 || e.Location.X > canvasBorderX || e.Location.Y > canvasBorderY)
            {
                return;
            }

            ProcessUserInput(new Vector2D(e.Location.X, e.Location.Y));

            canvasView.InvalidateSurface();
        }
        private void add_button_Clicked(object sender, EventArgs e)
        {
            if (double.TryParse(xCoordinate_entry.Text, out double x) && double.TryParse(yCoordinate_entry.Text, out double y))
            {
                if (x < 0 || y < 0 || x > canvasBorderX || y > canvasBorderY)
                {
                    return;
                }

                ProcessUserInput(new Vector2D(x, y));
               

                canvasView.InvalidateSurface();
            }
        }

        private void ProcessUserInput(Vector2D location) 
        {
            switch (drawMode)
            {
                case DrawMode.Dot:
                    dots.Add(location);
                    break;
                case DrawMode.Vertice:
                    verticesHistory.Add(location);
                    polygon.AddVertice(location);
                    break;

            }
        }

       
    }
}
