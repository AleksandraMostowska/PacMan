using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using PacMan.GameObjectsHandler.GhostHandler;
using PacMan.MapHandler.Maps;
using PacMan;
using PacMan.GameObjectsHandler;
using PacMan.SimulationHandler;

public class GameModel : PageModel
{
    public SimulationHistory SimulationHistory { get; private set; }
    public int CurrentTurn { get; private set; }
    public int MaxTurn => SimulationHistory.TurnLogs.Count - 1;
    public string MapType { get; private set; }

    public GameModel()
    {
        InitializeSimulation();
        CurrentTurn = 0;
    }

    public void OnGet(string mapType, int turn)
    {
        MapType = mapType ??"OGMap";

        InitializeSimulation();

        CurrentTurn = turn;
    }

    public void OnPostChangeTurn(string direction, string mapType, int turn)
    {
        MapType = mapType ?? "OGMap";

        CurrentTurn = turn;

        if (direction == "prev" && CurrentTurn > 0)
            CurrentTurn--;
        else if (direction == "next" && CurrentTurn < MaxTurn)
            CurrentTurn++;

        InitializeSimulation(); 
    }



    private void InitializeSimulation()
    {
        var map = GetMapByType(MapType);

        var PacMan = new Pacman("Pacman");

        List<IGameObj> creatures = new()
        {
            PacMan,
            new AngryGhost(),
            new FriendlyGhost(),
            new PatrolingGhost()
        };

        List<Point> points = new()
        {
            new Point(1, 1),
            new Point(9, 9),
            new Point(10, 9),
            new Point(8, 9)
        };

        string moves = "rrrrrrrruuuudllrruudlrludluddlrulr";

        Simulation simulation = new Simulation(map, creatures, points, moves);
        SimulationHistory = new SimulationHistory(simulation);
    }

    private Map GetMapByType(string mapType)
    {
        return mapType switch
        {
            "OGMap" => new OGMap(),
            "CustomMap1" => new CustomMap1(),
            "CustomMap2" => new CustomMap2(),
            _ => new OGMap()
        };
    }
}
