using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float verticalSpeed;
    private new Rigidbody2D rigidbody2D;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal, 0);
        rigidbody2D.AddForce(movement * speed);

        if (Input.GetButtonDown("Fire1")) {
            Debug.Log("Patate!");
            rigidbody2D.AddForce(new Vector2(0, verticalSpeed));
        }
    }

}
