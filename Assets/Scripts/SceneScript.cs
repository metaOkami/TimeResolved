using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{
    public Canvas Controls;
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Return) && Controls.enabled){
            Controls.enabled=false;
        }else if(Input.GetKeyDown(KeyCode.Return) && !Controls.enabled){
            Controls.enabled=true;
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }
    public void Sandbox(){
        SceneManager.LoadScene(0);
    }
    public void Levels(){
        SceneManager.LoadScene(1);
    }
}
