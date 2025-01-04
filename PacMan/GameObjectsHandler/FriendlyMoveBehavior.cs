using PacMan.MapHandler;
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
        Point nextPosition;

        do
        {
            var chosenDirection = directions[_random.Next(directions.Count)];
            nextPosition = map.Next(currentPosition, chosenDirection);
            if (!map.Exist(nextPosition)) directions.Remove(chosenDirection);
        } while (directions.Count > 0 && !map.Exist(nextPosition));
        return map.Exist(nextPosition) ? nextPosition : currentPosition;
    }
}
