using Game.Code.Views;

namespace Game.Code.Presenters
{
    public class TurnStatusPresenter
    {
        private readonly TurnStatusView _view;

        public TurnStatusPresenter(TurnStatusView view) => _view = view;

        public void EnableView() => _view.SetActive(true);

        public void DisableView() => _view.SetActive(false);

        public void SetText(string value) => _view.SetText(value);
    }
}