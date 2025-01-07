﻿using PacMan;
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

        var map = new BigMap();

        var PacMan = new Pacman("Pacman");

        List<IGameObj> creatures2 = new()
            {
                PacMan,
                new AngryGhost(),
                new FriendlyGhost()
            };

        List<PacMan.Point> points2 = new()
            {
                new PacMan.Point(6, 6),
                new PacMan.Point(2, 3),
                new PacMan.Point(10, 4)
            };

        string moves2 = "dllrruudlrludluddlrulr";

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
                Console.WriteLine(PacMan.GetPoints());
            }
        }
    }
}
