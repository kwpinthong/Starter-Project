using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterProject.AudioManager
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager _instance;
        [SerializeField] private AudioNode _2DAudioNode;
        [SerializeField] private AudioNode _3DAudioNode;
        [SerializeField] private AudioNode _BGMAudioNode;
        [SerializeField] private bool _dontDestroyOnLoad = true;

        private void Awake()
        {
            if (_instance)
            {
                Destroy(this);
                return;
            }

            _instance = this;

            if (_dontDestroyOnLoad)
            {
                DontDestroyOnLoad(this);
            }
        }
    }
}
