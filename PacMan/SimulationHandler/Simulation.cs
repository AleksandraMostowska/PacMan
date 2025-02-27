﻿using PacMan.GameObjectsHandler;
using PacMan.GameObjectsHandler.GhostHandler;
using PacMan.MapHandler.Maps;

namespace PacMan.SimulationHandler;

public class Simulation
{

    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Player moving on the map.
    /// </summary>
    public List<IGameObj> GameObjs { get; }

    /// <summary>
    /// Starting positions of players.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of pacman moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all creatures make moves.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// List of directions.
    /// </summary>
    private List<Direction> ParsedMoves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Current turn counter.
    /// </summary>
    private int _counter = 0;


    /// <summary>
    /// Valid moves chars.
    /// </summary>
    private HashSet<char> validMoves = new HashSet<char> { 'l', 'r', 'u', 'd' };

    /// <summary>
    /// Reference to Pacman object in the game.
    /// </summary>
    public readonly Pacman Pacman;



    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName
    {
        get => ParsedMoves[_counter % ParsedMoves.Count].ToString().ToLower();
    }


    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if players' list is empty,
    /// if number of players differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IGameObj> gameObjs,
        List<Point> positions, string moves)
    {
        if (gameObjs == null || gameObjs.Count == 0)
            throw new ArgumentException("Players list cannot be empty.");

        if (positions == null || positions.Count != gameObjs.Count)
            throw new ArgumentException("Positions count does not match the number of characters.");

        if (string.IsNullOrWhiteSpace(moves))
            throw new ArgumentException("Moves string cannot be empty or null.");

        Map = map ?? throw new ArgumentNullException(nameof(map));
        GameObjs = gameObjs;
        Positions = positions;
        Moves = moves;
        ParsedMoves = ValidateMoves(moves);


        for (int i = 0; i < gameObjs.Count; i++)
        {
            gameObjs[i].InitMapAndPosition(map, positions[i]);
            if (gameObjs[i] is Pacman p) Pacman = p;

        }

        if (Pacman == null)
            throw new InvalidOperationException("No Pacman found in the game.");
    }

    /// <summary>
    /// Makes one move of pacman in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished || Pacman.GetPoints() == Map.Coins.Count)
            throw new InvalidOperationException("Simulation is already finished.");

        var dir = ParsedMoves[_counter % ParsedMoves.Count];

        Pacman.Go(dir);
        foreach (var ghost in GameObjs.OfType<Ghost>())
        {
            ghost.Go();
        }

        _counter++;
        if (_counter >= Moves.Length) Finished = true;
    }


    /// <summary>
    /// Validates moves input.
    /// </summary>
    private List<Direction> ValidateMoves(string moves)
    {
        return moves
            .Where(c => validMoves.Contains(char.ToLower(c)))
            .Select(c => DirectionParser.Parse(c.ToString()).FirstOrDefault())
            .ToList();
    }
}
