using NUnit.Framework;
using StarterProject.AudioManager;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class AudioManagerTests
{
    private GameObject _audioManagerGameObject;
    private AudioManager _audioManager;

    [UnityTest]
    public IEnumerator HaveOneInstance()
    {
        _audioManagerGameObject = GameObject.Instantiate(new GameObject());
        _audioManager = _audioManagerGameObject.AddComponent<AudioManager>();

        yield return new WaitForSeconds(0.1f);

        GameObject _nextAudioManagerGameObject = GameObject.Instantiate(new GameObject());
        _nextAudioManagerGameObject.AddComponent<AudioManager>();

        yield return new WaitForSeconds(0.1f);

        Assert.IsNotNull(_audioManager.GetComponent<AudioManager>());
    }
}
