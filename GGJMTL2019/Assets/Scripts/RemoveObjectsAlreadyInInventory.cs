using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using UnityEngine.SceneManagement;
public class RemoveObjectsAlreadyInInventory : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    private Scene sceneOfScript;
    void FixedUpdate()
    {
        sceneOfScript = gameObject.scene;
        gameManager = GameManager.Instance;
        
        foreach (Inventory.ItemTypes enumItem in Enum.GetValues(typeof(Inventory.ItemTypes))) {
            string tagForEnum = enumItem.ToString();
            foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag(tagForEnum)) {
                if (gameObject.scene == sceneOfScript) {
                    gameObject.SetActive(!gameManager.inventory.hasItem(enumItem));
                }
            }
        }
        
    }

}
