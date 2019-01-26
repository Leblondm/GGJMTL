using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    
    void Start()
    {
        gameManager = GameManager.Instance;
        gameManager.currentSceneNormalWorld = gameObject.scene;
        string darkWorldSceneName = gameManager.currentSceneNormalWorld.name + "Dark";
        SceneManager.LoadScene(darkWorldSceneName, LoadSceneMode.Additive);
        GameManager.Instance.currentSceneOtherWorld = SceneManager.GetSceneByName(darkWorldSceneName);
    }


    private void OnDestroy()
    {
        SceneManager.UnloadSceneAsync(GameManager.Instance.currentSceneOtherWorld);
       // SceneManager.LoadScene("MainScene", LoadSceneMode.Additive);
    }
}
