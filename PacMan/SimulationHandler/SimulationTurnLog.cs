using PacMan.GameObjectsHandler;
using PacMan.MapHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.SimulationHandler;

/// <summary>
/// State of map after single simulation turn.
/// </summary>
public class SimulationTurnLog
{

    public required string IGameObj { get; init; }

    public required string Move { get; init; }

    public required Dictionary<Point, char> Symbols { get; init; }

    public required Dictionary<Point, Wall> Walls { get; init; }

    public required Dictionary<Point, Coin> Coins { get; init; }
    public required int Score { get; init; }
    public required int HP { get; init; }
}
