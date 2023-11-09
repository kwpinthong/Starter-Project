using Sirenix.OdinInspector;
using StarterProject.AudioManagerLib;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace StarterProject.UIFramework
{
    [RequireComponent(typeof(Selectable))]
    public class PlayerSoundOnEvent : MonoBehaviour
    {
        [ValueDropdown(nameof(_getAllKeys))]
        public string AudioKey;

        protected Selectable _selectable;

        public void PlaySound()
        {
            if (_selectable == null)
            {
                _selectable = GetComponent<Selectable>();
            }
            if (_selectable != null && (_selectable.gameObject.activeSelf && _selectable.interactable))
            {
                AudioManager.PlaySFX(AudioKey);
            }
        }

        protected static IEnumerable _getAllKeys()
        {
            return AudioManager.GetAllKey(AudioNodeType.TwoD);
        }
    }
}
