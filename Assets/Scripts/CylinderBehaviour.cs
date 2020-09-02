using UnityEngine;

public class CylinderBehaviour : MonoBehaviour
{
    public static CylinderBehaviour instance;
    public float speed = 35.0f;

    private void Awake()
    {
        instance = this;
    }

    void FixedUpdate()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }

    public void IncreaseSpeed()
    {
        if (speed < 120)
        {
            speed += 4.0f;
            if (speed > 120)
            {
                speed = 120;
            }
        }
    }
}
