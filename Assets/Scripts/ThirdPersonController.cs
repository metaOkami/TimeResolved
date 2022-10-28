using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    public Vector3 offset;
    public Vector3 yOffset;
    private Transform target;
    [Range(0,1)] public float lerpValue;
    public float sensibility;

    private void Start() {
        target=GameObject.Find("Player").transform;
    }

    private void LateUpdate() {
        transform.position=Vector3.Lerp(transform.position, target.position + offset, lerpValue);
        offset=Quaternion.AngleAxis(Input.GetAxis("Mouse X")*sensibility,Vector3.up)*offset;
        yOffset=Quaternion.AngleAxis(Input.GetAxis("Mouse Y")*sensibility,Vector3.down)*offset;
        

        transform.LookAt(target);
    }
}

