using UnityEngine;
using UnityEngine.UI;

namespace Game.Code.Views
{
    public class KeyboardView : ViewBase
    {
        public Button SendButton => _sendButton;
        public Button[] NumberButtons => _numberButtons;
        [SerializeField] private Button _sendButton;
        [SerializeField] private Button[] _numberButtons;
    }
}