using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpener : MonoBehaviour
{

    public GameObject closedDoor;
    public GameObject openedDoor;


    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(openedDoor.activeSelf);
        if (openedDoor.activeSelf)
        {
            Debug.Log(Input.GetButtonDown("User action"));
        }

        if (Input.GetButtonDown("User action"))
        {
            closedDoor.SetActive(false);
            openedDoor.SetActive(true);
        }

    }

    // Update is called once per frame
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(openedDoor.activeSelf);
        Debug.Log(Input.GetButtonDown("User action"));
        if (openedDoor.activeSelf)
        {
            Debug.Log(Input.GetButtonDown("User action"));
        }

        if (Input.GetButtonDown("User action"))
        {
            closedDoor.SetActive(false);
            openedDoor.SetActive(true);
        }

    }
}
