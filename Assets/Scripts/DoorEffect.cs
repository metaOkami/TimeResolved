using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEffect : MonoBehaviour
{
    public Material openDoor;
    public Animator dialogoAnimator;
    public Animator puertaAnimator;
    public void OpenDoor(){
        this.GetComponent<MeshRenderer>().material=openDoor;
    }

    private void Update() {
        
        try
        {
           if(dialogoAnimator.GetBool("dialogoAparece")==false){
            puertaAnimator.SetBool("abrirPuerta",true);
        } 
        }
        catch 
        {
            
            
        }
    }
}
