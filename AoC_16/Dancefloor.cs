using System;
using System.Collections.Generic;

namespace AoC_16
{
    class Dancefloor
    {
        private Dictionary<string, int> _dancers;
        private string[] _danceSurface;

        public Dancefloor(int size = 16)
        {
            _dancers = new Dictionary<string, int>();
            _danceSurface = new string[size];

            for (int i = 0; i < _danceSurface.Length; ++i)
            {
                _danceSurface[i] = ((char)('a' + i)).ToString();
                _dancers.Add(_danceSurface[i], i);
            }
        }

        private void Swap(string a, string b)
        {
            if (_dancers.ContainsKey(a) && _dancers.ContainsKey(b))
            {
                var t = _dancers[a];

                _dancers[a] = _dancers[b];
                _dancers[b] = t;

                _danceSurface[_dancers[a]] = a;
                _danceSurface[_dancers[b]] = b;
            }
        }

        private void Swap(int a, int b)
        {
            if (a != b && a >= 0 && b >= 0 && _danceSurface.Length > a && _danceSurface.Length > b)
                Swap(_danceSurface[a], _danceSurface[b]);
            else
                Console.WriteLine("Something's wrong.");
        }

        private void Spin(int amount)
        {
            amount %= _dancers.Count;

            string[] tSurface = new string[_danceSurface.Length];
            int j = 0;

            for (int i = tSurface.Length - amount; i < _danceSurface.Length; ++i, ++j)
            {
                tSurface[j] = _danceSurface[i];
                _dancers[tSurface[j]] = j;
            }

            for (int i = 0; j < tSurface.Length && i < _danceSurface.Length; ++j, ++i)
            {
                tSurface[j] = _danceSurface[i];
                _dancers[tSurface[j]] = j;
            }

            _danceSurface = tSurface;
        }

        public void Command(string command)
        {
            switch (command[0])
            {
                case 's':
                    Spin(int.Parse(command.Substring(1)));
                    break;

                case 'x':
                    command = command.Substring(1);
                    var args = command.Split('/');
                    Swap(int.Parse(args[0]), int.Parse(args[1]));
                    break;

                case 'p':
                    command = command.Substring(1);
                    var argss = command.Split('/');
                    Swap(argss[0], argss[1]);
                    break;
            }
        }

        public override string ToString()
        {
            string toRet = "";

            for (int i = 0; i < _danceSurface.Length; ++i)
                toRet += _danceSurface[i];

            return toRet;
        }

        public void SetOrder(string order)
        {
            if (order.Length == _dancers.Count)
            {
                for (int i = 0; i < order.Length; ++i)
                {
                    _danceSurface[i] = order[i].ToString();
                    _dancers[_danceSurface[i]] = i;
                }
            }
        }
    }
}