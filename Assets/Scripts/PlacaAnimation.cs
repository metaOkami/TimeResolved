using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaAnimation : MonoBehaviour
{
    public Animator placaAnimator;
    private void OnTriggerEnter(Collider other) {
        placaAnimator.SetBool("placaPresionada",true);
    }
    private void OnTriggerExit(Collider other) {
        placaAnimator.SetBool("placaPresionada",false);
    }
}
