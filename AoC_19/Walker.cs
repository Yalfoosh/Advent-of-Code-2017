using System;

namespace AoC_19
{
    public class Walker
    {
        enum TileType
        {
            Empty = 0,
            Vertical = 1,
            Horizontal = 2,
            Crossroad = 3,
            Other = 4
        }

        enum Direction
        {
            Standstill = 0,
            Up = 1,
            Left = 2,
            Down = 3,
            Right = 4
        }

        private string[] _route;
        private Tuple<int, int> _direction;

        private int[] _coords;

        private string _encountered;
        private long _steps;
        private long _letterAmount;

        public Walker(string[] map)
        {
            _route = map;
            _direction = SetDirection(Direction.Down);
            _coords = DetermineStart();
            _encountered = "";
        }

        public string WalkItOut()
        {
            _encountered = "";
            _steps = 0;

            _letterAmount = 0;

            foreach (string s in _route)
            foreach (char c in s)
                if (c >= 'A' && c <= 'Z')
                    ++_letterAmount;

            long encounteredLetters = 0;

            while (CanMoveAtAll())
            {
                var current = MoveNext();

                if (encounteredLetters < _letterAmount)
                    ++_steps;

                if (DetermineTileType(current) == TileType.Other)
                {
                    ++encounteredLetters;

                    if (encounteredLetters <= _letterAmount)
                        _encountered += current;
                }
            }

            ++_steps;

            return _encountered;
        }

        public long StepsTotal()
        {
            _letterAmount = 0;

            foreach(string s in _route)
                foreach(char c in s)
                    if (c >= 'A' && c <= 'Z')
                        ++_letterAmount;

            WalkItOut();
            return _steps;
        }

        private int[] DetermineStart()
        {
            int[] toRet = new int[2];
            toRet[1] = 0;

            for (int i = 0; i < _route[0].Length; ++i)
                if (DetermineTileType(_route[0][i]) == TileType.Vertical)
                    toRet[0] = i;

            return toRet;
        }
        private TileType DetermineTileType(char x)
        {
            switch (x)
            {
                case ' ':
                    return TileType.Empty;

                case '|':
                    return TileType.Vertical;

                case '-':
                    return TileType.Horizontal;

                case '+':
                    return TileType.Crossroad;
            }

            return TileType.Other;
        }

        private Tuple<int, int> SetDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Standstill:
                    return Tuple.Create(0, 0);

                case Direction.Up:
                    return Tuple.Create(0, -1);

                case Direction.Left:
                    return Tuple.Create(-1, 0);

                case Direction.Down:
                    return Tuple.Create(0, 1);

                case Direction.Right:
                    return Tuple.Create(1, 0);

                default:
                    return SetDirection(Direction.Standstill);
            }
        }
        private Direction GetDirection(Tuple<int, int> direction)
        {
            if (_direction.Item1 == 0)
            {
                if (_direction.Item2 == 0)
                    return Direction.Standstill;

                if (_direction.Item2 == -1)
                    return Direction.Up;

                    return Direction.Down;
            }

            //Implicitly we know that Item2 is surely to be 0 now because there is no diagonal movement.

            if (_direction.Item1 == -1)
                return Direction.Left;

            return Direction.Right;
        }
        private Direction ReverseDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Standstill:
                    return Direction.Standstill;

                case Direction.Up:
                    return Direction.Down;

                case Direction.Left:
                    return Direction.Right;

                case Direction.Down:
                    return Direction.Up;

                case Direction.Right:
                    return Direction.Left;

                default:
                    return ReverseDirection(Direction.Standstill);
            }
        }
        private Direction GetOppositeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.Standstill:
                    return Direction.Standstill;

                case Direction.Up:
                case Direction.Down:
                    return Direction.Right;

                case Direction.Left:
                case Direction.Right:
                    return Direction.Up;

                default:
                    return GetOppositeDirection(Direction.Standstill);
            }
        }
        private Direction GetNextDirection()
        {
            var currDirection = GetDirection(_direction);
            var assumedDirection = GetOppositeDirection(currDirection);

            if (DetermineTileType(Tile(assumedDirection)) != DetermineTileType(CurrentTile())
                && DetermineTileType(Tile(assumedDirection)) != TileType.Empty)
                return assumedDirection;

            return ReverseDirection(assumedDirection);
        }

        private char CurrentTile() => _route[_coords[1]][_coords[0]];
        private char Tile(Direction direction)
        {
            switch (direction)
            {
                case Direction.Standstill:
                    return CurrentTile();

                case Direction.Up:
                    return _route[_coords[1] - 1][_coords[0]];

                case Direction.Left:
                    return _route[_coords[1]][_coords[0] - 1];

                case Direction.Down:
                    return _route[_coords[1] + 1][_coords[0]];

                case Direction.Right:
                    return _route[_coords[1]][_coords[0] + 1];

                default:
                    return Tile(Direction.Standstill);
            }
        }
        private bool CanMove(Direction direction)
        {
            switch (direction)
            {
                case Direction.Standstill:
                    return true;

                case Direction.Up:
                    return _coords[1] > 0;

                case Direction.Left:
                    return _coords[0] > 0;

                case Direction.Down:
                    return _coords[1] < _route.Length - 1;

                case Direction.Right:
                    return _coords[0] < _route[0].Length - 1;

                default:
                    return false;
            }
        }
        private bool CanMoveAtAll()
        {
            var currDirection = GetDirection(_direction);
            var opposite = GetOppositeDirection(currDirection);

            return CanMove(currDirection) 
                   || CanMove(opposite) && DetermineTileType(Tile(opposite)) != TileType.Empty 
                   || CanMove(ReverseDirection(opposite)) && DetermineTileType(Tile(ReverseDirection(opposite))) != TileType.Empty;
        }
        private char Move(Direction direction)
        {
            var t = SetDirection(direction);

            _coords[0] += t.Item1;
            _coords[1] += t.Item2;

            return _route[_coords[1]][_coords[0]];
        }
        private char MoveNext()
        {
            var currDirection = GetDirection(_direction);

            //Implicitly we know that because we cannot move (shouldn't happen) or because the next Tile is empty, we are at the Crossroads.
            if (!CanMove(currDirection) || DetermineTileType(Tile(currDirection)) == TileType.Empty)
                _direction = SetDirection(GetNextDirection());

            return Move(GetDirection(_direction));
        }
    }
}