using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.MapHandler;

public class BigMap : Map
{
    
    public BigMap() : base(28, 31)
    {
        //if (sizeX > 1000) throw new ArgumentOutOfRangeException(nameof(sizeX), "Too wide.");
        //if (sizeY > 1000) throw new ArgumentOutOfRangeException(nameof(sizeY), "Too high.");
        FNext = MapRules.BigNext;
        //_fields = new Dictionary<Point, List<IMappable>>();

        _walls = new Dictionary<Point, Wall>();
        _coins = new Dictionary<Point, Coin>();

        InitWallsAndCoins();

    }

    private void InitWallsAndCoins()
    {

        _walls.Add(new Point(1, 1), new Wall());
        _walls.Add(new Point(1, 2), new Wall());
        _walls.Add(new Point(5, 5), new Wall());
        _walls.Add(new Point(0, 0), new Wall());
        _walls.Add(new Point(27, 30), new Wall());
        _walls.Add(new Point(10, 15), new Wall());

        _coins.Add(new Point(3, 3), new Coin());
        _coins.Add(new Point(7, 7), new Coin());
        _coins.Add(new Point(10, 10), new Coin());
        _coins.Add(new Point(2, 5), new Coin());
        _coins.Add(new Point(20, 20), new Coin());
        _coins.Add(new Point(14, 28), new Coin());

        foreach (var wall in _walls) Add(wall.Value, wall.Key); ;
        foreach (var coin in _coins) Add(coin.Value, coin.Key);
    }

}
