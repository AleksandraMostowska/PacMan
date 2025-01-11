using System;
using System.Collections.Generic;
using PacMan.MapHandler.Maps;

namespace PacMan.MapHandler.Maps
{
    public class CustomMap2 : Map
    {
        public CustomMap2() : base(19, 19)
        {
            FNext = MapRules.BigNext;
            _walls = new Dictionary<Point, Wall>();
            _coins = new Dictionary<Point, Coin>();

            InitWallsAndCoins();
        }

        private void InitWallsAndCoins()
        {
            // Ściany mapy (zewnętrzne obramowanie)
            for (int x = 0; x < SizeX; x++)
            {
                _walls.Add(new Point(x, 0), new Wall()); // Górna krawędź
                _walls.Add(new Point(x, SizeY - 1), new Wall()); // Dolna krawędź
            }

            for (int y = 1; y < SizeY - 1; y++)
            {
                _walls.Add(new Point(0, y), new Wall()); // Lewa krawędź
                _walls.Add(new Point(SizeX - 1, y), new Wall()); // Prawa krawędź
            }

            for(int y = 2; y <= 16; y+=14)
            {
                _walls.Add(new Point(2, y), new Wall());
                _walls.Add(new Point(3, y), new Wall());
                _walls.Add(new Point(4, y), new Wall());
                _walls.Add(new Point(6, y), new Wall());
                _walls.Add(new Point(7, y), new Wall());
                _walls.Add(new Point(8, y), new Wall());
                _walls.Add(new Point(10, y), new Wall());
                _walls.Add(new Point(11, y), new Wall());
                _walls.Add(new Point(12, y), new Wall());
                _walls.Add(new Point(14, y), new Wall());
                _walls.Add(new Point(15, y), new Wall());
                _walls.Add(new Point(16, y), new Wall());
            }

            for (int y = 3; y <= 15; y += 12)
            {
                _walls.Add(new Point(2, y), new Wall());
                _walls.Add(new Point(6, y), new Wall());
                _walls.Add(new Point(12, y), new Wall());
                _walls.Add(new Point(16, y), new Wall());
            }

            for (int y = 4; y <= 14; y += 10)
            {
                _walls.Add(new Point(2, y), new Wall());
                _walls.Add(new Point(4, y), new Wall());
                _walls.Add(new Point(5, y), new Wall());
                _walls.Add(new Point(6, y), new Wall());
                _walls.Add(new Point(8, y), new Wall());
                _walls.Add(new Point(10, y), new Wall());
                _walls.Add(new Point(12, y), new Wall());
                _walls.Add(new Point(13, y), new Wall());
                _walls.Add(new Point(14, y), new Wall());
                _walls.Add(new Point(16, y), new Wall());
            }

            for (int y = 5; y <= 13; y += 8)
            {
                _walls.Add(new Point(2, y), new Wall());
                _walls.Add(new Point(6, y), new Wall());
                _walls.Add(new Point(12, y), new Wall());
                _walls.Add(new Point(16, y), new Wall());
            }

            for (int y = 6; y <= 12; y += 6)
            {
                _walls.Add(new Point(2, y), new Wall());
                _walls.Add(new Point(3, y), new Wall());
                _walls.Add(new Point(4, y), new Wall());
                _walls.Add(new Point(6, y), new Wall());
                _walls.Add(new Point(7, y), new Wall());
                _walls.Add(new Point(8, y), new Wall());
                _walls.Add(new Point(10, y), new Wall());
                _walls.Add(new Point(11, y), new Wall());
                _walls.Add(new Point(12, y), new Wall());
                _walls.Add(new Point(14, y), new Wall());
                _walls.Add(new Point(15, y), new Wall());
                _walls.Add(new Point(16, y), new Wall());
            }

            for (int y = 7; y <= 11; y += 4)
            {
                _walls.Add(new Point(2, y), new Wall());
                _walls.Add(new Point(6, y), new Wall());
                _walls.Add(new Point(7, y), new Wall());
                _walls.Add(new Point(11, y), new Wall());
                _walls.Add(new Point(12, y), new Wall());
                _walls.Add(new Point(16, y), new Wall());
            }

            for (int y = 8; y <= 10; y += 2)
            {
                _walls.Add(new Point(2, y), new Wall());
                _walls.Add(new Point(4, y), new Wall());
                _walls.Add(new Point(5, y), new Wall());
                _walls.Add(new Point(6, y), new Wall());
                _walls.Add(new Point(7, y), new Wall());
                _walls.Add(new Point(11, y), new Wall());
                _walls.Add(new Point(12, y), new Wall());
                _walls.Add(new Point(13, y), new Wall());
                _walls.Add(new Point(14, y), new Wall());
                _walls.Add(new Point(16, y), new Wall());
            }

            for (int x = 1; x <= 17; x += 1)
            {
                _coins.Add(new Point(x, 9), new Coin());
            }

            for (int y = 1; y <= 17; y += 16)
            {
                _coins.Add(new Point(5, y), new Coin());
                _coins.Add(new Point(13, y), new Coin());
            }

            for (int y = 2; y <= 16; y += 14)
            {
                _coins.Add(new Point(5, y), new Coin());
                _coins.Add(new Point(13, y), new Coin());
            }

            for (int y = 3; y <= 15; y += 12)
            {
                _coins.Add(new Point(3, y), new Coin());
                _coins.Add(new Point(4, y), new Coin());
                _coins.Add(new Point(5, y), new Coin());
                _coins.Add(new Point(7, y), new Coin());
                _coins.Add(new Point(8, y), new Coin());
                _coins.Add(new Point(10, y), new Coin());
                _coins.Add(new Point(11, y), new Coin());
                _coins.Add(new Point(13, y), new Coin());
                _coins.Add(new Point(14, y), new Coin());
                _coins.Add(new Point(15, y), new Coin());
            }

            for (int y = 4; y <= 14; y += 10)
            {
                _coins.Add(new Point(3, y), new Coin());
                _coins.Add(new Point(7, y), new Coin());
                _coins.Add(new Point(11, y), new Coin());
                _coins.Add(new Point(15, y), new Coin());
            }

            for (int y = 5; y <= 13; y += 8)
            {
                _coins.Add(new Point(3, y), new Coin());
                _coins.Add(new Point(4, y), new Coin());
                _coins.Add(new Point(5, y), new Coin());
                _coins.Add(new Point(7, y), new Coin());
                _coins.Add(new Point(8, y), new Coin());
                _coins.Add(new Point(10, y), new Coin());
                _coins.Add(new Point(11, y), new Coin());
                _coins.Add(new Point(13, y), new Coin());
                _coins.Add(new Point(14, y), new Coin());
                _coins.Add(new Point(15, y), new Coin());
            }

            for (int y = 6; y <= 12; y += 6)
            {
                _coins.Add(new Point(5, y), new Coin());
                _coins.Add(new Point(13, y), new Coin());
            }

            for (int y = 7; y <= 11; y += 4)
            {
                _coins.Add(new Point(3, y), new Coin());
                _coins.Add(new Point(4, y), new Coin());
                _coins.Add(new Point(5, y), new Coin());
                _coins.Add(new Point(8, y), new Coin());
                _coins.Add(new Point(9, y), new Coin());
                _coins.Add(new Point(10, y), new Coin());
                _coins.Add(new Point(13, y), new Coin());
                _coins.Add(new Point(14, y), new Coin());
                _coins.Add(new Point(15, y), new Coin());
            }

            for (int y = 8; y <= 10; y += 2)
            {
                _coins.Add(new Point(3, y), new Coin());
                _coins.Add(new Point(15, y), new Coin());
            }

            foreach (var wall in _walls) Add(wall.Value, wall.Key); ;
            foreach (var coin in _coins) Add(coin.Value, coin.Key);
        }
    }
}