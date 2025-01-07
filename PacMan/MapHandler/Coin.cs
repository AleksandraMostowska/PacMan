using PacMan.GameObjectsHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.MapHandler;

public class Coin : IGameObj
{
    public Point Position { get; private set; }

    public char Symbol => 'C';

    public Coin() { }

    public Coin(Point position)
    {
        Position = position;
    }

    public void InitMapAndPosition(Map map, Point point)
    {
        if (map == null) throw new ArgumentNullException(nameof(map));
        map.Add(this, point);
        Position = point;
    }

    public override string ToString() => $"Coin at {Position}";
}
