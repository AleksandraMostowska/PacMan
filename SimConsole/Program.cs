﻿using PacMan.GameObjectsHandler;
using PacMan.GameObjectsHandler.GhostHandler;
using PacMan.MapHandler;
using PacMan.MapHandler.Maps;
using PacMan.SimulationHandler;
using System.Drawing;
using System.Text;

namespace SimConsole;

public class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        var map = new OGMap();

        var PacMan = new Pacman("Pacman");

        List<IGameObj> creatures2 = new()
            {
                PacMan,
                new AngryGhost(),
                new FriendlyGhost()
            };

        List<PacMan.Point> points2 = new()
            {
                new PacMan.Point(1, 1),
                new PacMan.Point(9, 9),
                new PacMan.Point(10, 9)
            };

        string moves2 = "rrrrrrrruuuudllrruudlrludluddlrulr";

        Simulation simulation = new Simulation(map, creatures2, points2, moves2);
        //MapVisualizer mapVisualizer = new MapVisualizer(map);

        //Console.WriteLine("SIMULATION!");
        //Console.WriteLine();
        //Console.WriteLine("Starting positions:");
        //mapVisualizer.Draw();

        //var turn = 0;

        //while (!simulation.Finished)
        //{
        //    ConsoleKeyInfo key = Console.ReadKey(intercept: true);
        //    Console.WriteLine($"Turn {turn}");
        //    Console.WriteLine($"{simulation.Pacman} moves {simulation.CurrentMoveName}");

        //    if (key.Key == ConsoleKey.Spacebar)
        //    {
        //        Console.WriteLine(map.PacmanPosition);
        //        simulation.Turn();
        //        mapVisualizer.Draw();
        //        turn++;
        //        Console.WriteLine(PacMan.GetPoints());
        //        Console.WriteLine(PacMan.GetHp());
        //    }
        //}

        SimulationHistory simulationHistory = new(simulation);

        //for (int i = 0; i < simulation.Moves.Length; i++)
        //{
        //    Console.WriteLine($"Tura: {i + 1}\n");
        //    Console.WriteLine(simulationHistory.TurnLogs[i].Mappable);
        //    Console.WriteLine(simulationHistory.TurnLogs[i].Move);
        //    foreach (KeyValuePair<Point, char> kvp in simulationHistory.TurnLogs[i].Symbols)
        //    {
        //        Console.WriteLine($"Postition: {kvp.Key}, Symbol: {kvp.Value}");
        //    }
        //    Console.WriteLine("\n");
        //}


        LogVisualizer logVisualizer = new(simulationHistory);
        for (int i = 0; i < simulation.Moves.Length; i++)
        {
            logVisualizer.Draw(i);
            Console.WriteLine($"{simulationHistory.TurnLogs[i].IGameObj} moves {simulationHistory.TurnLogs[i].Move}");
        }
    }
}
