using System.Collections.Generic;
using System.Linq;

namespace Pacman.Test
{
    internal class VisualBoardBuilder
    {
        private int _columns;
        private int _rows;
        private char _emptyCell;
        private readonly Dictionary<char, Position[]> _cellToPositions;
        private char[,] _board;

        public VisualBoardBuilder()
        {
            _cellToPositions = new Dictionary<char, Position[]>();
        }

        public VisualBoardBuilder WithColumns(int columns)
        {
            _columns = columns;
            return this;
        }

        public VisualBoardBuilder WithRows(int rows)
        {
            _rows = rows;
            return this;
        }

        public VisualBoardBuilder WithEmptyCell(char cell)
        {
            _emptyCell = cell;
            return this;
        }

        public VisualBoardBuilder WithPositions(char cell, params Position[] positions)
        {
            _cellToPositions.Add(cell, positions);
            return this;
        }

        public VisualBoard Build()
        {
            InitBoard();
            PlaceEmptyCells();
            PlacePositions();
            return MakeVisualBoard();
        }

        private void InitBoard()
        {
            _board = new char[_rows, _columns];
        }

        private string MakeLine(int row)
        {
            return new string(
                Enumerable.Range(0, _columns)
                    .Select(column => _board[row, column])
                    .ToArray());
        }

        private void PlacePositions()
        {
            foreach (var cell in _cellToPositions.Keys)
            {
                foreach (var position in _cellToPositions[cell])
                {
                    _board[position.Row, position.Column] = cell;
                }
            }
        }

        private void PlaceEmptyCells()
        {
            for (var i = 0; i < _rows; i++)
                for (var j = 0; j < _columns; j++)
                {
                    _board[i, j] = _emptyCell;
                }
        }

        private VisualBoard MakeVisualBoard()
        {
            return new VisualBoard(
                Enumerable
                    .Range(0, _rows)
                    .Select(MakeLine)
                    .ToArray());
        }
    }
}