using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class WorldSwitcher : MonoBehaviour
{

    public GameManager gameManager;
    private GameObject otherWorldMask;
    // Start is called before the first frame update
    
    void Start()
    {
        gameManager = GameManager.Instance;
        StartCoroutine(updateOtherWorldVisibility());
        if (!gameManager.isNormalWorld)
        {
            StartCoroutine(goToOtherWorld());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("World switch"))
        {
           StartCoroutine(goToOtherWorld());
        }
    }


    private IEnumerator updateOtherWorldVisibility() {

        while(!gameManager.currentSceneOtherWorld.isLoaded)
        {
            yield return new WaitForSeconds(0.05f);
        }

        foreach (GameObject gameObject in gameManager.currentSceneOtherWorld.GetRootGameObjects())
        {
            gameObject.SetActive(!gameManager.isNormalWorld);
        }

        foreach (GameObject gameObject in gameManager.currentSceneNormalWorld.GetRootGameObjects())
        {
            if(isElementToHideOrShow(gameObject))
            {
                gameObject.SetActive(gameManager.isNormalWorld);
            }
            if (gameObject.tag == "Knight" || gameObject.tag == "RunAwayRoomKey")
            {
                gameObject.SetActive(gameManager.isNormalWorld);
            }
            
        }
        yield return null;

    }

    private bool isElementToHideOrShow(GameObject gameObject) {
        foreach (Inventory.ItemTypes item in Enum.GetValues(typeof(Inventory.ItemTypes))) {
            if (item.ToString() == gameObject.tag) {
                return true;
            }
        }
        return false;
    }


    public IEnumerator goToOtherWorld() {
        if(gameManager.isNormalWorld || gameManager.otherWorldSceneNameInitiator != gameObject.scene.name)
        {
            gameManager.isNormalWorld = false;
            gameManager.otherWorldSceneNameInitiator = gameObject.scene.name;
            StartCoroutine(updateOtherWorldVisibility());
            float remainingTime = gameManager.remainingTimeInOtherWorld > 0 ? gameManager.remainingTimeInOtherWorld: gameManager.otherWorldTimeout;
            for (float time = remainingTime; time >= 0; time--)
            {
                if (gameManager.isNormalWorld) break;
                gameManager.remainingTimeInOtherWorld = time;
                yield return new WaitForSeconds(1f);
            }
            if (gameManager.remainingTimeInOtherWorld <= 0)
            {
                gameManager.isNormalWorld = true;
                StartCoroutine(updateOtherWorldVisibility());
                GameManager.Instance.sceneTransisionEvent = new GameManager.SceneTransisionEvent(gameObject.scene.name, "GetAsleepInfo");
            }
        }
        if (!gameManager.isNormalWorld || gameManager.otherWorldSceneNameInitiator != gameObject.scene.name)
        {
            gameManager.isNormalWorld = true;
            gameManager.otherWorldSceneNameInitiator = gameObject.scene.name;
            StartCoroutine(updateOtherWorldVisibility());
        }
        yield return null;
        
    }

}
