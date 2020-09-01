using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{

    public Score score;
    public CylinderBehaviour cylinderBehaviour;
    public PlatformBehaviour platformBehaviour;

    public void OnTriggerEnter(Collider other) {
        if(other.transform.tag == "Player"){
            score.scoreInt += 1;
            if(cylinderBehaviour.speed < 120){
                cylinderBehaviour.speed += 4.0f;
                if(cylinderBehaviour.speed > 120){
                    cylinderBehaviour.speed = 120;
                }
            }
        }
        if(score.scoreInt == 10 || score.scoreInt == 20){
            platformBehaviour.scaleX += 0.7f;
            platformBehaviour.scaleZ += 0.7f;
        } else if(score.scoreInt == 30){
            platformBehaviour.scaleX += 1.0f;
            platformBehaviour.scaleZ += 1.0f;
        }
    }
}
