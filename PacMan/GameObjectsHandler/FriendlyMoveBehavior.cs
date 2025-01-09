using PacMan.MapHandler.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameObjectsHandler;

public class FriendlyMoveBehavior : IMoveBehavior
{
    private static readonly Random _random = new();
    public Point GetNextMove(Point currentPosition, Map map, Point pacmanPosition)
    {
        var directions = Enum.GetValues(typeof(Direction)).Cast<Direction>().ToList();
        //Console.WriteLine(directions.Count);
        //Point nextPosition = currentPosition;
        Point nextPosition = new Point(currentPosition.X, currentPosition.Y);
        Console.WriteLine(nextPosition.Equals(currentPosition));

        while (directions.Count > 0)
        {
            var chosenDirection = directions[_random.Next(directions.Count)];
            nextPosition = map.Next(currentPosition, chosenDirection); 

            if (map.Exist(nextPosition) && !map.ContainsWall(nextPosition))
            {
                return nextPosition;
            }

            directions.Remove(chosenDirection); 
        }

        return currentPosition;

        //return map.Next(currentPosition, Direction.Right);
    }
}
