using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform bulletSpawn;
    public float cooldown;
    SphereCollider visionArea;  //Collider en trigger que determina el area en el cual la torreta se activa y te ataca
    float areaDistance; //Radio del spherecollider de arriba
    static public GameObject target;
    static public Vector3 lastPlayerPosition;
    public GameObject bulletPrefab;
    public float Timer;

    private void Start() {
        visionArea=this.GetComponent<SphereCollider>();
        areaDistance=visionArea.radius;
        
    }

    private void Update() {
        
        if(!PlayerConrtoller.timeStoped){
            Timer += Time.deltaTime;
        }

        RaycastHit hit;
        if(Physics.Raycast(bulletSpawn.position,transform.forward, out hit, areaDistance)){
            if(hit.collider.tag=="Player" && Timer>=cooldown){
                if(!PlayerConrtoller.timeStoped){
                    Instantiate(bulletPrefab,bulletSpawn);
                    target = hit.collider.gameObject;
                    lastPlayerPosition = hit.collider.transform.position;
                    Timer = 0;
                }
            }
        }
    }

    
    private void OnTriggerStay(Collider other) {
        if(other.tag=="Player"){
           // transform.LookAt(other.transform.position);
            
            if(!PlayerConrtoller.timeStoped){
                transform.LookAt(new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z));
            }
        }
    }

    
}
