using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterProject.AudioManager
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager _instance;

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
