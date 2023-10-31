using UnityEngine;
using UnityEngine.EventSystems;

namespace StarterProject.StateManager
{
    public class StateManager : MonoBehaviour
    {
        public State CurrentState => _currentState;

        [SerializeField] private State _firstState;

        private State _currentState;

        private void Start()
        {
            NextState(_firstState);
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
            if (EventSystem.current)
            {
                EventSystem.current.SetSelectedGameObject(_currentState.FirstSelect);
            }
        }
    }
}
