using System;
using Game.Code.Models;
using Game.Code.Views;
using PrimeTween;

namespace Game.Code.Presenters
{
    public class InfoPresenter
    {
        private readonly InfoView _view;
        private readonly InputModel _model;

        public InfoPresenter(InfoView view, InputModel model)
        {
            _view = view;
            _model = model;
        }

        public void EnableView()
        {
            _view.SetActive(true);
        }

        public void DisableView()
        {
            _view.SetActive(false);
        }

        public void SetText(string value)
        {
            _view.SetText(value);
        }

        public void RunWithDelay(Action action)
        {
            Sequence.Create(2, CycleMode.Yoyo)
                .Chain(Tween.Delay(1f, () => _view.SetText("NUMBER PICKED"))
                    .Chain(Tween.Delay(1f, () =>
                    {
                        _view.SetText("");
                        action?.Invoke();
                    })));
        }
    }
}