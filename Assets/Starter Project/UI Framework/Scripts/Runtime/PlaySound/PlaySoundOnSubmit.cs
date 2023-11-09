using Sirenix.OdinInspector;
using StarterProject.AudioManagerLib;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace StarterProject.UIFramework
{
    [RequireComponent(typeof(Selectable))]
    public class PlaySoundOnSubmit : MonoBehaviour, ISubmitHandler
    {
        [ValueDropdown(nameof(_getAllKeys))]
        public string AudioKey;

        public void OnSubmit(BaseEventData eventData)
        {
            PlaySound();
        }

        public void PlaySound()
        {
            AudioManager.PlaySFX(AudioKey);
        }

        private static IEnumerable _getAllKeys()
        {
            return AudioManager.GetAllKey(AudioNodeType.TwoD);
        }
    }
}
