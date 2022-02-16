
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PolygonApp.Droid.Logic.Backend
{
    internal class Vector2D
    {
        internal readonly double X;
        internal readonly double Y;

        internal Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }    

        /// <summary>
        /// Returns resulting vector of substraction
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        internal Vector2D Subtract(Vector2D other)
        {
            return new Vector2D(this.X - other.X, this.Y - other.Y);
        }
        
        /// <summary>
        /// Returns resulting vector of addition
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        internal Vector2D Add(Vector2D other)
        {
            return new Vector2D(this.X + other.X, this.Y + other.Y);
        }

        /// <summary>
        /// Returns resulting vector of multipication by scalar
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        internal Vector2D Scale(double scalar)
        {
            return new Vector2D(scalar * this.X, scalar * this.Y);
        }

        /// <summary>
        /// Returns normalized vector
        /// </summary>
        /// <returns></returns>
        internal Vector2D Normalize()
        {
            double module = Math.Sqrt(X * X + Y * Y);
            return new Vector2D(X / module, Y / module);
        }

        /// <summary>
        /// Returns the agle between this and unit vector e1
        /// </summary>
        /// <returns></returns>
        internal double Heading()
        {
            return Math.Atan2(this.X, this.Y);
        }

        /// <summary>
        /// Returns sing of cross product between two vectors
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        internal bool CrossProductSing(Vector2D other)
        {
            return (this.X * other.Y - this.Y * other.X) > 0;
        }

        internal bool Equals(Vector2D other)
        {
            //Console.WriteLine("debug equals");
            return this.X == other.X && this.Y == other.Y;
        }
    }
}