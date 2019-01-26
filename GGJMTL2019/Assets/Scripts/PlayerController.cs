using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerController : MonoBehaviour
{
    public float speed;
    public float verticalSpeed;

    private new Rigidbody2D rigidbody2D;
    private string darkWorldSceneName;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        gameManager = GameManager.Instance;

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rigidbody2D.AddForce(movement * speed);

        if (Input.GetButtonDown("Fire1"))
        {
            rigidbody2D.AddForce(new Vector2(0, verticalSpeed));
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Desk1" && Input.GetButtonDown("Fire2"))
        {
           
            Debug.Log("Tu as trouvé une clé!!");
            gameManager.inventory.addItem(Inventory.ItemTypes.SCISSOR);
        }
    }
}
