using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerConrtoller : MonoBehaviour
{

#region Variables

    public Transform mirarBotón;
    public bool isInRange;
    public float moveSpeed;
    public float jumpForce=15;
    private Vector3 moveDirection;
    public float gravityScale;
    private Camera theCam;
    public GameObject playerModel;
    public float rotateSpeed;
    public Animator animator;
    static public bool pulsaBoton=false;
    public  CharacterController charController;
    public bool isGrounded;
    public float distanceOfGroundDetection;
    public InteractuableObjects miInteractuableObjects;
    public ParticleSystem platformFire;
    
    //Cooldown parar tiempo
   
    public float cooldown;
    float Timer;
    bool canStopTime=true;
    float timeWithTimeStoped=0;

    public AudioClip[] timeStopSounds=new AudioClip[2];
    public AudioSource soundSource;
    

    //Checker de que el player cae

    private float lastY;    
    public float FallingThreshold = -0.01f;  //Adjust in inspector to appropriate value for the speed you want to trigger detecting a fall, probably by just testing (use negative numbers probably)
    [HideInInspector]
    public bool Falling = false;

    public GameObject menuPausa;


    //Variable para la mision final
    static public bool haActivadoEnergia=false;
    


    


#endregion

#region MecanicaPararTiempo
    public static bool timeStoped;
    public GameObject timeStopPostProcessing;

#endregion


    // Start is called before the first frame update
    void Start()
    {
        timeStoped=false;
        theCam=Camera.main;
        timeStopPostProcessing.SetActive(false);
        Timer=0;
        Cursor.visible=false;
        Cursor.lockState=CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(InteractuableObjects.estaEmpujando){
            moveDirection=(transform.forward*Input.GetAxisRaw("Vertical"));
        }
        
        AnimatorCheck();
        jumpCheck();

        if(timeStoped){
            timeWithTimeStoped+=Time.deltaTime;
            if(timeWithTimeStoped>=10){
                
                
                timeStoped=false;
                soundSource.PlayOneShot(timeStopSounds[1]);
                timeWithTimeStoped=0;
                Timer=5;
                timeStopPostProcessing.SetActive(false);
            }
        }

        Timer-=Time.deltaTime;
        float distancePerSecondSinceLastFrame = (transform.position.y - lastY) * Time.deltaTime;
        lastY = transform.position.y;  //set for next frame
        if (distancePerSecondSinceLastFrame < FallingThreshold)
        {
            Falling = true;
        }
        else
        {
            Falling = false;
        }

        if(Timer<=0){
            canStopTime=true;
        }else{
            canStopTime=false;
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            Cursor.visible=true;
            Cursor.lockState=CursorLockMode.None;
        }

    }

    private void FixedUpdate() {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,-transform.up,out hit,distanceOfGroundDetection)){
            isGrounded=true;
        }else{
            isGrounded=false;
        }
    }

 


  void AnimatorCheck()
    {

        //Variables para animacion
           
        animator.SetFloat("Speed", Mathf.Abs(moveDirection.x) + Mathf.Abs(moveDirection.z));
        animator.SetBool("Grounded", charController.isGrounded);
        animator.SetBool("Empuja", miInteractuableObjects.empujado);


        //Checkeamos animacion
        if(animator.GetCurrentAnimatorStateInfo(0).IsTag("locomotion")){
            Locomotion(); //puede moverse
            StopTime(); //puedo parar el tiempo
            AccionBoton();
        }


        if(animator.GetCurrentAnimatorStateInfo(0).IsTag("empujo")){
            LocomotionEmpujando();
        }
    }


     private void OnTriggerStay(Collider other) {
        if(other.tag=="Button"){
            isInRange=true;
        }
    }
    private void OnTriggerExit(Collider other) {
        if(other.tag=="Button"){
            isInRange=false;
        }
    }
public void Locomotion(){



        float yStore = moveDirection.y;
        

        //Moverse

        //moveDirection=new Vector3(Input.GetAxisRaw("Horizontal"), 0,Input.GetAxisRaw("Vertical"));
        moveDirection=(transform.forward*Input.GetAxisRaw("Vertical"))+(transform.right*Input.GetAxisRaw("Horizontal"));
        moveDirection.Normalize();
      
        moveDirection=moveDirection*moveSpeed;
         //si toco el suelo
        if(isGrounded){
              moveDirection.y =0;
        }else{
            moveDirection.y = yStore;
        }

        
        
        if(Input.GetKeyDown(KeyCode.Space)){
            if(charController.isGrounded){
                if(!Falling){
                    moveDirection.y=jumpForce;
                }

            }
        }

        moveDirection.y+=Physics.gravity.y*gravityScale*Time.deltaTime;
        
        
        charController.Move(moveDirection*Time.deltaTime);
      
     



        //transform.position+=(moveDirection*Time.deltaTime*moveSpeed);

        if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0){
            // charController.Move(moveDirection * Time.deltaTime);
            // // transform.rotation=Quaternion.Euler(0f,theCam.transform.rotation.eulerAngles.y,0f);
            // Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x,0f,moveDirection.z));
            // playerModel.transform.rotation=Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed *Time.deltaTime);
            if(!InteractuableObjects.estaEmpujando){
                transform.rotation = Quaternion.Euler(0f, theCam.transform.rotation.eulerAngles.y, 0f);
                Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));

                //Accedemos al jugador y le cambiamos su rotación, con Slerp lo hacemos más suavamente, cambiando de 0 a 90 grados por ejemplo, no de golpe, sino gradualmente conforme nos acercamos decelerando
                playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime); 
            }
            
            //A Slerp hay que pasarle la rotación actual, la rotación a la que queremos llegar, y la velocidad de rotación
            
        }
        
}
    public void LocomotionEmpujando(){

        float yStore = moveDirection.y;

        //Moverse

        //moveDirection=new Vector3(Input.GetAxisRaw("Horizontal"), 0,Input.GetAxisRaw("Vertical"));
        moveDirection=(transform.forward*Input.GetAxisRaw("Vertical"));
        moveDirection.Normalize();
        moveDirection=moveDirection*moveSpeed / 2 ;
        moveDirection.y = yStore;
        
        

        moveDirection.y+=Physics.gravity.y*Time.deltaTime*gravityScale;
        charController.Move(moveDirection*Time.deltaTime);
        //transform.position+=(moveDirection*Time.deltaTime*moveSpeed);

       
        
    }
    public void StopTime(){

       //Parar el tiempo
        
        if(Input.GetKeyDown(KeyCode.F)){
             
            if(!timeStoped && canStopTime){
                
                soundSource.PlayOneShot(timeStopSounds[0]);
                platformFire.Pause();
                timeStopPostProcessing.SetActive(true);
                timeStoped=true;
                Timer=5;
            }else if(timeStoped){
                
                soundSource.PlayOneShot(timeStopSounds[1]);
                timeStopPostProcessing.SetActive(false);
                timeStoped=false;
                Timer=5;
                platformFire.Play();
            }
        }
    }
    

    public void AccionBoton(){

        if(isInRange){
            if(Input.GetKeyDown(KeyCode.E)){
                
                //transform.LookAt(mirarBotón);
                transform.LookAt(new Vector3(mirarBotón.position.x, transform.position.y, mirarBotón.position.z));
                animator.SetTrigger("ButtonPress");
                pulsaBoton=true;
                haActivadoEnergia=true;
                Debug.Log(haActivadoEnergia);
            }
            
        }

    }

    public void jumpCheck(){
        if(!isGrounded){
            moveSpeed=13;
        }else{
            moveSpeed=5;
        }
    }
    


    
}
