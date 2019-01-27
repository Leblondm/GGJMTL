using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager
{

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (GameManager.instance == null)
            {
                GameManager.instance = new GameManager();
            }
            return GameManager.instance;
        }
    }
    public class SceneTransisionEvent
    {
        public string originSceneName;
        public string targetSceneName;
        public SceneTransisionEvent(string _originSceneName, string _targetSceneName)
        {
            originSceneName = _originSceneName;
            targetSceneName = _targetSceneName;
        }
    }
    public bool isNormalWorld = true;
    public float otherWorldTimeout = 10f;
    public float remainingTimeInOtherWorld;
    public Scene currentSceneNormalWorld;
    public Scene currentSceneOtherWorld;
    public string otherWorldSceneNameInitiator;
    public Inventory inventory = new Inventory();
    public SceneTransisionEvent sceneTransisionEvent = null;
    public bool isBedroomLocked = true;
    public bool inFrontOfBedroomDoor;

    public string bedroomTextMessage = "Find a way out of your room!";
}
