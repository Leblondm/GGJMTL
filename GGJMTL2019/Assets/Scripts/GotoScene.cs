using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GotoScene : MonoBehaviour
{

    public string targetScene;

    // Start is called before the first frame update
    void Start()
    {
    }

    private bool isSceneSwitching = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isSceneSwitching && GameManager.Instance.sceneTransisionEvent == null)
        {
            Debug.Log("YOLO " + gameObject.scene.name);
            isSceneSwitching = true;
            GameManager.Instance.sceneTransisionEvent = new GameManager.SceneTransisionEvent(gameObject.scene.name, targetScene);
        }
        
    }
}
