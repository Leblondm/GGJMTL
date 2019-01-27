﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedRoomUnlocker : MonoBehaviour
{


    private GameObject lockedDoor;
    private GameObject openDoor;

    // Start is called before the first frame update
    void Start()
    {
        Component[] scenesGameObject = GameObject.Find("BedRoomDoor").GetComponentsInChildren<Component>(true);
        foreach (Component currentComponent in scenesGameObject) {
            if (currentComponent.name == "OpenDoor") {
                openDoor = currentComponent.gameObject;
            } else if (currentComponent.name == "LockedDoor") {
                lockedDoor = currentComponent.gameObject;
            }
        }
        updateDoorState();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("User action") && !GameManager.Instance.isNormalWorld && GameManager.Instance.inFrontOfBedroomDoor && GameManager.Instance.inventory.hasItem(Inventory.ItemTypes.BedRoomKey) )
        {
            GameManager.Instance.isBedroomLocked = false;
            StartCoroutine(congratulations());
        }
    }


    private void updateDoorState() {
        openDoor.SetActive(!GameManager.Instance.isBedroomLocked);
        lockedDoor.SetActive(GameManager.Instance.isBedroomLocked);
    }

    private IEnumerator congratulations() {
        GameManager.Instance.bedroomTextMessage = "Yeay! Go and explore now :)";
        yield return new WaitForSeconds(2);
        updateDoorState();
        GameManager.Instance.bedroomTextMessage = "";
        yield return null;
    }
}
