using System;
using System.Collections.Generic;
using UnityEngine;

namespace StarterProject.AudioManagerLib
{
    [Serializable]
    public class AudioNode
    {
        public AudioNodeType Type;
        public AudioSource AudioSource;

        private List<AudioSource> AudioSources;
        internal AudioSource currentNode;
        internal AudioSource lastNode;

        public AudioSource GetAudioSource(Transform parent, Vector3 position = default)
        {
            if (AudioSources == null)
            {
                AudioSources = new List<AudioSource>();
            }
            var audioSource = AudioSources.Find(x => !x.isPlaying);
            if (audioSource == null)
            {
                int index = AudioSources.Count;
                audioSource = GameObject.Instantiate(AudioSource, parent);
                audioSource.name = $"{Type} {index + 1}";
                AudioSources.Add(audioSource);
            }
            audioSource.transform.position = position;
            lastNode = currentNode;
            currentNode = audioSource;
            return audioSource;
        }
    }
}
