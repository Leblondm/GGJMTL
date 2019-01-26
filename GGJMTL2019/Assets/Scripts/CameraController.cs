using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public float offsetXLeft;
    public float offsetXRight;
    public float offsetY;


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        smoothedPosition.x = Mathf.Max(smoothedPosition.x, offsetXLeft);
        smoothedPosition.x = Mathf.Min(smoothedPosition.x, offsetXRight);

        smoothedPosition.y = Mathf.Max(smoothedPosition.y, offsetY * -1);
        transform.position = smoothedPosition;
    }
   
}
