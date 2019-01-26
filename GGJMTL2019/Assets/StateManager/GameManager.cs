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
              //  DontDestroyOnLoad(GameManager.instance);
            }
            return GameManager.instance;
        }
    }
    public bool isNormalWorld = true;
    public float otherWorldTimeout = 3f;
    public float remainingTimeInOtherWorld;
    public Scene currentSceneNormalWorld;
    public Scene currentSceneOtherWorld;
    public Inventory inventory = new Inventory();
}
