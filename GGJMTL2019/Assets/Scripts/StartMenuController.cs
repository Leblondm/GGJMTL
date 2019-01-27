using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class StartMenuController : MonoBehaviour
{
    private int index = 0;
    private enum START_MENU {
          PLAY = 0,
          CREDITS = 1,
          QUIT = 2
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        if(!gameObject.scene.isLoaded)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            index++;
            index = index > Enum.GetNames(typeof(START_MENU)).Length - 1? 0: index;
        } else if (Input.GetKeyDown(KeyCode.UpArrow)) {
            index--;
            index = index < 0 ? Enum.GetNames(typeof(START_MENU)).Length - 1 : index;
        }

        foreach(START_MENU element in Enum.GetValues(typeof(START_MENU)))
        {
            GameObject.Find(element.ToString()).GetComponent<Renderer>().enabled = false;
        }

        START_MENU currentElement = (START_MENU)index;
        GameObject.Find(currentElement.ToString()).GetComponent<Renderer>().enabled = true;

        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (currentElement)
            {
                case START_MENU.PLAY:
                    GotoGameStart();
                    break;
                case START_MENU.CREDITS:
                    GotoCredits();
                    break;
                case START_MENU.QUIT:
                    Application.Quit();
                    break;
                default:
                    break;

            }
        }

    }

    private void GotoGameStart() {
        GameManager.Instance.sceneTransisionEvent = new GameManager.SceneTransisionEvent(gameObject.scene.name, "BedScene");
    }

    private void GotoCredits()
    {
        GameManager.Instance.sceneTransisionEvent = new GameManager.SceneTransisionEvent(gameObject.scene.name, "CreditsScene");
    }

}
