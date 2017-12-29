using System;
using System.Collections.Generic;

namespace AoC_18
{
    public class FRISC
    {
        private Dictionary<char, long> _memory;
        private long _PC;
        private long _maxRuns = 100000;
        private string[][] _instructions;
        private long? _lastFrequency;
        private long? _lastPrint;

        public FRISC()
        {
            _memory = new Dictionary<char, long>();
        }

        public void LoadProgram(string[] instructions)
        {
            _instructions = new string[instructions.Length][];

            for (int i = 0; i < instructions.Length; ++i)
                _instructions[i] = instructions[i].Split(' ');
        }

        public void Execute()
        {
            int ran = 0;

            for (_PC = 0; _PC < _instructions.Length && _PC >= 0 && ran < _maxRuns; ++_PC, ++ran)
            {
                switch (_instructions[_PC][0])
                {
                    case "snd":
                        if(IsRegister(_instructions[_PC][1]))
                            Sound(_instructions[_PC][1][0]);
                        else
                            Sound(long.Parse(_instructions[_PC][1]));
                        break;

                    case "set":
                        if(IsRegister(_instructions[_PC][2]))
                            Set(_instructions[_PC][1][0], _instructions[_PC][2][0]);
                        else
                            Set(_instructions[_PC][1][0], long.Parse(_instructions[_PC][2]));
                        break;

                    case "add":
                        if (IsRegister(_instructions[_PC][2]))
                            Add(_instructions[_PC][1][0], _instructions[_PC][2][0]);
                        else
                            Add(_instructions[_PC][1][0], long.Parse(_instructions[_PC][2]));
                        break;

                    case "mul":
                        if (IsRegister(_instructions[_PC][2]))
                            Multiply(_instructions[_PC][1][0], _instructions[_PC][2][0]);
                        else
                            Multiply(_instructions[_PC][1][0], long.Parse(_instructions[_PC][2]));
                        break;

                    case "mod":
                        if (IsRegister(_instructions[_PC][2]))
                            Modulus(_instructions[_PC][1][0], _instructions[_PC][2][0]);
                        else
                            Modulus(_instructions[_PC][1][0], long.Parse(_instructions[_PC][2]));
                        break;

                    case "rcv":
                        if (IsRegister(_instructions[_PC][1]))
                            Receive(_instructions[_PC][1][0]);
                        else
                            Receive(long.Parse(_instructions[_PC][1]));
                        break;

                    case "jgz":
                        if (IsRegister(_instructions[_PC][1]))
                        {
                            if (IsRegister(_instructions[_PC][2]))
                                Jump(_instructions[_PC][1][0], _instructions[_PC][2][0]);
                            else
                                Jump(_instructions[_PC][1][0], long.Parse(_instructions[_PC][2]));
                        }
                        else
                        {
                            if (IsRegister(_instructions[_PC][2]))
                                Jump(long.Parse(_instructions[_PC][1]), _instructions[_PC][2][0]);
                            else
                                Jump(long.Parse(_instructions[_PC][1]), long.Parse(_instructions[_PC][2]));
                        }
                        break;
                }
            }
        }

        private bool IsRegister(string parameter) => parameter.Length == 1 && parameter[0] >= 'a' && parameter[0] <= 'z';

        private long Fetch(char registerName)
        {
            if (_memory.ContainsKey(registerName))
                return _memory[registerName];

            return 0;
        }
        private void Write(char registerName, long value)
        {
            if (_memory.ContainsKey(registerName))
                _memory[registerName] = value;
            else
                _memory.Add(registerName, value);
        }

        #region COMMANDS

        private void Sound(long frequency) => _lastFrequency = frequency;
        private void Sound(char registerName) => Sound(Fetch(registerName));

        private void Set(char receivingRegisterName, long value) => Write(receivingRegisterName, value);
        private void Set(char receivingRegisterName, char donatingRegisterName) =>
            Set(receivingRegisterName, Fetch(donatingRegisterName));

        private void Add(char receivingRegisterName, long value) =>
            Write(receivingRegisterName, Fetch(receivingRegisterName) + value);
        private void Add(char receivingRegisterName, char donatingRegisterName) =>
            Add(receivingRegisterName, Fetch(donatingRegisterName));

        private void Multiply(char receivingRegisterName, long value) =>
            Write(receivingRegisterName, Fetch(receivingRegisterName) * value);
        private void Multiply(char receivingRegisterName, char donatingRegisterName) =>
            Multiply(receivingRegisterName, Fetch(donatingRegisterName));

        private void Modulus(char receivingRegisterName, long value)
        {
            if (value != 0)
                Write(receivingRegisterName, Fetch(receivingRegisterName) % value);
        }
        private void Modulus(char receivingRegisterName, char donatingRegisterName) =>
            Modulus(receivingRegisterName, Fetch(donatingRegisterName));

        private void Receive(long value)
        {
            if (value != 0 && _lastFrequency != _lastPrint)
                Console.WriteLine("[Task 1]   The last frequency played is " + (_lastPrint = _lastFrequency) + ".");
        }
        private void Receive(char registerName) => Receive(Fetch(registerName));

        private void Jump(long value, long jumpAmount) => _PC += value > 0 ? jumpAmount - 1 : 0;
        private void Jump(long value, char registerName) => Jump(value, Fetch(registerName));
        private void Jump(char registerName, long jumpAmount) => Jump(Fetch(registerName), jumpAmount);
        private void Jump(char registerName, char alterationRegisterName) =>
            Jump(Fetch(registerName), Fetch(alterationRegisterName));

        #endregion
    }
}