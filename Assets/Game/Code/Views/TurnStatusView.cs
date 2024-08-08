using UnityEngine;
using UnityEngine.UI;

namespace Game.Code.Views
{
    public class TurnStatusView : ViewBase
    {
        [SerializeField] private Text _textView;

        public void SetText(string text)
        {
            _textView.text = text;
        }
    }
}