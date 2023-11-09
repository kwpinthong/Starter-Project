using System;
using UnityEngine;

namespace StarterProject.AudioManagerLib
{
    [Serializable]
    public class AudioClipData
    {
        public string Key;
        public AudioClip AudioClip;
        [Range(0f, 1f)]
        public float Volume = 1f;
    }
}
