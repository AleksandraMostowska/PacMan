using PacMan.GameObjectsHandler;
using PacMan.MapHandler.Maps;
using PacMan;

public class FriendlyMoveBehavior : IMoveBehavior
{
    private const int MinDistance = 3;

    public Point GetNextMove(Point currentPosition, Map map, Point pacmanPosition)
    {
        var distance = Math.Abs(currentPosition.X - pacmanPosition.X) +
                       Math.Abs(currentPosition.Y - pacmanPosition.Y);

        if (distance <= MinDistance)
        {
            // Jeśli za blisko, oddala się w kierunku przeciwnym.
            return MoveAwayFromPacman(currentPosition, pacmanPosition, map);
        }

        // Jeśli w odpowiedniej odległości, podąża za Pacmanem.
        return MoveTowardPacman(currentPosition, pacmanPosition, map);
    }

    private Point MoveTowardPacman(Point currentPosition, Point pacmanPosition, Map map)
    {
        var preferredDirections = GetPreferredDirections(currentPosition, pacmanPosition);

        foreach (var direction in preferredDirections)
        {
            var nextPosition = map.Next(currentPosition, direction);

            if (map.Exist(nextPosition) && !map.ContainsWall(nextPosition))
                return nextPosition;
        }

        return currentPosition;
    }

    private Point MoveAwayFromPacman(Point currentPosition, Point pacmanPosition, Map map)
    {
        var preferredDirections = GetPreferredDirections(pacmanPosition, currentPosition); // Odwrotność

        foreach (var direction in preferredDirections)
        {
            var nextPosition = map.Next(currentPosition, direction);

            if (map.Exist(nextPosition) && !map.ContainsWall(nextPosition))
                return nextPosition;
        }

        return currentPosition;
    }

    private List<Direction> GetPreferredDirections(Point currentPosition, Point targetPosition)
    {
        var directions = new List<Direction>();
        var deltaX = targetPosition.X - currentPosition.X;
        var deltaY = targetPosition.Y - currentPosition.Y;

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