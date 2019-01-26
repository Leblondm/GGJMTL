using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Debug.Log(GameManager.Instance.isNormalWorld);
        GameObject.FindGameObjectWithTag("DarkWorldTimerBar").GetComponent<SpriteRenderer>().enabled = !GameManager.Instance.isNormalWorld;
    }
}
