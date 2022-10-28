using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float timeOfLife;
    public float speed;
    float timer=0;
    public GameObject Player;
    static Vector3 lastPlayerPosition;
    public GameObject Torreta;
   
    private void Start() {
        transform.parent=null;
    }
    private void Update() {
        if(!PlayerConrtoller.timeStoped){
            transform.position = Vector3.MoveTowards(this.transform.position, EnemyController.lastPlayerPosition, speed * Time.deltaTime);
            timer += Time.deltaTime;

            if (timer >= timeOfLife)
            {
                Destroy(this.gameObject);
            }
        }
        
    }

    
    
}
