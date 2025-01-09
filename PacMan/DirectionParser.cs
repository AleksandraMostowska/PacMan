using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan;

public static class DirectionParser
{
    public static List<Direction> Parse(string input)
    {
        var directions = new List<Direction>();
        var directionsMap = new Dictionary<char, Direction>(){
            { 'U', Direction.Up },
            { 'R', Direction.Right },
            { 'L', Direction.Left },
            { 'D', Direction.Down }
        };

        foreach (char c in input.ToUpper())
        {
            if (directionsMap.TryGetValue(c, out var direction)) directions.Add(direction);
        }

        return directions;
    }

    public static Direction ParseChar(char letter)
    {
        Direction directions = new();

        if (letter == 'u' || letter == 'U')
        {
            directions = (Direction.Up);
        }
        else if (letter == 'd' || letter == 'D')
        {
            directions = (Direction.Down); ;
        }
        else if (letter == 'l' || letter == 'L')
        {
            directions = (Direction.Left);
        }
        else if (letter == 'r' || letter == 'R')
        {
            directions = (Direction.Right);
        }

        return directions;
    }

    public static Direction Reverse(Direction direction)
    {
        return direction switch
        {
            Direction.Up => Direction.Down,
            Direction.Down => Direction.Up,
            Direction.Left => Direction.Right,
            Direction.Right => Direction.Left,
            _ => throw new ArgumentException("Invalid direction")
        };
    }
}
