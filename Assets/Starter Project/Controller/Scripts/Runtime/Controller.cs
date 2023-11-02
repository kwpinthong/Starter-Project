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

        public void UpdateFristSelect(PlayerInput playerInput)
        {
            if (playerInput.currentControlScheme == $"{Type.Gamepad}")
            {
            }
            else 
            {
            }
        }

        public static void SetSelectedGameObject(GameObject gameObject)
        {
            if (EventSystem.current)
            {
                EventSystem.current.SetSelectedGameObject(gameObject);
            }
        }
    }
}
