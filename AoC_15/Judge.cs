namespace AoC_15
{
    public class Judge
    {
        private Generator A;
        private Generator B;

        public Judge(Generator a, Generator b)
        {
            A = a;
            B = b;
        }

        public ulong Evaluate(ulong pairNumber)
        {
            A.Reset();
            B.Reset();

            ulong count = 0;

            for(ulong i = 0; i < pairNumber; ++i)
                if (isSimilar(A.GenerateNext(), B.GenerateNext()))
                    ++count;

            return count;
        }

        private bool isSimilar(long? first, long? second) => (first & 0xffff) == (second & 0xffff);
    }
}