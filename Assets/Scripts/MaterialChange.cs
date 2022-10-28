using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChange : MonoBehaviour
{ 
    public Material puertaCerrada;
    public Material puertaAbierta;
    Material actualMaterial;
    public GameObject objeto;

    private void Start() {
        actualMaterial=this.gameObject.GetComponent<Material>();
    }
    public void changeMat(){
        if(actualMaterial.name=="MarcoPuertaRed"){
            objeto.GetComponent<MeshRenderer>().material=puertaAbierta;
        }
    }
}
