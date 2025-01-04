using PacMan;
using PacMan.GameObjectsHandler;
using PacMan.MapHandler;
using System.Drawing;
using System.Text;

namespace SimConsole;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        var map = new BigMap(10, 10);

        List<IGameObj> creatures2 = new()
            {
                new Pacman("Pacman"),
                new AngryGhost(),
                new FriendlyGhost()
            };

        List<PacMan.Point> points2 = new()
            {
                new PacMan.Point(6, 6),
                new PacMan.Point(2, 3),
                new PacMan.Point(1, 1)
            };

        string moves2 = "dlrludluddlrulr";

        Simulation simulation = new Simulation(map, creatures2, points2, moves2);
        MapVisualizer mapVisualizer = new MapVisualizer(map);

        Console.WriteLine("SIMULATION!");
        Console.WriteLine();
        Console.WriteLine("Starting positions:");
        mapVisualizer.Draw();

        var turn = 0;

        while (!simulation.Finished)
        {
            ConsoleKeyInfo key = Console.ReadKey(intercept: true);
            Console.WriteLine($"Turn {turn}");
            Console.WriteLine($"{simulation.Pacman} moves {simulation.CurrentMoveName}");

            if (key.Key == ConsoleKey.Spacebar)
            {
                Console.WriteLine(map.PacmanPosition);
                simulation.Turn();
                mapVisualizer.Draw();
                turn++;
            }
        }
    }
}
