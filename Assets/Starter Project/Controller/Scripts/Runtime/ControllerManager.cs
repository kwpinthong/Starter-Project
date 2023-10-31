using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterProject.Controller
{
    public class ControllerManager : MonoBehaviour
    {
        private static ControllerManager _instance;

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
    }
}
