using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaDobleScript : MonoBehaviour
{
    static public int plataformasPisadas=0;
    static public bool isOver=false;
    
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Cubos"){
            plataformasPisadas++;
        }
    }
    private void OnTriggerStay(Collider other) {
        if(other.tag=="Cubos"){
            isOver=true;
        }
    }
}
