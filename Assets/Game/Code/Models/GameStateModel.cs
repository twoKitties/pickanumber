using System;

namespace Game.Code.Models
{
    public class GameStateModel
    {
        public readonly int Min;
        public readonly int Max;
        public int GuessedNumber { get; private set; }
        public int ClosestMin;
        public int ClosestMax;
        private readonly Random _random;

        public GameStateModel(Random random, int max)
        {
            _random = random;
            Min = 0;
            Max = max;
            ClosestMin = 0;
            ClosestMax = Max;
        }

        public void Generate() => GuessedNumber = _random.Next(0, Max);
    }
}