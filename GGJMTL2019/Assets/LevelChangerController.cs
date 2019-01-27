using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerController : MonoBehaviour
{
    public Animator animator;

    private string levelToUnload;
    private string levelToLoad;
    private bool levelChangeInProgess;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.sceneTransisionEvent != null && !levelChangeInProgess)
        {
            levelChangeInProgess = true;
            levelToUnload = GameManager.Instance.sceneTransisionEvent.originSceneName;
            levelToUnload = levelToUnload.Replace("Dark", "");
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
        StartCoroutine(dirtyFix());
    }

    public IEnumerator dirtyFix() {

        SceneManager.UnloadSceneAsync(levelToUnload);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(levelToLoad, LoadSceneMode.Additive);

        FadeIntoLevel();
        levelChangeInProgess = false;
        yield return null;

    }

}
