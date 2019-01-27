using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RedEmenyController : MonoBehaviour
{
    public CharacterController2D controller;
    public float runSpeed = 40f;

    private Animator animator;                          //Variable of type Animator to store a reference to the enemy's Animator component.
    private Transform target;


    private BoxCollider2D boxCollider;      //The BoxCollider2D component attached to this object.
    private Rigidbody2D rb2D;              //The Rigidbody2D component attached to this object.
    private PlayerController fakePlayer;

    private bool playerKilled = false;

    float horizontalMove = 0f;

    // Start is called before the first frame update
    void Start()
    {
        //Get a component reference to this object's BoxCollider2D
        boxCollider = GetComponent<BoxCollider2D>();

        //Get a component reference to this object's Rigidbody2D
        rb2D = GetComponent<Rigidbody2D>();

        //Get and store a reference to the attached Animator component.
        animator = GetComponent<Animator>();

        //Find the Player GameObject using it's tag and store a reference to its transform component.
        target = GameObject.FindGameObjectWithTag("Player").transform;
        horizontalMove = -1 * runSpeed;

        fakePlayer = new PlayerController();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    void FixedUpdate()
    {
        // Move Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject colloidedWith = collision.gameObject;
        PlayerController player = colloidedWith.GetComponentInChildren<PlayerController>();
        if (player && !playerKilled)
        {
            Debug.Log("Collided with player");
            animator.SetTrigger("Attacks");
            playerKilled = true;
            player.kill();
            GameManager.Instance.sceneTransisionEvent = new GameManager.SceneTransisionEvent(gameObject.scene.name, "GetAsleepInfo");
        }
    }

 
}
