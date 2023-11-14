using UnityEngine;

namespace IdleRestaurant
{
    public class Cooks : MonoBehaviour
    {
        public static Cook GetAvailableCook()
        {
            if (_instance.cooks == null)
            {
                _instance._UpdateCooks();
            }
            foreach (var cook in _instance.cooks)
            {
                if (!cook.IsWorking)
                {
                    return cook;
                }
            }
            return null;
        }

        private static Cooks _instance;

        [SerializeField] private Cook[] cooks;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
                _UpdateCooks();
            }
        }

        private void _UpdateCooks()
        {
            cooks = GetComponentsInChildren<Cook>();
        }
    }
}
