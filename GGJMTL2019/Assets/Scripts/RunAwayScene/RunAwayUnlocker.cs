using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAwayUnlocker : MonoBehaviour
{


    private GameObject lockedDoor;
    private GameObject openDoor;

    // Start is called before the first frame update
    void Start()
    {
        Component[] scenesGameObject = GameObject.Find("RunAwayDoor").GetComponentsInChildren<Component>(true);
        foreach (Component currentComponent in scenesGameObject)
        {
            if (currentComponent.name == "OpenDoor")
            {
                openDoor = currentComponent.gameObject;
            }
            else if (currentComponent.name == "LockedDoor")
            {
                lockedDoor = currentComponent.gameObject;
            }
        }
        updateDoorState();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("User action") && GameManager.Instance.isNormalWorld && GameManager.Instance.inFrontOfRunAwayDoor && GameManager.Instance.inventory.hasItem(Inventory.ItemTypes.RunAwayRoomKey))
        {
            FindObjectOfType<AudioManager>().Play("jingle_item_7");
            GameManager.Instance.isRunAwayDoorLocked = false;
            StartCoroutine(congratulations());
        }

        if (Input.GetButtonDown("User action") && GameManager.Instance.inFrontOfRunAwayDoor && (!GameManager.Instance.isNormalWorld || !GameManager.Instance.inventory.hasItem(Inventory.ItemTypes.RunAwayRoomKey)))
        {
            FindObjectOfType<AudioManager>().Play("door_locked");
        }
    }


    private void updateDoorState()
    {
        openDoor.SetActive(!GameManager.Instance.isRunAwayDoorLocked);
        lockedDoor.SetActive(GameManager.Instance.isRunAwayDoorLocked);
    }

    private IEnumerator congratulations()
    {
        updateDoorState();
        FindObjectOfType<AudioManager>().Play("door_unlock");
        openDoor.SetActive(!GameManager.Instance.isRunAwayDoorLocked);
        lockedDoor.SetActive(GameManager.Instance.isRunAwayDoorLocked);
        yield return null;
    }
}

