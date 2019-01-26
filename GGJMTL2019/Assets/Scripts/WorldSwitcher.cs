using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitcher : MonoBehaviour
{

    public GameManager gameManager;
    public GameObject otherWorldMask;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("World switch"))
        {
            StartCoroutine(goToOtherWorld());
        }
    }

    
    public IEnumerator goToOtherWorld() {
        if(GameManager.Instance.isNormalWorld)
        {
            Debug.Log("normal world: " + GameManager.Instance.isNormalWorld);
            gameManager.isNormalWorld = false;
            GameObject otherWorldInst = Instantiate(otherWorldMask);
            yield return new WaitForSeconds(gameManager.otherWorldTimeout);
            Destroy(otherWorldInst);
            gameManager.isNormalWorld = true;
        }
        yield return null;
    }
}
