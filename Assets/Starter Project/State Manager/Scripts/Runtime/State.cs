using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace StarterProject.StateLib
{
    [ExecuteInEditMode]
    public class State : MonoBehaviour
    {
        [Space]
        [DisplayAsString]
        public string Name;
        [Space]
        public GameObject FirstSelect;
        [Space]
        public UnityEvent OnEnter;
        [Space]
        public UnityEvent OnExit;

        public virtual void Enter()
        {
            Debug.Log($"Enter {Name}");
            OnEnter.Invoke();
        }

        public virtual void Exit()
        {
            Debug.Log($"Exit {Name}");
            OnExit.Invoke();
        }

        private void Update()
        {
#if UNITY_EDITOR
            _UpdateName();
#endif
        }

        private void _UpdateName()
        {
            if (Name != gameObject.name)
            {
                Name = gameObject.name;
            }
        }
    }
}
