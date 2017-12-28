namespace AoC_10
{
    public class Twister
    {
        public byte[] Storage { get; }
        private int _start;
        private int _skipSize;

        public Twister()
        {
            Storage = new byte[256];

            for (int i = 0; i < 256; ++i)
                Storage[i] = (byte)i;
        }

        private void HashIt(int[] lengths, int times = 1)
        {
            _start = 0;
            _skipSize = 0;

            for (int n = 0; n < times; ++n)
                foreach(int i in lengths)
                    HashIteration(i);
        }

        private void HashIteration(int length)
        {
            CopyTo(Storage, _start, Mirror(Select(_start, length)));

            _start = (_start + length + _skipSize++) % Storage.Length;
        }

        private void CopyTo(byte[] destinationArray, int startingIndex, byte[] sourceArray)
        {
            for (int i = 0; i < sourceArray.Length; ++i)
                destinationArray[(startingIndex + i) % destinationArray.Length] = sourceArray[i];
        }

        private byte[] Mirror(byte[] array)
        {
            for (int i = 0; i < array.Length / 2; ++i)
            {
                var t = array[i];
                array[i] = array[array.Length - 1 - i];
                array[array.Length - 1 - i] = t;
            }

            return array;
        }

        private byte[] Select(int startingIndex, int length)
        {
            byte[] toRet = new byte[length];

            for (int i = startingIndex, j = 0; j < length; ++i, ++j)
                toRet[j] = Storage[i % Storage.Length];

            return toRet;
        }

        public int FirstTwoMultiplied(int[] lengths)
        {
            HashIt(lengths);

            return Storage[0] * Storage[1];
        }

        private byte ArrayXOR(byte[] input)
        {
            byte toRet = input[0];

            for (int i = 1; i < input.Length; ++i)
                toRet ^= input[i];

            return toRet;
        }

        private byte[] DenseHash()
        {
            byte[] toRet = new byte[16];

            for (int i = 0; i < 16; ++i)
                toRet[i] = ArrayXOR(Select(i * 16, 16));

            return toRet;
        }

        public byte[] HashSequence(int[] lengths)
        {
            HashIt(lengths, 64);
            return DenseHash();
        }
    }
}