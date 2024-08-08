using System;
using System.Collections.Generic;
using Game.Code.Services;

namespace Game.Code.Core
{
    public class Bot
    {
        private readonly int _min;
        private readonly int _max;
        private readonly GameStateModel _gameStateModel;
        private readonly HashSet<int> _generatedNumbers;
        private readonly Random _random;

        public Bot(int min, int max, GameStateModel gameStateModel)
        {
            _min = min;
            _max = max;
            _gameStateModel = gameStateModel;
            _generatedNumbers = new HashSet<int>(max);
            _random = new Random();
        }

        public int GetNumber()
        {
            if (_generatedNumbers.Count >= (_max - _min + 1))
            {
                _generatedNumbers.TryGetValue(_random.Next(_min, _max), out var result);
                return result;
            }

            int number;
            var closestMin = _gameStateModel.ClosestMin;
            var closestMax = _gameStateModel.ClosestMax;
            do
            {
                number = _random.Next(closestMin + 1, closestMax - 1);
            } while (_generatedNumbers.Contains(number));

            _generatedNumbers.Add(number);
            return number;
        }
    }
}