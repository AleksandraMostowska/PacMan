using PacMan.GameObjectsHandler;
using PacMan.MapHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan;

/// <summary>
/// State of map after single simulation turn.
/// </summary>
public class SimulationTurnLog
{

    /// <summary>
    /// Text representastion of moving object in this turn.
    /// CurrentMappable.ToString()
    /// </summary>
    public required string IGameObj { get; init; }
    /// <summary>
    /// Text representation of move in this turn.
    /// CurrentMoveName.ToString();
    /// </summary>
    public required string Move { get; init; }
    /// <summary>
    /// Dictionary of IMappable.Symbol on the map in this turn.
    /// </summary>
    public required Dictionary<Point, char> Symbols { get; init; }

    public required Dictionary<Point, Wall> Walls { get; init; }

    public required Dictionary<Point, Coin> Coins { get; init; }
    public required int Score { get; init; }
    public required int HP { get; init; }
}
