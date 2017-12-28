using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AoC_8
{
    class Evaluator
    {
        private Dictionary<string, long> _storage;
        public long maxSize { get; private set; }

        public Evaluator()
        {
            _storage = new Dictionary<string, long>();
            maxSize = long.MinValue;
        }

        public void Execute(string[] commands)
        {
            foreach (string s in commands)
                Evaluate(s);
        }

        private void Evaluate(string command)
        {
            var args = new Regex(@"\s+").Split(command);

            if (Question(args[4], args[5], args[6]))
            {
                long amount = long.Parse(args[2]);

                if (args[1] == "dec")
                    amount *= -1;

                if (_storage.ContainsKey(args[0]))
                    _storage[args[0]] += amount;
                else
                    _storage.Add(args[0], amount);

                if (_storage[args[0]] > maxSize)
                    maxSize = _storage[args[0]];
            }
        }

        private bool Question(string name, string op, string amount)
        {
            var result = Extract(name).CompareTo(long.Parse(amount));

            switch (op)
            {
                case "==":
                    return result == 0;
                case "!=":
                    return result != 0;

                case ">":
                    return result > 0;
                case "<":
                    return result < 0;

                case ">=":
                    return result >= 0;
                case "<=":
                    return result <= 0;
            }

            return false;
        }

        public long Extract(string name)
        {
            if (_storage.ContainsKey(name))
                return _storage[name];

            return 0;
        }

        public long Largest()
        {
            long Largest = long.MinValue;

            foreach(var s in _storage)
                if (_storage[s.Key] > Largest)
                    Largest = _storage[s.Key];

            return Largest;
        }
    }
}