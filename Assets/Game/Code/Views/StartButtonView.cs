using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Code.Views
{
    public class StartButtonView : ViewBase
    {
        public event Action onClicked; 
        [SerializeField] private Button _startButton;
        [SerializeField] private Text _textView;

        private void Awake() => _startButton.onClick.AddListener(OnClicked);

        private void OnDestroy() => _startButton.onClick.RemoveListener(OnClicked);

        private void OnClicked() => onClicked?.Invoke();

        public void SetText(string value) => _textView.text = value;
    }
}