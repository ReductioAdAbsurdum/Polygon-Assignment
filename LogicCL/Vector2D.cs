using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicCL
{
    public struct Vector2D : IEquatable<Vector2D>
    {
        public readonly double X;
        public readonly double Y;    

        public Vector2D(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Returns sing of cross product between two vectors
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool CrossProductSing(Vector2D other) 
        {
            return (this.X * other.Y - this.Y * other.X) > 0;
        }

        /// <summary>
        /// Returns resulting vector of substraction
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public Vector2D Subtract(Vector2D other)
        {
            return new Vector2D(this.X - other.X, this.Y - other.Y);
        }

        /// <summary>
        /// Returns normalized vector
        /// </summary>
        /// <returns></returns>
        public Vector2D Normalize() 
        {
            double module = Math.Sqrt(X * X + Y * Y);
            return new Vector2D(X / module, Y / module);
        }

        /// <summary>
        /// Returns the agle between this and unit vector e1
        /// </summary>
        /// <returns></returns>
        public double Heading() 
        {
            return Math.Atan2(this.X, this.Y);
        }

        public bool Equals(Vector2D other)
        {
            //Console.WriteLine("debug equals");
            return this.X == other.X && this.Y == other.Y;
        }
    }
}
