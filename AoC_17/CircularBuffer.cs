using System;
using System.Collections.Generic;

namespace AoC_17
{
    public class CircularBuffer
    {
        private List<int> _buffer;
        private int currentPosition;

        public CircularBuffer(int size = 2018)
        {
            currentPosition = 0;
            _buffer = new List<int>(size);
        }

        //returns the index where it was inserted.
        private int Insert(int steps)
        {
            if (_buffer.Count < 1)
                _buffer.Add(0);
            else
            {
                currentPosition = (currentPosition + steps) % _buffer.Count;

                _buffer.Insert(++currentPosition, _buffer.Count);
            }

            if(_buffer.Count % 100000 == 0)
                Console.WriteLine(_buffer.Count);

            return currentPosition;
        }

        //Returns the first number after times - 1.
        public int Load(int steps, int times = 2018)
        {
            int toRet = 0;

            for(int i = 0; i < times; ++i)
                toRet = Insert(steps);

            return (toRet + 1) % _buffer.Count;
        }

        //Returns the number right from zero.
        public int InsertVirtual(int steps, int amount = 50000001)
        {
            int IndexOfZero = 0;
            int RightFromZero = 0;
            int position = 0;

            for (int i = 0; i < amount; ++i)
            {
                if (i < 1)
                {
                    IndexOfZero = 0;
                    position = 0;
                }
                else
                {
                    position = (position + steps) % i;

                    if (position == IndexOfZero)
                        RightFromZero = i;
                    else if (position < IndexOfZero)
                        ++IndexOfZero;

                    ++position;
                }
            }

            return RightFromZero;
        }

        public int AtIndex(int index) => _buffer[index];
    }
}