using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower = 22;
    public Rigidbody playerRB;
    private bool onPlatform = true;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (onPlatform)
            {
                onPlatform = false;
                playerRB.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Platform")
        {
            onPlatform = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "JumpTrigger")
        {
            ScoreManager.instance.IncreaseScore();
            CylinderBehaviour.instance.IncreaseSpeed();
            PlatformBehaviour.instance.IncreaseScale();
        }
        if (other.transform.tag == "Plane")
        {
            GameManager.instance.GameOver();
        }
    }

}
