using PacMan.MapHandler.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameObjectsHandler;

public interface IMoveBehavior
{
    Point GetNextMove(Point currentPosition, Map map, Point pacmanPosition);
}
