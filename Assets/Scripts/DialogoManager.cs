using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogoManager : MonoBehaviour
{
    public Animator dialogoAnim;
    public float secsToDisappear=5;
    float Timer;
    public Text dialogoInicial;
    public Text dialogoDos;
    public Text dialogoFinal;
    public Text dialogoFinal2;
    public Text currentDialog;
    public int timesFinalDialog=1;

    private void Start() {
        currentDialog.text=dialogoInicial.text;
        dialogoAnim.SetBool("dialogoAparece", true);
    }
    private void Update() {
        Timer+=Time.deltaTime;
        if(Timer>=secsToDisappear){
            
            dialogoAnim.SetBool("dialogoAparece",false);
            
        }else{
            
            dialogoAnim.SetBool("dialogoAparece", true);
        }

        if(PlayerConrtoller.haActivadoEnergia && timesFinalDialog==1){
            currentDialog.text=dialogoFinal2.text;
            Timer=0;
            timesFinalDialog=0;
        }
    }


    private void OnTriggerEnter(Collider other) {
        if(other.tag=="zona1"){
            currentDialog.text=dialogoDos.text;
            Timer=0;
            other.gameObject.SetActive(false);
            
        }else if(other.tag=="zona2"){
            currentDialog.text=dialogoFinal.text;
            Timer=0;
            other.gameObject.SetActive(false);
        }
    }
    

   

}
