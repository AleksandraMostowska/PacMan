using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.MapHandler;

internal static class MapRules
{
    public static Point BigNext(Map m, Point p, Direction d)
    {
        var moved = p.Next(d);
        if (!m.Exist(moved))
        {
            //var reversed = p.Next(DirectionParser.Reverse(d));
            //if (m.Exist(reversed)) return reversed;
            return p;
        }
        return moved;
    }

    //public static void AddWall(Map m, Point p) => new Wall().InitMapAndPosition(m, p);
    //public static void AddCoin(Map m, Point p) => new Coin().InitMapAndPosition(m, p);



    //public static Point BigNextDiagonal(Map m, Point p, Direction d)
    //{
    //    var moved = p.NextDiagonal(d);
    //    if (!m.Exist(moved))
    //    {
    //        var reversed = p.NextDiagonal(DirectionParser.Reverse(d));
    //        if (m.Exist(reversed)) return reversed;
    //        return p;
    //    }
    //    return moved;
    //}

    ////SmallSquare
    //public static Point WallNext(Map m, Point p, Direction d)
    //{
    //    var moved = p.Next(d);
    //    if (!m.Exist(moved)) return p;
    //    return moved;
    //}

    ////SmallSquare
    //public static Point WallNextDiagonal(Map m, Point p, Direction d)
    //{
    //    var moved = p.NextDiagonal(d);
    //    if (!m.Exist(moved)) return p;
    //    return moved;
    //}

    //public static Point SmallTorusNext(Map m, Point p, Direction d)
    //{
    //    var moved = p.Next(d);
    //    return new Point((moved.X + m.SizeX) % m.SizeX, (moved.Y + m.SizeY) % m.SizeY);
    //}

    //public static Point SmallTorusNextDiagonal(Map m, Point p, Direction d)
    //{
    //    var moved = p.NextDiagonal(d);
    //    return new Point((moved.X + m.SizeX) % m.SizeX, (moved.Y + m.SizeY) % m.SizeY);
    //}

    //public static Point BigBounceNext(Map m, Point p, Direction d)
    //{
    //    var moved = p.Next(d);
    //    if (!m.Exist(moved))
    //    {
    //        var reversed = p.Next(DirectionParser.Reverse(d));
    //        if (m.Exist(reversed)) return reversed;
    //        return p;
    //    }
    //    return moved;
    //}

    //public static Point BigBounceNextDiagonal(Map m, Point p, Direction d)
    //{
    //    var moved = p.NextDiagonal(d);
    //    if (!m.Exist(moved))
    //    {
    //        var reversed = p.NextDiagonal(DirectionParser.Reverse(d));
    //        if (m.Exist(reversed)) return reversed;
    //        return p;
    //    }
    //    return moved;
    //}

    //public static Point BigTorusNext(Map m, Point p, Direction d)
    //{
    //    var moved = p.Next(d);
    //    return new Point((moved.X + m.SizeX) % m.SizeX, (moved.Y + m.SizeY) % m.SizeY);
    //}

    //public static Point BigTorusNextDiagonal(Map m, Point p, Direction d)
    //{
    //    var moved = p.NextDiagonal(d);
    //    return new Point((moved.X + m.SizeX) % m.SizeX, (moved.Y + m.SizeY) % m.SizeY);
    //}
}
