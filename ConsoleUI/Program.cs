using ConsoleUI;
using LogicCL;


Demo();

/// <summary>
/// Rectagnle(blue) with two points colored green inside of it and two points colored red outside of it
/// </summary>
static void Demo() 
{
    Vector2D dot1 = new Vector2D(0, 0);
    Vector2D dot2 = new Vector2D(0, 0.5);
    Vector2D dot3 = new Vector2D(1.5, 1);
    Vector2D dot4 = new Vector2D(-1, 1);


    Canvas canvas = new Canvas();

    if (Evaluator.IsInside(Polygon.Rectangle, dot1))
    {
        canvas.DrawPoint(dot1, ConsoleColor.Green);
    }
    else
    {
        canvas.DrawPoint(dot1, ConsoleColor.Red);

    }

    if (Evaluator.IsInside(Polygon.Rectangle, dot2))
    {
        canvas.DrawPoint(dot2, ConsoleColor.Green);
    }
    else
    {
        canvas.DrawPoint(dot2, ConsoleColor.Red);

    }

    if (Evaluator.IsInside(Polygon.Rectangle, dot3))
    {
        canvas.DrawPoint(dot3, ConsoleColor.Green);
    }
    else
    {
        canvas.DrawPoint(dot3, ConsoleColor.Red);

    }
    if (Evaluator.IsInside(Polygon.Rectangle, dot4))
    {
        canvas.DrawPoint(dot4, ConsoleColor.Green);
    }
    else
    {
        canvas.DrawPoint(dot4, ConsoleColor.Red);

    }


    Console.ForegroundColor = ConsoleColor.Blue;
    canvas.DrawPolygon(Polygon.GetCustomPolygon(10_000));

    Console.ReadLine();
}