using Sirenix.OdinInspector;
using StarterProject.AudioManagerLib;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace StarterProject.UIFramework
{
    [RequireComponent(typeof(Selectable))]
    public class PlaySoundOnSubmit : MonoBehaviour, ISubmitHandler
    {
        [ValueDropdown(nameof(GetAllSFXKeys))]
        public string AudioKey;

        private static IEnumerable GetAllSFXKeys()
        {
            List<string> _keys = new List<string>();

            var audioBack = (AudioBank)AssetDatabase.LoadAssetAtPath("Assets/Starter Project/Resources/Audio Manager/Audio Bank.asset", typeof(AudioBank));
            var sfx = audioBack.Bank.Find(x => x.Type == AudioNodeType.TwoD);
            foreach (var s in sfx.AudioClipDatas)
            {
                _keys.Add(s.Key);
            }

            return _keys;
        }

        public void OnSubmit(BaseEventData eventData)
        {
            PlaySound();
        }

        public void PlaySound()
        {
            AudioManager.PlaySFX(AudioKey);
        }
    }
}
