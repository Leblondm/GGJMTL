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

    // Start is called before the first frame update
    void Start()
    {
        controller.OnLandEvent.AddListener(() => {
            Debug.Log("LANDED !");
            canJump = true;
            animator.SetBool("IsJumping", false);
        });
    }

    private void Update()
    {
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
        // Move Character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Desk1" && Input.GetButtonDown("Fire2"))
        {
           
            Debug.Log("Tu as trouvé une clé!!");
            gameManager.inventory.addItem(Inventory.ItemTypes.Desk1);
        }
    }
}
