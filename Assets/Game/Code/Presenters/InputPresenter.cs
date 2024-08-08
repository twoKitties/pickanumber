using System;
using Game.Code.Models;
using Game.Code.Views;
using Random = System.Random;

namespace Game.Code.Presenters
{
    public class InputPresenter : IDisposable
    {
        private readonly KeyboardView _view;
        private readonly InputModel _model;
        private readonly Random _random;
        private readonly int[] _map;
        private int _currentInput;
        private Action _onInputSentCallback;

        public InputPresenter(KeyboardView view, InputModel model)
        {
            _view = view;
            _model = model;
            _map = new int[view.NumberButtons.Length];
            var seed = UnityEngine.Random.Range(-_map.Length, _map.Length);
            _random = new Random(seed);
        }

        public void Initialize()
        {
            _view.SendButton.onClick.AddListener(SendGuess);
            for (var i = 0; i < _view.NumberButtons.Length; i++)
            {
                var button = _view.NumberButtons[i];
                var index = i;
                button.onClick.AddListener(() => HandleInput(index));
                
                _map[i] = i;
            }
        }

        public void Dispose()
        {
            _view.SendButton.onClick.RemoveListener(SendGuess);
            foreach (var button in _view.NumberButtons)
            {
                button.onClick.RemoveAllListeners();
            }
        }

        public void EnableView()
        {
            for (var i = 0; i < _map.Length; i++)
            {
                var textView = _view.NumberButtons[i].GetComponentInChildren<UnityEngine.UI.Text>();
                textView.text = _map[i].ToString();
            }
            _view.SetActive(true);
        }

        public void DisableView()
        {
            ShuffleInput(_map);
            _view.SetActive(false);
        }

        public void Reset()
        {
            _currentInput = 0;
        }

        private void HandleInput(int input)
        {
            var number = _map[input];
            var tempInput = _currentInput * 10 + number;
            
            if (_currentInput > _model.Max)
            {
                MakePing();
            }
            else
            {
                _currentInput = tempInput;
                _model.Value = tempInput;
            }
        }

        private void SendGuess()
        {
            //TODO invoke next state
            //_model.OnValueApplied();
            _onInputSentCallback?.Invoke();
        }

        private void ShuffleInput<T>(T[] map)
        {
            var n = map.Length;
            for (var i = n - 1; i > 0; i--)
            {
                var j = _random.Next(0, i + 1);
                (map[i], map[j]) = (map[j], map[i]);
            }
        }

        private void MakePing()
        {
            //TODO pinmg with answer view
            //TODO or just notify model, guess presenter will handle this
        }

        public void AddCallback(Action onInputSentCallback)
        {
            _onInputSentCallback = onInputSentCallback;
        }
    }
}