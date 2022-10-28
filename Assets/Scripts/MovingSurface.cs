using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSurface : MonoBehaviour
{
    CharacterController player;
    Vector3 groundPosition;
    Vector3 lastGroundPosition;
    string groundName;
    string lastGroundName;

    private void Start() {
        player=this.GetComponent<CharacterController>();
    }

    private void FixedUpdate() {
        if(player.isGrounded){
            RaycastHit hit;

            if(Physics.SphereCast(transform.position, player.height/4,-transform.up,out hit)){
                GameObject groundedIn=hit.collider.gameObject;
                groundName=groundedIn.name;
                groundPosition=groundedIn.transform.position;

                if(groundPosition!=lastGroundPosition && groundName==lastGroundName){
                    this.transform.position+=groundPosition-lastGroundPosition;
                    
                }

                lastGroundName=groundName;
                lastGroundPosition=groundPosition;
            }
        }else if(!player.isGrounded){
            lastGroundName=null;
            lastGroundPosition=Vector3.zero;
        }
        
    }
    

}
