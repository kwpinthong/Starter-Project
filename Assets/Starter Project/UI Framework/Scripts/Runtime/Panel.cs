using Sirenix.OdinInspector;
using System;
using UnityEngine;

namespace StarterProject.UIFramework
{
    public class Panel : MonoBehaviour
    {
        [SerializeField] protected bool _isInteractable = true;
        protected CanvasGroup _canvasGroup;

        public bool IsInteractable
        {
            get => _isInteractable;
            set
            {
                _isInteractable = value;
                _canvasGroup.interactable = value;
            }
        }

        [Button]
        public void Open()
        {
            PreOpen();
            _Opening(() => PostOpen());
        }

        [Button]
        public void Close()
        {
            PreClose();
            _Closing(() => PostClose());
        }

        private void _Opening(Action completed)
        {
            Opening(completed);
        }

        private void _Closing(Action completed)
        {
            Closing(completed);
        }

        protected virtual void PreOpen()
        {
        }

        protected virtual void Opening(Action completed)
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.blocksRaycasts = true;

            completed?.Invoke();
        }

        protected virtual void PostOpen()
        {
            IsInteractable = true;
        }

        protected virtual void PreClose()
        {
        }

        protected virtual void Closing(Action completed)
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;

            completed?.Invoke();
        }

        protected virtual void PostClose()
        {
            IsInteractable = false;
        }

        private void EnsureGetCanvasGroup()
        {
            if (_canvasGroup == null)
            {
                GetCanvasGroup();
            }
        }

        private void GetCanvasGroup()
        {
            _canvasGroup = GetComponentInChildren<CanvasGroup>();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            EnsureGetCanvasGroup();

            if (_isInteractable != _canvasGroup.interactable)
            {
                _canvasGroup.interactable = _isInteractable;
            }
        }
#endif
    }
}
