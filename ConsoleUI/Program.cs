using LogicCL;


Vector2D dot = new Vector2D(0.6, 0.7);


Console.WriteLine(Evaluator.isInside(Polygon.Triangle,dot));
Console.WriteLine(Evaluator.isInside(Polygon.Rectangle,dot));
Console.WriteLine(Evaluator.isInside(Polygon.Pentagon,dot));
Console.WriteLine(Evaluator.isInside(Polygon.Hexagon,dot));
Console.WriteLine(Evaluator.isInside(Polygon.Octagon,dot));



