using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AoC_18
{
    public class ARM
    {
        private List<Dictionary<char, long>> _memory;
        private List<long> _PC;

        private List<Queue<long>> _queue;

        private string[][] _instructions;

        private bool[] Waiting;
        private ulong ProgramOneSending;
        private ulong ProgramZeroReceiving;

        public ARM()
        {
            _memory = new List<Dictionary<char, long>>();
            _PC = new List<long>();
            _queue = new List<Queue<long>>();
        }

        public void LoadProgram(string[] instructions)
        {
            _instructions = new string[instructions.Length][];

            for (int i = 0; i < instructions.Length; ++i)
                _instructions[i] = instructions[i].Split(' ');
        }

        public void Simulate()
        {
            _memory.Add(new Dictionary<char, long>());
            _memory.Add(new Dictionary<char, long>());
            _PC.Add(0);
            _PC.Add(0);
            _queue.Add(new Queue<long>());
            _queue.Add(new Queue<long>());

            Waiting = new bool[2];
            Waiting[0] = Waiting[1] = false;
            ProgramOneSending = 0;
            ProgramZeroReceiving = 0;

            Console.Write("\n");

            Task.Factory.StartNew(() => Execute(false));
            Task.Factory.StartNew(() => Execute(true));
        }

        private void Execute(bool indexOne)
        {
            Console.WriteLine("Started " + (indexOne ? "1" : "0") + ".");
            Thread.Sleep(20);

            var index = indexOne ? 1 : 0;
            _memory[index].Add('p', index);

            for (_PC[index] = 0; _PC[index] < _instructions.Length && _PC[index] >= 0 && (!(Waiting[0] && Waiting[1]) || (_queue[0].Count > 0 || _queue[1].Count > 0)); ++_PC[index])
            {
                switch (_instructions[_PC[index]][0])
                {
                    case "snd":
                        if (IsRegister(_instructions[_PC[index]][1]))
                            Send(_instructions[_PC[index]][1][0], indexOne);
                        else
                            Send(long.Parse(_instructions[_PC[index]][1]), indexOne);
                        break;

                    case "set":
                        if (IsRegister(_instructions[_PC[index]][2]))
                            Set(_instructions[_PC[index]][1][0], _instructions[_PC[index]][2][0], indexOne);
                        else
                            Set(_instructions[_PC[index]][1][0], long.Parse(_instructions[_PC[index]][2]), indexOne);
                        break;

                    case "add":
                        if (IsRegister(_instructions[_PC[index]][2]))
                            Add(_instructions[_PC[index]][1][0], _instructions[_PC[index]][2][0], indexOne);
                        else
                            Add(_instructions[_PC[index]][1][0], long.Parse(_instructions[_PC[index]][2]), indexOne);
                        break;

                    case "mul":
                        if (IsRegister(_instructions[_PC[index]][2]))
                            Multiply(_instructions[_PC[index]][1][0], _instructions[_PC[index]][2][0], indexOne);
                        else
                            Multiply(_instructions[_PC[index]][1][0], long.Parse(_instructions[_PC[index]][2]), indexOne);
                        break;

                    case "mod":
                        if (IsRegister(_instructions[_PC[index]][2]))
                            Modulus(_instructions[_PC[index]][1][0], _instructions[_PC[index]][2][0], indexOne);
                        else
                            Modulus(_instructions[_PC[index]][1][0], long.Parse(_instructions[_PC[index]][2]), indexOne);
                        break;

                    case "rcv":
                        if (IsRegister(_instructions[_PC[index]][1]))
                            Receive(_instructions[_PC[index]][1][0], indexOne);
                        break;

                    case "jgz":
                        if (IsRegister(_instructions[_PC[index]][1]))
                        {
                            if (IsRegister(_instructions[_PC[index]][2]))
                                Jump(_instructions[_PC[index]][1][0], _instructions[_PC[index]][2][0], indexOne);
                            else
                                Jump(_instructions[_PC[index]][1][0], long.Parse(_instructions[_PC[index]][2]), indexOne);
                        }
                        else
                        {
                            if (IsRegister(_instructions[_PC[index]][2]))
                                Jump(long.Parse(_instructions[_PC[index]][1]), _instructions[_PC[index]][2][0], indexOne);
                            else
                                Jump(long.Parse(_instructions[_PC[index]][1]), long.Parse(_instructions[_PC[index]][2]), indexOne);
                        }
                        break;
                }

                while (Waiting[index] && !Waiting[1 - index])
                    Receive(_instructions[_PC[index]][1][0], indexOne);
            }

            if (indexOne)
            {
                Console.WriteLine("\n[Task 2]   Program 1 sent a number " + ProgramOneSending + " times.");
                Console.WriteLine("[Task 2]   Program 0 received a number " + ProgramZeroReceiving + " times.");
            }
            
        }

        private bool IsRegister(string parameter) => parameter.Length == 1 && parameter[0] >= 'a' && parameter[0] <= 'z';

        private long Fetch(char registerName, bool indexOne)
        {
            var index = indexOne ? 1 : 0;

            if (_memory[index].ContainsKey(registerName))
                return _memory[index][registerName];

            return 0;
        }
        private void Write(char registerName, long value, bool indexOne)
        {
            var index = indexOne ? 1 : 0;

            if (_memory[index].ContainsKey(registerName))
                _memory[index][registerName] = value;
            else
                _memory[index].Add(registerName, value);
        }

        #region COMMANDS

        private void Send(long value, bool indexOne)
        {
            var index = indexOne ? 1 : 0;

            //For some reason this thing wont run without Console.Writing. I assume it is thread related, but am not smart enough yet to know for sure.
            _queue[1 - index].Enqueue(value);
            Console.Write(".");

            if (indexOne)
                ++ProgramOneSending;
        }

        private void Send(char registerName, bool indexOne) => Send(Fetch(registerName, indexOne), indexOne);



        private void Set(char receivingRegisterName, long value, bool indexOne) => Write(receivingRegisterName, value, indexOne);

        private void Set(char receivingRegisterName, char donatingRegisterName, bool indexOne) =>
            Set(receivingRegisterName, Fetch(donatingRegisterName, indexOne), indexOne);



        private void Add(char receivingRegisterName, long value, bool indexOne) =>
            Write(receivingRegisterName, Fetch(receivingRegisterName, indexOne) + value, indexOne);

        private void Add(char receivingRegisterName, char donatingRegisterName, bool indexOne) =>
            Add(receivingRegisterName, Fetch(donatingRegisterName, indexOne), indexOne);



        private void Multiply(char receivingRegisterName, long value, bool indexOne) =>
            Write(receivingRegisterName, Fetch(receivingRegisterName, indexOne) * value, indexOne);

        private void Multiply(char receivingRegisterName, char donatingRegisterName, bool indexOne) =>
            Multiply(receivingRegisterName, Fetch(donatingRegisterName, indexOne), indexOne);



        private void Modulus(char receivingRegisterName, long value, bool indexOne)
        {
            if (value != 0)
                Write(receivingRegisterName, Fetch(receivingRegisterName, indexOne) % value, indexOne);
        }

        private void Modulus(char receivingRegisterName, char donatingRegisterName, bool indexOne) =>
            Modulus(receivingRegisterName, Fetch(donatingRegisterName, indexOne), indexOne);



        private void Receive(char registerName, bool indexOne)
        {
            var index = indexOne ? 1 : 0;

            if (_queue[index].Count > 0)
            {
                Write(registerName, _queue[index].Dequeue(), indexOne);

                if (Waiting[index])
                    Waiting[index] = false;

                if (!indexOne)
                    ++ProgramZeroReceiving;
            }
            else
                Waiting[index] = true;
        }



        private void Jump(long value, long jumpAmount, bool indexOne) => _PC[indexOne ? 1 : 0] += value > 0 ? jumpAmount - 1 : 0;
        private void Jump(long value, char registerName, bool indexOne) => Jump(value, Fetch(registerName, indexOne), indexOne);
        private void Jump(char registerName, long jumpAmount, bool indexOne) => Jump(Fetch(registerName, indexOne), jumpAmount, indexOne);
        private void Jump(char registerName, char alterationRegisterName, bool indexOne) =>
            Jump(Fetch(registerName, indexOne), Fetch(alterationRegisterName, indexOne), indexOne);

        #endregion
    }
}