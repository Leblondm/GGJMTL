using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDController : MonoBehaviour
{
    GameObject darkWorldTimerIndicator;

    public float originalPosition;
    public float ratio;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameManager.Instance.otherWorldTimeout / ratio);
        darkWorldTimerIndicator = GameObject.Find("DarkWorldTimerIndicator");
        Debug.Log(darkWorldTimerIndicator.transform.position.x);
        originalPosition = darkWorldTimerIndicator.transform.position.x + (GameManager.Instance.otherWorldTimeout / ratio);
        darkWorldTimerIndicator.transform.position = new Vector3(originalPosition, darkWorldTimerIndicator.transform.position.y);
    }

    void FixedUpdate()
    {
        darkWorldTimerIndicator.transform.position = new Vector3(originalPosition + (GameManager.Instance.remainingTimeInOtherWorld / ratio), darkWorldTimerIndicator.transform.position.y);
        foreach (SpriteRenderer spriteRenderer in GameObject.FindGameObjectWithTag("DarkWorldTimer").GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderer.enabled = !GameManager.Instance.isNormalWorld;
        }
    }
}
