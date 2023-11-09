using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace StarterProject.ControllerLib
{
    public class Controller : MonoBehaviour
    {
        public enum Type
        {
            MouseKeyboard,
            Gamepad,
        }

        private static Controller _instance;

        public static Type CurrentType = Type.MouseKeyboard;
        public static event Action OnGamepadConnected;
        public static event Action OnCancel;

        public static void SetSelectedGameObject(GameObject gameObject)
        {
            if (EventSystem.current)
            {
                EventSystem.current.SetSelectedGameObject(gameObject);
            }
        }

        [SerializeField] private PlayerInput _playerInput;
        [SerializeField] private bool _dontDestroyOnLoad = true;

        private void Awake()
        {
            if (_instance)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;

            if (_dontDestroyOnLoad)
            {
                DontDestroyOnLoad(gameObject);
            }
        }

        public void UpdateFristSelect()
        {
            if (_playerInput.currentControlScheme == $"{Type.Gamepad}")
            {
                CurrentType = Type.Gamepad;
                OnGamepadConnected?.Invoke();
            }
            else 
            {
                CurrentType = Type.MouseKeyboard;
                SetSelectedGameObject(null);
            }
        }

        public void _OnCancel()
        {
            OnCancel?.Invoke();
        }
    }
}
