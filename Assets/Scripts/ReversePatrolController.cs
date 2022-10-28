using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReversePatrolController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform patrolPoint1;
    public Transform patrolPoint2;
    private Transform targetPoint;
    public float speed;
    public ParticleSystem particles;

    private void Start() {
        targetPoint=patrolPoint1;
        particles.Stop();
    }

    private void FixedUpdate() {
        if(PlayerConrtoller.timeStoped && PlayerConrtoller.haActivadoEnergia){
            particles.Play();
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
        }else{
            particles.Pause();
        }
    }

}
