using System;

namespace AoC_14
{
    public class Hasher
    {
        public byte[] Storage { get; }
        private int _start;
        private int _skipSize;

        public Hasher()
        {
            Storage = new byte[256];
            Reset();
        }

        public void Reset()
        {
            for (int i = 0; i < 256; ++i)
                Storage[i] = (byte)i;
        }

        private byte[] Select(int startingIndex, int length)
        {
            byte[] toRet = new byte[length];

            for (int i = startingIndex, j = 0; j < length; ++i, ++j)
                toRet[j] = Storage[i % Storage.Length];

            return toRet;
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

        private void HashIteration(int length)
        {
            CopyTo(Storage, _start, Mirror(Select(_start, length)));

            _start = (_start + length + _skipSize++) % Storage.Length;
        }
        private void HashIt(int[] lengths, int times = 1)
        {
            _start = 0;
            _skipSize = 0;

            for (int n = 0; n < times; ++n)
                foreach (int i in lengths)
                    HashIteration(i);
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

        private byte[] HashSequence(int[] lengths)
        {
            HashIt(lengths, 64);
            return DenseHash();
        }
        private byte[] HashSequence(string input)
        {
            int[] lengths = new int[input.Length + 5];

            for (int i = 0; i < input.Length; ++i)
                lengths[i] = (byte)input[i];

            //WAKE ME UP, WAKE ME UP INSIDE,
            //WAKE ME UP INSIDE, SAVE ME FROM THE NOTHING I'VE BECOOOOOME
            lengths[input.Length] = 17;
            lengths[input.Length + 1] = 31;
            lengths[input.Length + 2] = 73;
            lengths[input.Length + 3] = 47;
            lengths[input.Length + 4] = 23;

            return HashSequence(lengths);
        }
        private string ToHash(byte[] input)
        {
            string toRet = BitConverter.ToString(input);
            return toRet.Replace("-", "").ToLower();
        }

        public string GetKnotHash(string input) => ToHash(HashSequence(input));
    }
}