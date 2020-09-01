using UnityEngine;

public class CylinderBehaviour : MonoBehaviour
{

    public float speed = 35.0f;
    private Score score;
    void FixedUpdate()
    {
        transform.Rotate(0 ,0 , speed*Time.deltaTime);
    }
}
