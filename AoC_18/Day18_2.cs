namespace AoC_18
{
    public static class Day18_2
    {
        public static void Task()
        {
            ARM Dankec = new ARM();
            Dankec.LoadProgram(Core.Input);

            Dankec.Simulate();
        }
    }
}
