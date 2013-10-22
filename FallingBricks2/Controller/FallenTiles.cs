using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FallingBricks2.Controller
{
    public interface IFallenTiles
    {
        Dictionary<int, Tile> Tiles { get; }
        void Add(Tile tile);
        bool Has(Tile tile);
        void RemoveCompletedRowIfRequired(Shape fallingShape, int maxNumberInRow);
    }

    public class FallenTiles : IFallenTiles
    {
        private Dictionary<int, Tile> _tiles;
        public Dictionary<int, Tile> Tiles { get { return _tiles; } }
        public FallenTiles()
        {
            _tiles = new Dictionary<int, Tile>();
        }

        public void Add(Tile tile)
        {
            _tiles.Add(tile.Position.Index, tile);
        }

        public bool Has(Tile tile)
        {
            return _tiles.ContainsKey(tile.Position.Index);
        }

        public void RemoveCompletedRowIfRequired(Shape fallingShape, int maxNumberInRow)
        {
            var rowsToRemove = GetRowsToRemove(fallingShape, maxNumberInRow);
            RemoveRows(rowsToRemove);            
            ShiftTilesDown(rowsToRemove);
        }

        private void ShiftTilesDown(Dictionary<int, IEnumerable<int>> rowsToRemove)
        {
            foreach (var tile in GetTilesThatNeedToShiftDown(rowsToRemove))
            {
                var movedTile = new Tile { Colour = tile.Colour,
                                            Position = new Point(tile.Position.X, tile.Position.Y + rowsToRemove.Count) };
                if(_tiles.ContainsKey(tile.Position.Index))
                    _tiles.Remove(tile.Position.Index);

                if (!_tiles.ContainsKey(movedTile.Position.Index))
                    _tiles.Add(movedTile.Position.Index, movedTile);
            }
        }

        private void RemoveRows(Dictionary<int, IEnumerable<int>> rowsToRemove)
        {
            foreach (var row in rowsToRemove)
            {
                foreach (var key in row.Value)
                    _tiles.Remove(key);
            }
        }

        private List<Tile> GetTilesThatNeedToShiftDown(Dictionary<int, IEnumerable<int>> rowsToRemove)
        {
            var tilesThatNeedToShiftDown = new List<Tile>();
            foreach (var row in rowsToRemove)
                tilesThatNeedToShiftDown.AddRange(_tiles.Where(d => d.Value.Position.Y < row.Key).Select(d => d.Value).ToList());

            tilesThatNeedToShiftDown.Sort(new SortOnPositionIndex());
            return tilesThatNeedToShiftDown;
        }

        private class SortOnPositionIndex : IComparer<Tile>
        {
            public int Compare(Tile a, Tile b)
            {
                if (a.Position.Index < b.Position.Index) return 1;
                else if (a.Position.Index > b.Position.Index) return -1;
                else return 0;
            }
        }

        private Dictionary<int, IEnumerable<int>> GetRowsToRemove(Shape fallingShape, int maxNumberInRow)
        {
            var rowsToRemove = new Dictionary<int, IEnumerable<int>>();
            foreach (var tile in fallingShape.Tiles)
            {
                if (rowsToRemove.ContainsKey(tile.Position.Y))
                    continue;

                var indexes = _tiles.Where(d => d.Value.Position.Y == tile.Position.Y).Select(d => d.Key).ToList();
                if (indexes.Count() == maxNumberInRow)
                    rowsToRemove.Add(tile.Position.Y, indexes);
            }
            return rowsToRemove;
        }
    }
}
