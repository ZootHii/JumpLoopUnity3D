using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    public float scaleX = 2.0f;
    public float scaleZ = 2.0f;

    private void FixedUpdate() {
        /*Vector3 scale = transform.localScale;
        scale.x = scaleX;
        scale.z = scaleZ;
        transform.localScale = scale;*/

        transform.localScale = new Vector3(scaleX, transform.localScale.y, scaleZ);

    }
}
