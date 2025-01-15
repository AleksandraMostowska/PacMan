using PacMan.MapHandler.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameObjectsHandler.GhostHandler;

public class AngryMoveBehavior : IMoveBehavior
{
    public Point GetNextMove(Point currentPosition, Map map, Point pacmanPosition)
    {
        var preferredDirections = GetPreferredDirections(currentPosition, pacmanPosition);

        foreach (var direction in preferredDirections)
        {

            var nextPosition = map.Next(currentPosition, direction);

            if (map.Exist(nextPosition) && !map.ContainsWall(nextPosition)) return nextPosition;
        }
        return currentPosition;
    }

    private List<Direction> GetPreferredDirections(Point currentPosition, Point pacmanPosition)
    {
        var directions = new List<Direction>();
        var deltaX = pacmanPosition.X - currentPosition.X;
        var deltaY = pacmanPosition.Y - currentPosition.Y;

        if (Math.Abs(deltaX) > Math.Abs(deltaY))
        {
            directions.Add(deltaX > 0 ? Direction.Right : Direction.Left);
            directions.Add(deltaY > 0 ? Direction.Up : Direction.Down);
        }
        else
        {
            directions.Add(deltaY > 0 ? Direction.Up : Direction.Down);
            directions.Add(deltaX > 0 ? Direction.Right : Direction.Left);
        }

        return directions;
    }
}