using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.MapHandler.Maps;

namespace PacMan.MapHandler;

internal static class MapRules
{
    public static Point BigNext(Map m, Point p, Direction d)
    {
        var moved = p.Next(d);
        if (!m.Exist(moved))
        {
            return p;
        }
        return moved;
    }
}
