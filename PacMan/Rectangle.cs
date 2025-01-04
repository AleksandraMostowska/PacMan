using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan;

public class Rectangle
{
    public readonly int X1, Y1, X2, Y2;

    public Rectangle(int x1, int y1, int x2, int y2)
    {
        var left_bottom_x = x1 < x2 ? x1 : x2;
        var left_bottom_y = y1 < y2 ? y1 : y2;
        var right_top_x = x2 > x1 ? x2 : x1;
        var right_top_y = y2 > y1 ? y2 : y1;


        if (left_bottom_x == right_top_x || left_bottom_y == right_top_y)
        {
            throw new ArgumentException("Wrong parameters passed - cannot create rectangle");
        }

        X1 = left_bottom_x;
        Y1 = left_bottom_y;
        X2 = right_top_x;
        Y2 = right_top_y;
    }

    public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y) {   }

    public bool Contains(Point point) => point.X >= X1 && point.Y >= Y1 && point.X <= X2 && point.Y <= Y2;

    public override string ToString() => $"({X1}, {Y1}):({X2}, {Y2})";
}
