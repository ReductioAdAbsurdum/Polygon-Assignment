
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolygonApp.Droid.Logic.Backend
{
    internal class Polygon
    {
        private List<Vector2D> vertices = new List<Vector2D>();

        /// <summary>
        /// Add vertice to polygon.
        /// </summary>
        /// <param name="vertice"></param>
        internal void AddVertice(Vector2D vertice)
        {
            // Guard logic from double vertice on same point
            if (!vertices.Contains(vertice))
            {
                vertices.Add(vertice);
            }
        }

        /// <summary>
        /// Clear all vertices from polygon.
        /// </summary>
        /// <param name="vertice"></param>
        internal void ClearVertices()
        {
            vertices.Clear();
        }

        /// <summary>
        /// Sort vertices then returns array of them
        /// </summary>
        /// <returns></returns>
        internal Vector2D[] GetVertices()
        {
            SortVertices();
            return vertices.ToArray();
        }

        /// <summary>
        /// Returns number of vertices.
        /// </summary>
        internal int VerticeNumber
        {
            get
            {
                return vertices.Count;
            }
        }

        /// <summary>
        /// Return center of vertices. Used to sort vertices in mathematical negative direction
        /// </summary>  
        private Vector2D FindCenter()
        {
            double sumX = 0;
            double sumY = 0;

            foreach (Vector2D v in vertices)
            {
                sumX += v.X;
                sumY += v.Y;
            }

            return new Vector2D(sumX / vertices.Count, sumY / vertices.Count);
        }

        /// <summary>
        /// Sorts internal list of vertices
        /// </summary>
        private void SortVertices()
        {
            Vector2D center = FindCenter();

            vertices.Sort((a, b) =>
            {
                Vector2D canterToFirst = a.Subtract(center);
                Vector2D centerToSecund = b.Subtract(center);

                if (canterToFirst.Heading() - centerToSecund.Heading() >= 0)
                {
                    return 1;
                }
                return -1;
            });
        }

        /// <summary>
        /// Returns true if polygon is convex, false if not.
        /// </summary>
        /// <returns></returns>
        internal bool IsConvex() 
        {
            if (vertices.Count < 3) 
            {
                return false;
            }

            SortVertices();

            
            // Check for direction changes
            bool preferedOrentation = vertices[0].Subtract(vertices[vertices.Count - 1]).CrossProductSing(vertices[1].Subtract(vertices[0]));

            for (int i = 0; i < vertices.Count - 2; i++)
            {
                if (preferedOrentation != vertices[i+1].Subtract(vertices[i]).CrossProductSing(vertices[i+2].Subtract(vertices[i+1]))) 
                {
                    return false;
                }
            }

            // Check for invalid *inside* dots
            Vector2D target = vertices[vertices.Count - 2].Add(vertices[0]).Scale(0.5);

            if (Evaluator.IsInside(this, target) == false)
            {
                return false;
            }

            target = vertices[vertices.Count - 1].Add(vertices[1]).Scale(0.5);

            if (Evaluator.IsInside(this, target) == false)
            {
                return false;
            }

            for (int i = 0; i < vertices.Count - 2; i++)
            {
                target = vertices[i].Add(vertices[i + 2]).Scale(0.5);

                if (Evaluator.IsInside(this, target) == false) 
                {
                    return false;
                }
            }
           


            return true;
        }

        /// <summary>
        /// Provides triangle that is created inside unit circle
        /// </summary>
        internal static Polygon Triangle
        {
            get
            {
                Polygon triangle = new Polygon();
                triangle.AddVertice(new Vector2D(0, 1).Normalize());
                triangle.AddVertice(new Vector2D(-1, 0).Normalize());
                triangle.AddVertice(new Vector2D(1, 0).Normalize());

                return triangle;
            }
        }

        /// <summary>
        /// Provides rectangle that is created inside unit circle
        /// </summary>
        internal static Polygon Rectangle
        {
            get
            {
                Polygon rectangle = new Polygon();

                rectangle.AddVertice(new Vector2D(1, 1).Normalize());
                rectangle.AddVertice(new Vector2D(1, -1).Normalize());
                rectangle.AddVertice(new Vector2D(-1, 1).Normalize());
                rectangle.AddVertice(new Vector2D(-1, -1).Normalize());

                return rectangle;
            }
        }

        /// <summary>
        /// Provides pentagon that is created inside unit circle
        /// </summary>
        internal static Polygon Pentagon
        {
            get
            {
                Polygon pentagon = new Polygon();

                pentagon.AddVertice(new Vector2D(1, 1).Normalize());
                pentagon.AddVertice(new Vector2D(1, -1).Normalize());
                pentagon.AddVertice(new Vector2D(-1, 1).Normalize());
                pentagon.AddVertice(new Vector2D(-1, -1).Normalize());
                pentagon.AddVertice(new Vector2D(0, 1).Normalize());

                return pentagon;
            }
        }

        /// <summary>
        /// Provides hexagon that is created inside unit circle
        /// </summary>
        internal static Polygon Hexagon
        {
            get
            {
                Polygon pentagon = new Polygon();

                pentagon.AddVertice(new Vector2D(1, 1).Normalize());
                pentagon.AddVertice(new Vector2D(1, -1).Normalize());
                pentagon.AddVertice(new Vector2D(-1, 1).Normalize());
                pentagon.AddVertice(new Vector2D(-1, -1).Normalize());
                pentagon.AddVertice(new Vector2D(0, 1).Normalize());
                pentagon.AddVertice(new Vector2D(0, -1).Normalize());

                return pentagon;
            }
        }

        /// <summary>
        /// Provides octagon that is created inside unit circle
        /// </summary>
        internal static Polygon Octagon
        {
            get
            {
                Polygon octagon = new Polygon();

                octagon.AddVertice(new Vector2D(1, 1).Normalize());
                octagon.AddVertice(new Vector2D(1, -1).Normalize());
                octagon.AddVertice(new Vector2D(-1, 1).Normalize());
                octagon.AddVertice(new Vector2D(-1, -1).Normalize());
                octagon.AddVertice(new Vector2D(0, 1).Normalize());
                octagon.AddVertice(new Vector2D(0, -1).Normalize());
                octagon.AddVertice(new Vector2D(1, 0).Normalize());
                octagon.AddVertice(new Vector2D(-1, 0).Normalize());

                return octagon;
            }
        }

        /// <summary>
        /// Returns n sided poligon
        /// </summary>
        /// <param name="n">Number of sides of the polygon that is inside of unit circle</param>
        /// <returns></returns>
        internal static Polygon GetCustomPolygon(int n)
        {
            Polygon polygon = new Polygon();

            Random rng = new Random();
            for (int i = 0; i < n; i++)
            {
                polygon.AddVertice(new Vector2D(rng.NextDouble() - 0.5, rng.NextDouble() - 0.5).Normalize());
            }

            return polygon;
        }

        

    }
}