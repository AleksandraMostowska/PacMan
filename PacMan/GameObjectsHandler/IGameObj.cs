using PacMan.MapHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameObjectsHandler;

public interface IGameObj
{
    Point Position { get; }
    public char Symbol { get; }
    public string ToString();
    void InitMapAndPosition(Map map, Point point);
}
