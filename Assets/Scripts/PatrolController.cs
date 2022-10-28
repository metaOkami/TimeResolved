using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolController : MonoBehaviour
{
    public Transform patrolPoint1;
    public Transform patrolPoint2;
    private Transform targetPoint;
    public float speed;

    private void Start() {
        targetPoint=patrolPoint1;
    }

    private void FixedUpdate() {
        if(!PlayerConrtoller.timeStoped){
            if (transform.position == targetPoint.position)
            {
                if (targetPoint == patrolPoint1)
                {
                    targetPoint = patrolPoint2;
                }
                else
                {
                    targetPoint = patrolPoint1;
                }
            }

            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.fixedDeltaTime);
        }
    }


}
