using ConsoleUI;
using LogicCL;


Vector2D dot1 = new Vector2D(0, 0);
Vector2D dot2 = new Vector2D(0, 0.5);
Vector2D dot3 = new Vector2D(0.5, 0);
Vector2D dot4 = new Vector2D(-0.5, 0);
Vector2D dot5 = new Vector2D(0, -0.5);

//Console.WriteLine(Evaluator.IsInside(Polygon.Triangle, dot));
//Console.WriteLine(Evaluator.IsInside(Polygon.Rectangle, dot));
//Console.WriteLine(Evaluator.IsInside(Polygon.Pentagon, dot));
//Console.WriteLine(Evaluator.IsInside(Polygon.Hexagon, dot));
//Console.WriteLine(Evaluator.IsInside(Polygon.Octagon, dot)); 


Canvas canvas = new Canvas();

canvas.DrawPoint(dot1,ConsoleColor.Red);
canvas.DrawPoint(dot2,ConsoleColor.Red);
canvas.DrawPoint(dot3,ConsoleColor.Red);
canvas.DrawPoint(dot4,ConsoleColor.Red);
canvas.DrawPoint(dot5,ConsoleColor.Red);

Console.ForegroundColor = ConsoleColor.Red;
canvas.DrawPolygon(Polygon.Rectangle);

Console.ReadLine();
