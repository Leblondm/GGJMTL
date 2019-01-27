using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class StartMenuController : MonoBehaviour
{
    private int index = 0;
    private bool goingUp;
    private bool goingDown;
    private float previousVerticalAxisValue;
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
        goingUp = false;
        goingDown = false;
        if (Input.GetAxis("Vertical") == 0 && previousVerticalAxisValue != 0)
        {
            if (previousVerticalAxisValue > 0f)
            {
                goingUp = true;
            }
            else if (previousVerticalAxisValue < 0)
            {
                goingDown = true;
            }
        }
        previousVerticalAxisValue = Input.GetAxis("Vertical");

         if (!gameObject.scene.isLoaded)
            {
                return;
            }
            if (goingDown)
            {
                index++;
                index = index > Enum.GetNames(typeof(START_MENU)).Length - 1 ? 0 : index;
            }
            else if (goingUp)
            {
                index--;
                index = index < 0 ? Enum.GetNames(typeof(START_MENU)).Length - 1 : index;
            }

            foreach (START_MENU element in Enum.GetValues(typeof(START_MENU)))
            {
                GameObject.Find(element.ToString()).GetComponent<Renderer>().enabled = false;
            }

            START_MENU currentElement = (START_MENU)index;
            GameObject.Find(currentElement.ToString()).GetComponent<Renderer>().enabled = true;

            if (Input.GetButtonDown("Submit"))
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
            goingUp = false;
            goingDown = false;
    }

    private void GotoGameStart() {
        GameManager.Instance.sceneTransisionEvent = new GameManager.SceneTransisionEvent(gameObject.scene.name, "BedScene");
        SceneManager.UnloadSceneAsync("MusicScene");
    }

    private void GotoCredits()
    {
        GameManager.Instance.sceneTransisionEvent = new GameManager.SceneTransisionEvent(gameObject.scene.name, "CreditsScene");
    }

}
