using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomLockedDoorState : MonoBehaviour
{

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        gameManager.inFrontOfBedroomDoor = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameManager.inFrontOfBedroomDoor = false;
    }
}
