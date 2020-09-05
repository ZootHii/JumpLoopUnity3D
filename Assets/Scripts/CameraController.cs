using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    
    public Transform playerTransform;

    private void FixedUpdate()
    {
        transform.position = new Vector3(playerTransform.position.x, 1.5f, playerTransform.position.z - 6);
        if (playerTransform.position.y < -0.28)
        {
            transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 1.75f, playerTransform.position.z - 6);
        }
    }
}
