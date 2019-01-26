using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WorldSwitcher : MonoBehaviour
{

    public GameManager gameManager;
    private GameObject otherWorldMask;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire3"))
        {
           StartCoroutine(goToOtherWorld());
        }
    }


    private void updateOtherWorldVisibility() {
        foreach (GameObject gameObject in gameManager.currentSceneOtherWorld.GetRootGameObjects())
        {
            gameObject.SetActive(!gameManager.isNormalWorld);
        }
    }

    public IEnumerator goToOtherWorld() {
        if(gameManager.isNormalWorld)
        {
            gameManager.isNormalWorld = false;
            updateOtherWorldVisibility();
            yield return new WaitForSeconds(gameManager.otherWorldTimeout);
            gameManager.isNormalWorld = true;
            updateOtherWorldVisibility();
        }
        yield return null;
        
    }

}
