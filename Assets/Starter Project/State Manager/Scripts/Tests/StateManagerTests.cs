using NUnit.Framework;
using StarterProject.StateManager;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.UI;

public class StateManagerTests
{
    private GameObject _stateManagerGameObject;
    private StateManager _stateManager;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        var prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Starter Project/State Manager/Scripts/Tests/State Manager Test.prefab");
        yield return new WaitForSeconds(0.1f);
        _stateManagerGameObject = GameObject.Instantiate(prefab);
        yield return new WaitForSeconds(0.1f);
        _stateManager = _stateManagerGameObject.GetComponent<StateManager>();
        Assert.IsNotNull(_stateManager);
    }

    [UnityTest]
    public IEnumerator ToStateA()
    {
        Assert.AreEqual("State A", _stateManager.CurrentState.Name);

        yield return new WaitForSeconds(0.1f);

        var buttonA = GameObject.Find("Button A");
        Assert.IsNotNull(buttonA);
        Assert.IsFalse(buttonA.GetComponent<Button>().interactable);
    }

    [UnityTest]
    public IEnumerator ToStateB()
    {
        var stateB = GameObject.Find("State B");
        _stateManager.NextState(stateB.GetComponent<State>());  

        yield return new WaitForSeconds(0.1f);

        var buttonA = GameObject.Find("Button B");
        Assert.IsNotNull(buttonA);
        Assert.IsFalse(buttonA.GetComponent<Button>().interactable);
    }

    [UnityTest]
    public IEnumerator ToStateC()
    {
        var stateB = GameObject.Find("State C");
        _stateManager.NextState(stateB.GetComponent<State>());

        yield return new WaitForSeconds(0.1f);

        var buttonA = GameObject.Find("Button C");
        Assert.IsNotNull(buttonA);
        Assert.IsFalse(buttonA.GetComponent<Button>().interactable);
    }
}
