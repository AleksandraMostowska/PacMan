using PacMan.GameObjectsHandler;
using PacMan.MapHandler;
using PacMan.MapHandler.Maps;

namespace PacMan
{
    public class GameManager
    {
        public Map Map { get; }
        public List<IGameObj> GameObjs { get; }
        public Pacman Pacman { get; }

        public GameManager(Map map, List<IGameObj> gameObjs)
        {
            Map = map;
            GameObjs = gameObjs;

            // Znajdź Pacmana wśród obiektów gry
            Pacman = gameObjs.OfType<Pacman>().FirstOrDefault()
                ?? throw new InvalidOperationException("No Pacman found in the game.");
        }

        public GameState GetGameState()
        {
            var ghosts = GameObjs.OfType<Ghost>().Select(g => g.Position).ToList();
            var walls = Map.Walls.Keys.ToList();
            var coins = Map.Coins.Keys.ToList();

            return new GameState(Pacman.Position, ghosts, walls, coins);
        }

        public GameState MovePacman(Direction direction)
        {
            Pacman.Go(direction);

            foreach (var ghost in GameObjs.OfType<Ghost>())
            {
                ghost.Go();
            }

            return GetGameState();
        }
    }

    public class GameState
    {
        public Point PacmanPosition { get; }
        public List<Point> GhostPositions { get; }
        public List<Point> WallPositions { get; }
        public List<Point> CoinPositions { get; }

        public GameState(Point pacmanPosition, List<Point> ghostPositions, List<Point> wallPositions, List<Point> coinPositions)
        {
            PacmanPosition = pacmanPosition;
            GhostPositions = ghostPositions;
            WallPositions = wallPositions;
            CoinPositions = coinPositions;
        }
    }
}
