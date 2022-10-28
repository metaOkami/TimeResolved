using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXManager : MonoBehaviour
{
    public AudioSource soundSource;
    public AudioClip[] Effects;

    /*
    Lista de orden de efectos en el array
    1- Abrir puerta
    */

    public void OpenDoor(){
        soundSource.PlayOneShot(Effects[0]);
    }
}
