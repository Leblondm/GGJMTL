using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    GameObject darkWorldTimerBar;
    GameObject darkWorldTimerIndicator;

    public float offset;


    // Start is called before the first frame update
    void Start()
    {
        darkWorldTimerBar = GameObject.Find("DarkWorldTimerBar");
        darkWorldTimerIndicator = GameObject.Find("DarkWorldTimerIndicator");
        Debug.Log(darkWorldTimerIndicator.transform.position.x);
        originalPosition = darkWorldTimerIndicator.transform.position.x + (GameManager.Instance.otherWorldTimeout / ratio);
        darkWorldTimerIndicator.transform.position = new Vector3(originalPosition, darkWorldTimerIndicator.transform.position.y);
    }

    void FixedUpdate()
    {
        darkWorldTimerIndicator.transform.position = new Vector2((darkWorldTimerBar.transform.position.x + (GameManager.Instance.remainingTimeInOtherWorld / 10)) - offset, darkWorldTimerIndicator.transform.position.y);
        foreach (SpriteRenderer spriteRenderer in GameObject.FindGameObjectWithTag("DarkWorldTimer").GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderer.enabled = !GameManager.Instance.isNormalWorld;
        }
    }
}
