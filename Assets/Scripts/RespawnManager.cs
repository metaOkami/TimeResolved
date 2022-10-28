using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public Transform spawn;

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag=="Paredes" && !InteractuableObjects.estaEmpujando){
            transform.parent=null;
            transform.position=spawn.position;
        }
    }

    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag=="Paredes" && !InteractuableObjects.estaEmpujando){
            transform.parent=null;
            transform.position=spawn.position;
        }
    }
}
