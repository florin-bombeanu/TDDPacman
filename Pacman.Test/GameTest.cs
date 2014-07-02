using NFluent;
using NUnit.Framework;

namespace Pacman.Test
{
    [TestFixture]
    public class GameTest
    {

        [Test]
        public void GivenTheInitialGame_PacmanIsInTheMiddleOfTheBoard()
        {
            Check.That(VisualBoardForPacman(new Game(3, 4))).Equals(
                new VisualBoard(
                    "...",
                    "...",
                    ".P.",
                    "..."));

            Check.That(VisualBoardForPacman(new Game(3, 3))).Equals(
               new VisualBoard(
                   "...",
                   ".P.",
                   "..."));
        }

        [Test]
        public void GivenTheInitialGame_PacmanOrientationIsUp()
        {
            var game = new Game(3, 4);
            Check.That(game.PacmanOrientation).Equals(Orientation.Up);
        }

        [TestCase(Orientation.Left)]
        [TestCase(Orientation.Right)]
        [TestCase(Orientation.Up)]
        [TestCase(Orientation.Down)]
        public void PacmanChangesOrientation(Orientation turnOrientation)
        {
            var game = new Game(3, 4);

            game.PacmanTurn(turnOrientation);

            Check.That(game.PacmanOrientation).Equals(turnOrientation);
        }

        private VisualBoard VisualBoardForPacman(Game game)
        {
            return new VisualBoardBuilder()
                .WithColumns(game.Columns)
                .WithRows(game.Rows)
                .WithEmptyCell('.')
                .WithPositions('P', game.PacmanPosition)
                .Build();
        }

        //private Position GetPacmanPosition(VisualBoard board)
        //{
        //   // return board.FindPositions('P').Single();
        //}

        //private Position GetWallPosition(VisualBoard board)
        //{
        ////    return board.FindPositions('W').Single();
        //}
    }
}
