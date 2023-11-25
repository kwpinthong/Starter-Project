using UnityEngine;
using UnityEngine.Events;

namespace StarterProject.CommonLib
{
    public class AnimationEvent : MonoBehaviour
    {
        public UnityEvent OnReachEvent;

        public void InvokeReachEvent()
        {
            OnReachEvent?.Invoke();
        }
    }
}
