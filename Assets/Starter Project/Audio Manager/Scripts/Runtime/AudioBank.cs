using System.Collections.Generic;
using UnityEngine;

namespace StarterProject.AudioManagerLib
{
    [CreateAssetMenu(fileName = "Audio Bank", menuName = "Starter Project/Audio Manager/Audio Bank")]
    public class AudioBank : ScriptableObject
    {
        public float CrossFadeTime = 2f;
        public AnimationCurve BGMFadeOutCurve;
        public AnimationCurve BGMFadeInCurve;
        [Space]
        public List<AudioBankData> Bank;
    }
}
