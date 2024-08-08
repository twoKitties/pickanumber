using System;
using Game.Code.Views;

namespace Game.Code.Presenters
{
    public class StartButtonPresenter : IDisposable
    {
        public event Action onStartClicked;
        private readonly StartButtonView _view;

        public StartButtonPresenter(StartButtonView view) => _view = view;

        public void Initialize() => _view.onClicked += OnStartClicked;

        public void Dispose() => _view.onClicked -= OnStartClicked;

        public void EnableView() => _view.SetActive(true);

        public void DisableView() => _view.SetActive(false);

        public void SetText(string value) => _view.SetText(value);

        private void OnStartClicked() => onStartClicked?.Invoke();
    }
}