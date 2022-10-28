using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaController : MonoBehaviour
{
    bool placaPresionada=false;
    int placasParaPresionar=2;
    public Animator animatorPuerta;
    public int placasPresionadas=0;
    private void Update() {
        if(placaPresionada){
            animatorPuerta.SetBool("abrirPuerta", true);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag=="Cubos" && this.gameObject.tag=="PlacaPresion"){
            placaPresionada=true;
        }else if(other.tag=="Cubos" && this.gameObject.tag=="PlacasDobles"){
            
            placasPresionadas++;
            if(placasPresionadas==placasParaPresionar){
                placaPresionada=true;
            }
        }
    }
}
