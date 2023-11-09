using Sirenix.OdinInspector;
using StarterProject.AudioManagerLib;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace StarterProject.UIFramework
{
    [RequireComponent(typeof(Selectable))]
    public class PlaySoundOnClick : MonoBehaviour, IPointerClickHandler
    {
        [ValueDropdown(nameof(_getAllKeys))]
        public string AudioKey;

        public void OnPointerClick(PointerEventData eventData)
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
