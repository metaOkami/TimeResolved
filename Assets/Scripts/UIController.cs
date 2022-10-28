using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{
    
    
    public int escena;
    public Canvas menuPausa;
    
    private void Start() {
        
        if(SceneManager.GetActiveScene().name=="FinishGame"){
            Cursor.lockState=CursorLockMode.None;
            Cursor.visible=true;
            menuPausa=null;
        }
        try
        {
            menuPausa.enabled=false;
        }
        catch 
        {
            
        }
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            try
            {
                if(Time.timeScale==1 && menuPausa.enabled==false){
                    menuPausa.enabled=true;
                    Time.timeScale=0;
                }else{
                    menuPausa.enabled=false;
                    Time.timeScale=1;
                }
            }
            catch 
            {
                
              
            }
        }
    }
    public void CambiarEscena(string escena)
    {
        SceneManager.LoadScene(escena);
    }

    public void Exit(){
        Application.Quit();
    }

    
    
}
