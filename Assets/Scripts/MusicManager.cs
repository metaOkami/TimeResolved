using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource Sound;
    /*
    Lista de sonidos en orden en el array
    1- Correr
    2- Saltar
    3- Arrastrar
    4- Parar el tiempo
    5- Reanudar tiempo
    6- Caer
    */

    public AudioClip[] PlayerClips;

    public void WalkSound(){
        Sound.PlayOneShot(PlayerClips[0]);
    }

    public void JumpSound(){
        Sound.PlayOneShot(PlayerClips[1]);
    }

    public void MoveBox(){
        if(InteractuableObjects.estaEmpujando){
            Sound.PlayOneShot(PlayerClips[2]);
        }
        
    }

    public void StopTime(){
        Sound.PlayOneShot(PlayerClips[3]);
    }
    public void ReanudeTime(){
        Sound.PlayOneShot(PlayerClips[4]);
    }

    public void Landing(){
        Sound.PlayOneShot(PlayerClips[5]);
    }

    public void StopPushing(){
        if(!InteractuableObjects.estaEmpujando){
            Sound.Stop();
        }
    }
}
