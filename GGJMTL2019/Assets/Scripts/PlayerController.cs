using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;

    private GameManager gameManager;

    float horizontalMove = 0f;
    bool jump = false;
    bool canJump = false;
    bool crouch = false;
    bool cantMove = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        controller.OnLandEvent.AddListener(() => {
            canJump = true;
            animator.SetBool("IsJumping", false);
        });
    }

    private void Update()
    {
        if(cantMove == true) return;

        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (canJump && Input.GetButtonDown("Jump"))
        {
            //Debug.Log("Jump");
            jump = true;
            animator.SetBool("IsJumping", true);
            canJump = false;
        }

        crouch = Input.GetAxis("Vertical") < 0;
    }

    void FixedUpdate()
    {
        if (cantMove) return;

        /* if (horizontalMove != 0)
        {
            FindObjectOfType<AudioManager>().Play("footstep");
        }
        else
        {
            FindObjectOfType<AudioManager>().Stop("footstep");
        } */

        // Move Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Desk1" && Input.GetButtonDown("User action"))
        {
            // Debug.Log("Tu as trouvé une clé!!");
            gameManager.inventory.addItem(Inventory.ItemTypes.Desk1);
            FindObjectOfType<AudioManager>().Play("jingle_item_5");
        }

        if (other.gameObject.tag == "BedRoomKey" && Input.GetButtonDown("User action"))
        {
            gameManager.bedroomTextMessage = "Maybe you can use this key...";
            gameManager.inventory.addItem(Inventory.ItemTypes.BedRoomKey);
            FindObjectOfType<AudioManager>().Play("jingle_item_5");
        }
    }

    public void kill()
    {
        cantMove = true;
        animator.SetTrigger("Killed");
    }
}
