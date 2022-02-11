
namespace LogicCL
{
    public static class Evaluator
    {
        /// <summary>
        /// Returns true if point is inside of polygon, false if not.
        /// </summary>
        /// <param name="polygon"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static bool IsInside(Polygon polygon, Vector2D point) 
        {
            Vector2D[] vertices = polygon.GetVertices();
            if (vertices.Contains(point)) 
            {
                return true;
            }


            if (vertices.Length < 3) 
            {
                throw new InvalidOperationException("Invalid polygon");
            }

            bool goalOrentation = Orentation(vertices[0], vertices[1], point);


            for (int i = 1; i < vertices.Length; i++)
            {
                Vector2D first = vertices[i];
                Vector2D secund;
                if (i + 1 == vertices.Length)
                {
                    secund = vertices[0];
                }
                else 
                {
                    secund = vertices[i + 1];
                }

                if (goalOrentation != Orentation(first, secund, point)) 
                {
                    return false;
                }
            }
            
            return true;
        }

        /// <summary>
        /// Returns orentation of point compared to polygon side
        /// </summary>
        /// <param name="first"></param>
        /// <param name="secund"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        private static bool Orentation(Vector2D first, Vector2D secund, Vector2D point)
        {
            return secund.Subtract(first).CrossProductSing(point.Subtract(first));
        }

    }

    
}
