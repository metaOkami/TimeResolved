using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisionDoblePlaca : MonoBehaviour
{
    public Animator anim;

    private void Update() {
        if(PlataformaDobleScript.plataformasPisadas>=2){
            anim.SetBool("abrirPuerta",true);
        }
    }
    
}
