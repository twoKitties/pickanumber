using System;
using Game.Code.Models;
using Game.Code.Presenters;

namespace Game.Code.Services
{
    public class PresenterProvider : IService, IDisposable
    {
        public InputPresenter InputPresenter { get; private set; }
        public InfoPresenter InfoPresenter { get; private set; }
        public StartButtonPresenter StartButtonPresenter { get; private set; }
        public TurnStatusPresenter TurnStatusPresenter { get; private set; }
        public GuessPresenter GuessPresenter { get; private set; }
        private readonly UIFactory _uiFactory;
        private readonly InputModel _inputModel;

        public PresenterProvider(UIFactory uiFactory, InputModel inputModel)
        {
            _uiFactory = uiFactory;
            _inputModel = inputModel;
        }

        public void Initialize()
        {
            InputPresenter = new InputPresenter(_uiFactory.CreateUI().KeyboardView, _inputModel);
            InputPresenter.Initialize();
            InfoPresenter = new InfoPresenter(_uiFactory.CreateUI().InfoView, _inputModel);
            StartButtonPresenter = new StartButtonPresenter(_uiFactory.CreateUI().ButtonView);
            StartButtonPresenter.Initialize();
            TurnStatusPresenter = new TurnStatusPresenter(_uiFactory.CreateUI().StatusView);
            GuessPresenter = new GuessPresenter(_uiFactory.CreateUI().GuessView, _inputModel);
            GuessPresenter.Initialize();
        }

        public void Dispose()
        {
            InputPresenter?.Dispose();
            StartButtonPresenter?.Dispose();
            GuessPresenter.Dispose();
        }
    }
}