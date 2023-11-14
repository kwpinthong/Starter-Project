using UnityEngine;

namespace IdleRestaurant
{
    public class Chairs : MonoBehaviour
    {
        public static Chair GetEmptyChair()
        {
            if (_instance.chairs == null)
            {
                return null;
            }
            foreach (var chair in _instance.chairs)
            {
                if (chair.IsEmpty)
                {
                    return chair;
                }
            }
            return null;
        }

        private static Chairs _instance;

        [SerializeField] private Chair[] chairs;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
        }

#if UNITY_EDITOR
        [Sirenix.OdinInspector.Button]
        private void _UpdateChairs()
        {
            chairs = GetComponentsInChildren<Chair>();
        }
#endif
    }
}
