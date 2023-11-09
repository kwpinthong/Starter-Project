using StarterProject.ControllerLib;
using UnityEngine;

namespace StarterProject.StateLib
{
    public class StateManager : MonoBehaviour
    {
        public State CurrentState => _currentState;

        [SerializeField] private State _firstState;

        private State _currentState;

        private void Start()
        {
            Controller.OnGamepadConnected += Controller_OnGamepadConnected;
            NextState(_firstState);
        }

        private void OnDestroy()
        {
            Controller.OnGamepadConnected -= Controller_OnGamepadConnected;
        }

        public void NextState(State nextState)
        {
            if (_currentState != null)
            {
                _currentState.Exit();
            }
            _currentState = nextState;
            _currentState.Enter();
            SetFirstSelect();
        }

        public void SetFirstSelect()
        {
            if (Controller.CurrentType == Controller.Type.Gamepad)
            {
                Controller.SetSelectedGameObject(_currentState.FirstSelect);
            }
        }

        private void Controller_OnGamepadConnected()
        {
            Controller.SetSelectedGameObject(_currentState.FirstSelect);
        }
    }
}
