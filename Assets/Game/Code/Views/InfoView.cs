using UnityEngine;
using UnityEngine.UI;

namespace Game.Code.Views
{
    public class InfoView : ViewBase
    {
        [SerializeField] private Text _textView;

        public void SetText(string text)
        {
            _textView.text = text;
        }

        public void SetTextColor(Color color)
        {
            _textView.color = color;
        }
    }
}