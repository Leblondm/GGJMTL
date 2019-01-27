using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerController : MonoBehaviour
{
    public Animator animator;

    private string levelToUnload;
    private string levelToLoad;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.sceneTransisionEvent != null)
        {
            levelToUnload = GameManager.Instance.sceneTransisionEvent.originSceneName;
            levelToLoad = GameManager.Instance.sceneTransisionEvent.targetSceneName;
            GameManager.Instance.sceneTransisionEvent = null;
            FadeToLevel();
        }
    }

    public void FadeToLevel()
    {
        animator.SetTrigger("FadeOut");
    }

    public void FadeIntoLevel()
    {
        animator.SetTrigger("FadeIn");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad, LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(levelToUnload);
        FadeIntoLevel();
    }
}
