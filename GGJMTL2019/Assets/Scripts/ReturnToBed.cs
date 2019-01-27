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
        yield return new WaitForSeconds(5);

        Scene currentScene = gameObject.scene;
        SceneManager.UnloadSceneAsync(GameManager.Instance.currentSceneNormalWorld);
        SceneManager.UnloadSceneAsync(currentScene);
        SceneManager.LoadScene("BedScene", LoadSceneMode.Additive);

    }
}
