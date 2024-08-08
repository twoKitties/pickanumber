using UnityEngine;

namespace Game.Code.Views
{
    public abstract class ViewBase : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup _canvasGroup;
        
        public virtual void SetActive(bool isActive)
        {
            _canvasGroup.alpha = isActive ? 1 : 0;
            _canvasGroup.blocksRaycasts = isActive;
            _canvasGroup.interactable = isActive;
        }
    }
}