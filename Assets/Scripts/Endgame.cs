using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Endgame : MonoBehaviour
{
    // Start is called before the first frame update
    public int escena;

      private void OnTriggerEnter(Collider other) {
        SceneManager.LoadScene(escena);
    }
}
