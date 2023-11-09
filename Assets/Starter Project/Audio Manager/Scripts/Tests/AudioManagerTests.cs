using NUnit.Framework;
using StarterProject.AudioManagerLib;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

public class AudioManagerTests
{
    private const string pathTest = "Assets/Starter Project/Audio Manager/Scripts/Tests/_assets";
    private const string prefabName = "_audio_manager.prefab";
    private const string prefabPath = pathTest + "/" + prefabName;

    private GameObject _audioManagerGameObject;
    private AudioManager _audioManager;

    [UnityTest]
    public IEnumerator HaveOneInstance()
    {
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
        yield return new WaitForSeconds(0.1f);
        _audioManagerGameObject = GameObject.Instantiate(prefab);
        yield return new WaitForSeconds(0.1f);
        _audioManager = _audioManagerGameObject.GetComponent<AudioManager>();
        Assert.IsNotNull(_audioManager);

        yield return new WaitForSeconds(0.1f);

        GameObject _nextAudioManagerGameObject = GameObject.Instantiate(new GameObject());
        _nextAudioManagerGameObject.AddComponent<AudioManager>();

        yield return new WaitForSeconds(0.1f);

        Assert.IsNotNull(_audioManager.GetComponent<AudioManager>());
    }


    [UnityTest]
    public IEnumerator MissingKey()
    {
        if (_audioManager == null)
        {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            yield return new WaitForSeconds(0.1f);
            _audioManagerGameObject = GameObject.Instantiate(prefab);
            yield return new WaitForSeconds(0.1f);
            _audioManager = _audioManagerGameObject.GetComponent<AudioManager>();
            Assert.IsNotNull(_audioManager);
        }

        yield return new WaitForSeconds(0.1f);

        AudioManager.PlaySFX("Select 1");

        yield return new WaitForSeconds(1f);

        var audioGameObject = _audioManagerGameObject.transform.Find("TwoD 1");
        Assert.IsNull(audioGameObject);
    }

    [UnityTest]
    public IEnumerator PlayBGM()
    {
        if (_audioManager == null)
        {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            yield return new WaitForSeconds(0.1f);
            _audioManagerGameObject = GameObject.Instantiate(prefab);
            yield return new WaitForSeconds(0.1f);
            _audioManager = _audioManagerGameObject.GetComponent<AudioManager>();
            Assert.IsNotNull(_audioManager);
        }

        yield return new WaitForSeconds(0.1f);

        AudioManager.PlayBGM("BGM1");

        yield return new WaitForSeconds(0.1f);

        AudioSource audioSourceBGM1 = _audioManagerGameObject.transform.Find("BGM 1").GetComponent<AudioSource>();

        yield return new WaitForSeconds(3f);

        AudioManager.PlayBGM("BGM2");

        yield return new WaitForSeconds(0.1f);

        AudioSource audioSourceBGM2 = _audioManagerGameObject.transform.Find("BGM 2").GetComponent<AudioSource>();

        yield return new WaitForSeconds(3f);

        Assert.AreEqual(false, audioSourceBGM1.isPlaying);
        Assert.AreEqual(true, audioSourceBGM2.isPlaying);
    }

    [UnityTest]
    public IEnumerator PlaySFX2D()
    {
        if (_audioManager == null)
        {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            yield return new WaitForSeconds(0.1f);
            _audioManagerGameObject = GameObject.Instantiate(prefab);
            yield return new WaitForSeconds(0.1f);
            _audioManager = _audioManagerGameObject.GetComponent<AudioManager>();
            Assert.IsNotNull(_audioManager);
        }

        yield return new WaitForSeconds(0.1f);

        AudioManager.PlaySFX("Select");

        yield return new WaitForSeconds(1f);

        AudioSource audioSource = _audioManagerGameObject.transform.Find("TwoD 1").GetComponent<AudioSource>();

        float WaitTime = 3f;

        AudioManager.PlaySFX("Select");

        while (true)
        {
            if (audioSource.isPlaying)
            {
                Assert.Pass();
                break;
            }

            WaitTime -= Time.deltaTime;

            if (WaitTime < 0)
            {
                Assert.Fail();
                break;
            }

            yield return null;
        }
    }

    [UnityTest]
    public IEnumerator PlaySFX3D()
    {
        if (_audioManager == null)
        {
            var prefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);
            yield return new WaitForSeconds(0.1f);
            _audioManagerGameObject = GameObject.Instantiate(prefab);
            yield return new WaitForSeconds(0.1f);
            _audioManager = _audioManagerGameObject.GetComponent<AudioManager>();
            Assert.IsNotNull(_audioManager);
        }

        yield return new WaitForSeconds(0.1f);

        AudioManager.PlaySFX("Select", new Vector3(10, 10));

        yield return new WaitForSeconds(1f);

        AudioSource audioSource = _audioManagerGameObject.transform.Find("ThreeD 1").GetComponent<AudioSource>();

        yield return new WaitForSeconds(1f);

        Assert.AreEqual(10f, audioSource.transform.position.x);
        Assert.AreEqual(10f, audioSource.transform.position.y);

        float WaitTime = 3f;

        AudioManager.PlaySFX("Select", new Vector3(10, 10));

        while (true)
        {
            if (audioSource.isPlaying)
            {
                Assert.Pass();
                break;
            }

            WaitTime -= Time.deltaTime;

            if (WaitTime < 0)
            {
                Assert.Fail();
                break;
            }

            yield return null;
        }
    }
}
