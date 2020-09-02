using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower;
    public Rigidbody playerRB;
    private bool onPlatform = true;

    private void Update() {
        if(Input.GetMouseButtonUp(0)){
            if(onPlatform){
                onPlatform = false;
                playerRB.AddForce(new Vector3(0,jumpPower,0) , ForceMode.Impulse);
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        if(other.transform.tag == "Platform"){
            onPlatform = true;
        }
        if(other.transform.tag == "Plane"){
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
