using Microsoft.AspNetCore.Mvc.RazorPages;
using PacMan;
using PacMan.GameObjectsHandler;
using PacMan.MapHandler.Maps;
public class Game2Model : PageModel
{
    public SimulationHistory SimulationHistory { get; private set; }
    public int CurrentTurn { get; private set; }
    public int MaxTurn => SimulationHistory.TurnLogs.Count - 1;

    public Game2Model()
    {
        var map = new CustomMap1();

        var PacMan = new Pacman("Pacman");

        List<IGameObj> creatures2 = new()
            {
                PacMan,
                new AngryGhost(),
                new FriendlyGhost(),
                new PatrolingGhost()
            };

        List<Point> points2 = new()
            {
                new Point(1, 1),
                new Point(9, 9),
                new Point(10, 9),
                new Point(8, 9)
            };

        string moves2 = "rrrrrrrruuuudllrruudlrludluddlrulr";

        Simulation simulation = new Simulation(map, creatures2, points2, moves2);
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
