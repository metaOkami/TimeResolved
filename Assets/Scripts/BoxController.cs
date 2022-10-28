using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private void FixedUpdate() {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,-transform.up,out hit,1.5f)){
            if(hit.collider.tag=="Obstacle"){
                if(transform.parent.name=="PlayerPadre"){
                    transform.parent=null;
                    transform.position=Vector3.MoveTowards(transform.position,new Vector3(hit.transform.position.x,0,hit.transform.position.z),3f*Time.deltaTime);
                }else{
                    transform.parent=hit.transform;
                }
                
            }
        }
    }
}
