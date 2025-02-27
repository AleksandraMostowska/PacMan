﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan;

public readonly struct Point
{
    public readonly int X, Y;
    public Point(int x, int y) => (X, Y) = (x, y);
    public override string ToString() => $"({X}, {Y})";

    public Point Next(Direction direction)
    {
        return direction switch
        {
            Direction.Left => new Point(X - 1, Y),
            Direction.Right => new Point(X + 1, Y),
            Direction.Up => new Point(X, Y + 1),
            Direction.Down => new Point(X, Y - 1),
            _ => this
        };
    }

    public bool IsSamePointAs(Point point) => (X == point.X && Y == point.Y);
}
