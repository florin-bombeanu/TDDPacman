using System.Data;

namespace Pacman
{
    public class Game
    {
        public int Columns { get; private set; }
        public int Rows { get; private set; }

        public Position PacmanPosition
        {
            get
            {
                return new Position(Columns / 2, Rows / 2);
            }
        }

        public Game(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
            PacmanOrientation = Orientation.Up;
        }

        public Orientation PacmanOrientation { get;  set; }

        public void PacmanTurn(Orientation orientation)
        {
            PacmanOrientation = orientation;
        }
    }
}