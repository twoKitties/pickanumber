using System;

namespace Game.Code.Models
{
    public class InputModel
    {
        public readonly int Max;
        public event Action onValueChanged;

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                onValueChanged?.Invoke();
            }
        }

        private int _value;

        public InputModel(int max)
        {
            Max = max;
        }

        public void Reset()
        {
            _value = 0;
        }
    }
}