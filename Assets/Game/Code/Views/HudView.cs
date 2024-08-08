using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Code.Views
{
    public class HudView : MonoBehaviour
    {
        [SerializeField] private TurnStatusView _turnStatusView;
        [FormerlySerializedAs("_answerView")] [SerializeField] private GuessView _guessView;
        [SerializeField] private InfoView _infoView;
        [SerializeField] private KeyboardView _keyboardView;
        [SerializeField] private StartButtonView _startButtonView;

        public TurnStatusView StatusView => _turnStatusView;
        public GuessView GuessView => _guessView;
        public InfoView InfoView => _infoView;
        public KeyboardView KeyboardView => _keyboardView;
        public StartButtonView ButtonView => _startButtonView;
    }
}