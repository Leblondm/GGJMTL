using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAwayLockedDoorState : MonoBehaviour
{

    private GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        gameManager.inFrontOfRunAwayDoor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameManager.inFrontOfRunAwayDoor = false;
    }
}
