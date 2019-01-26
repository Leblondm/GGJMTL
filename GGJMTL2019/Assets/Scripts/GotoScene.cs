using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoScene : MonoBehaviour
{

    public string targetScene;
    private Scene currentScene;
    // Start is called before the first frame update
    void Start()
    {
        currentScene = gameObject.scene;
    }

    private bool isSceneSwitching = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!isSceneSwitching)
        {
            isSceneSwitching = true;
            SceneManager.UnloadSceneAsync(currentScene);
            SceneManager.LoadScene(targetScene, LoadSceneMode.Additive);
        }
        
    }
}
