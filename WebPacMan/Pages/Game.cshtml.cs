using Microsoft.AspNetCore.Mvc.RazorPages;
using PacMan;
using PacMan.GameObjectsHandler;
using PacMan.MapHandler.Maps;
public class GameModel : PageModel
{
    public SimulationHistory SimulationHistory { get; private set; }
    public int CurrentTurn { get; private set; }
    public int MaxTurn => SimulationHistory.TurnLogs.Count - 1;

    public GameModel()
    {
        OGMap map = new();
        List<IGameObj> creatures = new()
        {
            new Pacman("Player"),
            new AngryGhost(),
            new FriendlyGhost()
        };
        List<Point> points = new()
        {
            new Point(1, 1),
            new Point(9, 9),
            new Point(8, 9)
        };
        string moves = "rrrrrrrluludlulldllullrdllr";
        Simulation simulation = new Simulation(map, creatures, points, moves);
        SimulationHistory = new SimulationHistory(simulation);
        CurrentTurn = 0;
    }

    public void OnGet(int? turn) => CurrentTurn = turn ?? 0;

    public void OnPostChangeTurn(string direction, int? turn)
    {
        CurrentTurn = turn ?? 0;

        if (direction == "prev" && CurrentTurn > 0) CurrentTurn--;
        else if (direction == "next" && CurrentTurn < MaxTurn) CurrentTurn++;
    }
}
