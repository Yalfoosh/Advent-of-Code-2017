using System.Collections.Generic;

namespace AoC_15
{
    public class Generator
    {
        private const long Divisor = 2147483647;

        private readonly long _startingNumber;
        private readonly long _multiplier;

        public long? LastGenerated { get; private set; }

        private readonly long _multiple;

        public Generator(long startingNumber = 941, long multiplier = 11860, long multiple = 1)
        {
            _startingNumber = startingNumber;
            _multiplier = multiplier;

            _multiple = multiple;

            Reset();
        }

        public long? GenerateNext()
        {
            while ((LastGenerated = _multiplier * (LastGenerated ?? _startingNumber) % Divisor) % _multiple != 0);

            return LastGenerated;
        }

        public void Reset()
        {
            LastGenerated = null;
        }
    }
}