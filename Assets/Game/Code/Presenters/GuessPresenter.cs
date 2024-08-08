using System;
using Game.Code.Models;
using Game.Code.Views;
using UnityEngine;

namespace Game.Code.Presenters
{
    public class GuessPresenter : IDisposable
    {
        private readonly GuessView _view;
        private readonly InputModel _model;

        public GuessPresenter(GuessView view, InputModel model)
        {
            _view = view;
            _model = model;
        }

        public void Initialize()
        {
            _model.onValueChanged += ChangeValue;
        }

        public void Dispose()
        {
            _model.onValueChanged -= ChangeValue;
        }

        public void EnableView()
        {
            _view.SetActive(true);
        }

        public void SetText(string value)
        {
            _view.SetText(value);
        }

        private void ChangeValue()
        {
            var value = _model.Value;
            _view.SetText(value.ToString());
        }

        public void SetTextColor(Color color)
        {
            _view.SetTextColor(color);
        }
    }
}