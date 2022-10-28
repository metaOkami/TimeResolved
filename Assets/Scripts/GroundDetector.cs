using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    public bool isGrounded;
    public Vector3 lastObjectPosition;
    private void Start() {
        isGrounded=true;
    }

    private void Update() {
        RaycastHit hit;
        if(Physics.Raycast(this.transform.position,-transform.up,out hit,2)){
            isGrounded=true;
        }else if(transform.position.y<lastObjectPosition.y+2f){
            isGrounded=false;
        }
    }

    private void LateUpdate() {
        lastObjectPosition=transform.position;
    }
}
