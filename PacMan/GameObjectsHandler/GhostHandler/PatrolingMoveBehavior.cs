using PacMan.MapHandler.Maps;
using PacMan;
using PacMan.GameObjectsHandler.GhostHandler;

public class PatrolingMoveBehavior : IMoveBehavior
{
    private List<Point> patrolPoints = new List<Point>
    {
        new Point(1, 9),
        new Point(17, 9),
        new Point(9, 7),
        new Point(9, 11)
    };

    private int currentPatrolIndex = 0;

    public Point GetNextMove(Point currentPosition, Map map, Point pacmanPosition)
    {
        var nextPatrolPoint = patrolPoints[currentPatrolIndex];

        if (currentPosition.X == nextPatrolPoint.X && currentPosition.Y == nextPatrolPoint.Y)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Count;
            nextPatrolPoint = patrolPoints[currentPatrolIndex];
        }

        var preferredDirections = GetPreferredDirections(currentPosition, nextPatrolPoint);

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