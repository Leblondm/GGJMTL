using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float verticalSpeed;

    private new Rigidbody2D rigidbody2D;
    private string darkWorldSceneName;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        darkWorldSceneName = SceneManager.GetActiveScene().name + "Dark";
        SceneManager.LoadScene(darkWorldSceneName, LoadSceneMode.Additive);
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

        if (Input.GetButtonDown("Fire1"))
        {
            rigidbody2D.AddForce(new Vector2(0, verticalSpeed));
        }

        if (Input.GetButtonDown("Fire3"))
        {
            foreach (GameObject gameObject in SceneManager.GetSceneByName(darkWorldSceneName).GetRootGameObjects())
            {
                if (gameObject.activeSelf)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(true);
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Desk1" && Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Tu as trouvé une clé!!");
        }
    }
}
