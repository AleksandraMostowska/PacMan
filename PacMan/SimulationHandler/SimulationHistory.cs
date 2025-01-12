using PacMan.GameObjectsHandler;
using PacMan.MapHandler;
using PacMan.MapHandler.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.SimulationHandler;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        Run();
    }

    public string GetMoves() => _simulation.Moves;


    public Map GetMap() => _simulation.Map;

    private void Run()
    {
        TurnLogs.Add(new SimulationTurnLog
        {
            IGameObj = string.Empty,
            Move = string.Empty,
            Symbols = _simulation.GameObjs
                .GroupBy(m => m.Position)
                .ToDictionary(
                    group => group.Key,
                    group => group.Count() > 1 ? 'X' : group.First().Symbol
                ),
            Walls = new Dictionary<Point, Wall>(_simulation.Map.Walls),
            Coins = new Dictionary<Point, Coin>(_simulation.Map.Coins),
            Score = 0,
            HP = 0
        });

        while (!_simulation.Finished)
        {
            var currentMappable = _simulation.Pacman;
            var move = _simulation.CurrentMoveName;

            _simulation.Turn();

            TurnLogs.Add(new SimulationTurnLog
            {
                IGameObj = currentMappable.ToString(),
                Move = move,
                Symbols = _simulation.GameObjs
                    .GroupBy(m => m.Position)
                    .ToDictionary(
                        group => group.Key,
                        group => group.Count() > 1 ? 'X' : group.First().Symbol
                    ),
                Walls = new Dictionary<Point, Wall>(_simulation.Map.Walls),
                Coins = new Dictionary<Point, Coin>(_simulation.Map.Coins),
                Score = _simulation.Pacman.GetPoints(),
                HP = _simulation.Pacman.GetHp()
            });
        }
    }
}
