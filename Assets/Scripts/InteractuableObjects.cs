using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractuableObjects : MonoBehaviour
{
    
     public bool empujado = false;
    public LayerMask layer;
    static public bool estaEmpujando=false;
    


    private void FixedUpdate() {
      
        RaycastHit rayHit;
        RaycastHit groundDetectorRay;
        

        if (Physics.Raycast(transform.position, transform.forward, out rayHit, 2f, layer) && Input.GetKey(KeyCode.Mouse0))
        {
            if (rayHit.collider.tag == "Cubos")
            {
                
                estaEmpujando=true;
                empujado = true;
                //ROTACION DE GOLPE
                transform.rotation =  Quaternion.LookRotation(-rayHit.normal, Vector3.up);
                //EMPARENTANDO
                rayHit.transform.parent = transform;
                /////////////direccion mirando a la caja poco a poco
                
                

                Vector3 pointOfHit=rayHit.point;
                if(!Physics.Raycast(pointOfHit,-Vector3.up,out groundDetectorRay,2)){
                    rayHit.transform.parent=null;
                }
             }
            
        }else{
            
            estaEmpujando=false;
            empujado=false;
            // rayHit.transform.parent=null;
            try
            {
                
               rayHit.transform.parent=null; 
               
            }
            catch 
            {
                
                
            }
            
        }
        
    }

  
    
}
