using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightEnnemyController : MonoBehaviour
{

    private bool playerKilled = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject colloidedWith = collision.gameObject;
        PlayerController player = colloidedWith.GetComponentInChildren<PlayerController>();
        if (player && !playerKilled)
        {
            playerKilled = true;
            player.kill();
            GameManager.Instance.sceneTransisionEvent = new GameManager.SceneTransisionEvent(gameObject.scene.name, "GetAsleepInfo");
        }
    }
}
