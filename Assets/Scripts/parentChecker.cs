using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentChecker : MonoBehaviour
{
    

    private void Update() {
        if(transform.parent!=null && !InteractuableObjects.estaEmpujando){
            transform.parent=null;
        }
    }
}
