using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LimitsController : MonoBehaviour
{    
    void OnTriggerExit2D(Collider2D other)
    {
        // Destroy(other.gameObject);
        
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }
}
