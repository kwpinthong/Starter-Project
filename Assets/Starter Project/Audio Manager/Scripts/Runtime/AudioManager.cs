using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace StarterProject.AudioManagerLib
{
    public class AudioManager : MonoBehaviour
    {
        private static AudioManager _instance;

        public static void PlayBGM(string bgm)
        {
            _instance._PlayBGM(bgm);
        }

        public static void PlaySFX(string sfx)
        {
            _instance._PlaySFX(sfx);
        }

        public static void PlaySFX(string sfx, Vector3 position)
        {
            _instance._PlaySFX(sfx, position);
        }

        public static void SetMasterVolume(float volume)
        {
            _instance._SetMasterVolume(volume);
        }

        public static void SetBGMVolume(float volume)
        {
            _instance._SetBGMVolume(volume);
        }

        public static void SetSFXVolume(float volume)
        {
            _instance._SetSFXVolume(volume);
        }

        public static IEnumerable GetAllKey(AudioNodeType type)
        {
            List<string> _keys = new List<string>();

            var audioBack = (AudioBank)Resources.Load("Audio Bank");

            if (audioBack == null)
            {
                Debug.LogWarning("Audio Bank not found, in Resources folder");
            }
            else
            {
                var sfx = audioBack.Bank.Find(x => x.Type == type);
                foreach (var s in sfx.AudioClipDatas)
                {
                    _keys.Add(s.Key);
                }
            }

            return _keys;
        }

        [SerializeField] private List<AudioNode> _nodes;
        [SerializeField] private AudioBank _audioBank;
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private string _MasterVolumeParam = "MasterVolume";
        [SerializeField] private string _BGMVolumeParam = "BGMVolume";
        [SerializeField] private string _SFXVolumeParam = "SFXVolume";

        AudioNode BGM => _nodes.Find(x => x.Type == AudioNodeType.BGM);
        AudioNode TwoD => _nodes.Find(x => x.Type == AudioNodeType.TwoD);
        AudioNode ThreeD => _nodes.Find(x => x.Type == AudioNodeType.ThreeD);
        AudioBankData BGMBank => _audioBank.Bank.Find(x => x.Type == AudioNodeType.BGM);
        AudioBankData TwoDBank => _audioBank.Bank.Find(x => x.Type == AudioNodeType.TwoD);
        AudioBankData ThreeDBank => _audioBank.Bank.Find(x => x.Type == AudioNodeType.ThreeD);

        private void Awake()
        {
            if (_instance)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;

            DontDestroyOnLoad(gameObject);
        }

        private void _PlayBGM(string bgm)
        {
            bool found = false;

            foreach (var audioClipData in BGMBank.AudioClipDatas)
            {
                if (audioClipData.Key == bgm)
                {
                    found = true;
                    _PlayBGM(audioClipData);
                    break;
                }
            }

            if (found == false)
            {
                Debug.LogWarning($"BGM {bgm} not found");
            }
        }

        private void _PlaySFX(string sfx)
        {
            bool found = false;

            foreach (var audioClipData in TwoDBank.AudioClipDatas)
            {
                if (audioClipData.Key == sfx)
                {
                    found = true;
                    _PlayTwoD(audioClipData);
                    break;
                }
            }

            if (found == false)
            {
                Debug.LogWarning($"SFX {sfx} not found");
            }
        }

        private void _PlaySFX(string sfx, Vector3 position)
        {
            bool found = false;

            foreach (var audioClipData in ThreeDBank.AudioClipDatas)
            {
                if (audioClipData.Key == sfx)
                {
                    found = true;
                    _PlayThreeD(audioClipData, position);
                    break;
                }
            }

            if (found == false)
            {
                Debug.LogWarning($"SFX {sfx} not found");
            }
        }

        private Coroutine _crosseFadeBGM;

        private void _PlayBGM(AudioClipData audioClipData)
        {
            if (_crosseFadeBGM != null)
            {
                return;
            }

            var currentBGM = BGM.currentNode;
            if (currentBGM != null && currentBGM.clip == audioClipData.AudioClip)
            {
                return;
            }

            var audioSource = BGM.GetAudioSource(transform);
            _crosseFadeBGM = StartCoroutine(crosseFade(audioClipData, BGM.lastNode, audioSource, true));

            IEnumerator crosseFade(AudioClipData audioClipData, AudioSource currentBGM, AudioSource nextBGM, bool loop)
            {
                nextBGM.volume = 0;
                nextBGM.clip = audioClipData.AudioClip;
                nextBGM.loop = loop;
                nextBGM.Play();

                float currentBGMStart = currentBGM == null ? 0f : currentBGM.volume;
                float nextBGMVolume = audioClipData.Volume;
                float crossFadeTime = _audioBank.CrossFadeTime;
                float time = 0;

                while (true)
                {
                    time += Time.deltaTime;

                    if (currentBGM != null)
                    {
                        currentBGM.volume = Mathf.Lerp(currentBGMStart, 0f, _audioBank.BGMFadeOutCurve.Evaluate(time / crossFadeTime));
                    }

                    if (nextBGM != null)
                    {
                        nextBGM.volume = Mathf.Lerp(0f, nextBGMVolume, _audioBank.BGMFadeInCurve.Evaluate(time / crossFadeTime));
                    }

                    if (nextBGM.volume >= nextBGMVolume)
                    {
                        if (currentBGM != null && currentBGM.volume <= 0f)
                        {
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }

                    yield return null;
                }

                if (currentBGM != null)
                {
                    currentBGM.Stop();
                }

                _crosseFadeBGM = null;
            }
        }

        private void _PlayTwoD(AudioClipData audioClipData)
        {
            var audioSource = TwoD.GetAudioSource(transform);
            _PlayAudioSource(audioSource, audioClipData);
        }

        private void _PlayThreeD(AudioClipData audioClipData, Vector3 position)
        {
            var audioSource = ThreeD.GetAudioSource(transform, position);
            _PlayAudioSource(audioSource, audioClipData);
        }

        private void _PlayAudioSource(AudioSource audioSource, AudioClipData audioClipData)
        {
            audioSource.clip = audioClipData.AudioClip;
            audioSource.volume = audioSource.volume;
            audioSource.Play();
        }

        private void _SetMasterVolume(float volume)
        {
            _audioMixer.SetFloat(_MasterVolumeParam, _GetVolume(volume));
        }

        private void _SetBGMVolume(float volume)
        {
            _audioMixer.SetFloat(_BGMVolumeParam, _GetVolume(volume));
        }

        private void _SetSFXVolume(float volume)
        {
            _audioMixer.SetFloat(_SFXVolumeParam, _GetVolume(volume));
        }

        private float _GetVolume(float volume) // require volume Range (0f,1f)
        {
            return Mathf.Log(volume) * 20;
        }
    }
}
