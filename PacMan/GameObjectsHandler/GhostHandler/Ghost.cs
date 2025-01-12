using PacMan.MapHandler.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PacMan.GameObjectsHandler.GhostHandler;

public class Ghost : IGameObj
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }
    protected int HpToRemove { get; init; }
    protected IMoveBehavior? moveBehavior;
    private Point _initialPosition;

    public virtual char Symbol => 'G';

    public Ghost() { }

    public void Go()
    {
        if (Map == null) throw new InvalidOperationException("Ghost is not on the map!");
        if (moveBehavior == null) throw new InvalidOperationException("Move behavior is not defined!");

        var nextPosition = moveBehavior.GetNextMove(Position, Map, Map.PacmanPosition);

        if (!Map.ContainsWall(nextPosition))
        {
            if (Map.Exist(nextPosition))
            {
                if (nextPosition.IsSamePointAs(Map.PacmanPosition))
                {
                    ResetPosition();
                    Map.RemovePacmansHP(HpToRemove);
                }
                else
                {
                    Map.Move(this, Position, nextPosition);
                    Position = nextPosition;
                }
            }
        }

        //if (Map.Exist(nextPosition))
        //{
        //    if (nextPosition.IsSamePointAs(Map.PacmanPosition))
        //    {
        //        ResetPosition();
        //        Map.RemovePacmansHP(HpToRemove);
        //    }
        //    else
        //    {
        //        Map.Move(this, Position, nextPosition);
        //        Position = nextPosition;
        //    }

        //}
        //else throw new InvalidOperationException("Next position is outside the map boundaries.");
    }

    public void InitMapAndPosition(Map map, Point position)
    {
        if (map == null) throw new ArgumentNullException(nameof(map));
        if (Map != null) throw new InvalidOperationException($"This creature is already on a map. It cannot be moved to a new map.");
        if (!map.Exist(position)) throw new ArgumentException("Non-existing position for this map.");

        Map = map;
        Position = position;
        _initialPosition = position;
        map.Add(this, position);
    }

    public override string ToString() => $"{GetType().Name.ToUpper()}";

    private void ResetPosition()
    {
        // Map.Move cannot be applied since by moving him on map and changing his _initialPosition
        // resulted in duplicating ghost on the map
        if (Map == null) throw new InvalidOperationException("Map is not set!");
        Map.Remove(this, Position);
        Position = _initialPosition;
        Map.Add(this, _initialPosition);

        //Position = _initialPosition;  
        //Map.Move(this, Position, _initialPosition); 
    }

}
