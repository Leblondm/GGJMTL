using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToBed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReturnToBedNow());
    }

    private IEnumerator ReturnToBedNow()
    {
        GameManager.Instance.isNormalWorld = true;
        GameManager.Instance.remainingTimeInOtherWorld = 0;
        yield return new WaitForSeconds(5);

        Scene currentScene = gameObject.scene;

        GameManager.Instance.sceneTransisionEvent = new GameManager.SceneTransisionEvent(gameObject.scene.name, "BedScene");
    }
}
