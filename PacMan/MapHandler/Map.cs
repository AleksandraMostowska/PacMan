using PacMan.GameObjectsHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.MapHandler;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    private readonly Rectangle _bounds;
    protected Dictionary<Point, Wall>? _walls;
    protected Dictionary<Point, Coin>? _coins;
    public Dictionary<Point, Coin> Coins => _coins ?? new Dictionary<Point, Coin>();
    public int SizeX { get; }
    public int SizeY { get; }
    protected Func<Map, Point, Direction, Point>? FNext { get; set; }
    //protected Func<Map, Point, Direction, Point>? FNextDiagonal { get; set; }


    Dictionary<Point, List<IGameObj>>? _fields;
    private Pacman? _pacman;
    public Point PacmanPosition => _pacman?.Position ?? throw new InvalidOperationException("Pacman is not on the map.");


    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too narrow.");
        if (sizeY < 5) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too short.");

        SizeX = sizeX;
        SizeY = sizeY;
        _bounds = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
        _fields = new Dictionary<Point, List<IGameObj>>();
    }

    public void Add(IGameObj gameobj, Point position)
    {
        CheckIfPositionWithinMap(position);
        if (!_fields.ContainsKey(position)) _fields[position] = new List<IGameObj>();
        _fields[position].Add(gameobj);

        if (gameobj is Pacman pacman)
        {
            if (_pacman != null) throw new InvalidOperationException("Pacman is already placed on the map.");
            _pacman = pacman;
        }
    }

    public void Remove(IGameObj gameobj, Point position)
    {
        CheckIfPositionWithinMap(position);
        if (_fields.TryGetValue(position, out var gameObjs))
        {
            gameObjs.Remove(gameobj);
            if (_fields[position].Count == 0) _fields.Remove(position);
        }

        if (gameobj is Coin) _coins?.Remove(position);

        if (gameobj is Pacman) _pacman = null;
    }

    public List<IGameObj>? At(Point position)
    {
        CheckIfPositionWithinMap(position);
        return _fields.TryGetValue(position, out var gameObjs) ? gameObjs : null;
    }

    public List<IGameObj>? At(int x, int y) => At(new Point(x, y));

    public void Move(IGameObj gameobj, Point posFrom, Point posTo)
    {
        CheckIfPositionWithinMap(posTo);

        if (_walls.ContainsKey(posTo)) return;

        Remove(gameobj, posFrom);
        Add(gameobj, posTo);

        //if (gameobj is Pacman pacman) pacman.Position = posTo;
    }


    public bool ContainsCoin(Point position) => _coins?.ContainsKey(position) ?? false;
    public bool ContainsWall(Point position) => _walls?.ContainsKey(position) ?? false;


    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => _bounds.Contains(p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public Point Next(Point p, Direction d) => FNext?.Invoke(this, p, d) ?? p;

    //Func<Point, Direction, Point> Next = (p, d) => ;

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    //public Point NextDiagonal(Point p, Direction d) => FNextDiagonal?.Invoke(this, p, d) ?? p;

    public void RemovePacmansHP(int hp) => _pacman?.RemoveHp(hp);


    private void CheckIfPositionWithinMap(Point position)
    {
        if (!Exist(position)) throw new ArgumentException("Position outside the map.");
    }
}
