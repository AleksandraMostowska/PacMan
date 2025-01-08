using PacMan.MapHandler.Maps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameObjectsHandler;

public class Pacman : IGameObj
{
    public Map? Map { get; private set; }
    public Point Position { get; private set; }
    //private int _level = 1;
    private string _name = "Player 1";
    private int _points = 0;
    private int _hp = 3;

    //public int Level
    //{
    //    get => _level;
    //    init
    //    {
    //        _level = GameValidator.Limiter(value, 1, 10);
    //    }
    //}

    public string Name
    {
        get => _name;
        init
        {
            _name = GameValidator.Shortener(value, 3, 25, ' ');
        }
    }

    public Pacman() { }

    public Pacman(string name)
    {
        Name = name;
    }

    public void AddPoint() => _points++;

    public void RemovePoint() => _points--;

    public void AddHp(int hp) => _hp = GameValidator.Limiter(_hp + hp, 0, 3);


    public void RemoveHp(int hp) => _hp = GameValidator.Limiter(_hp - hp, 0, 3);

    public char Symbol => 'P';

    public void InitMapAndPosition(Map map, Point position)
    {
        if (map == null) throw new ArgumentNullException(nameof(map));
        if (Map != null) throw new InvalidOperationException($"This creature is already on a map. It cannot be moved to a new map.");
        if (!map.Exist(position)) throw new ArgumentException("Non-existing position for this map.");

        Map = map;
        Position = position;
        map.Add(this, position);
    }

    public void Go(Direction direction)
    {

        if (Map == null) throw new InvalidOperationException("Creature cannot move since it's not on the map!");

        var newPosition = Map.Next(Position, direction);

        if (!Map.ContainsWall(newPosition))
        {
            if (Map.ContainsCoin(newPosition))
            {
                var coin = Map.Coins[newPosition];
                _points++;
                Map.Remove(coin, newPosition);
            }

            Map.Move(this, Position, newPosition);
            Position = newPosition;  
        }
    }

    public override string ToString() => $"{Name.ToUpper()}";

    public int GetPoints() => _points;
    public int GetHp() => _hp;
}
