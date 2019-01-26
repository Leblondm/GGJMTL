using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
