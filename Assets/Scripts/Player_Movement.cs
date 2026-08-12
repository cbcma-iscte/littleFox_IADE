using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player_Movement : MonoBehaviour
{
    private CharacterController controller;
    public GameControl gameControl;
    public GameObject boatMove;
    private BoatMove bm;

    private bool isRightside = true;
    public float movementSpeed = 5f;
    public float rotationSpeed = 50f;
    Animator m_Animator;
    private float rangeInteraction;
        public GameObject PanelMessage;
    
    public Transform respawn_point;
    
    public Transform afterBoat1;
    public Transform afterBoat2;
    
    private float verticalVelocity = 0f;
    private float gravity = -9.81f;
    
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        bm = boatMove.GetComponent<BoatMove>();
        controller = GetComponent<CharacterController>();

        
    }

    // O teu Update corrigido
    void Update()
    {
        // --- 1. APLICAR GRAVIDADE ---
        if (controller.isGrounded)
        {
            verticalVelocity = -2f; 
        }
        else
        {
  
            verticalVelocity += gravity * Time.deltaTime;
        }


        Vector3 move = Vector3.zero; 

        if(Input.GetKey(KeyCode.UpArrow)){
            m_Animator.SetFloat("Walk", movementSpeed);
            move = transform.forward * movementSpeed; 
        }
        else if(Input.GetKey(KeyCode.DownArrow)){
            m_Animator.SetFloat("Walk", movementSpeed);
            move = -transform.forward * movementSpeed; 
        }
        else{
            m_Animator.SetFloat("Walk", 0f);
        }

        move.y = verticalVelocity;
        
        controller.Move(move * Time.deltaTime);


        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter(Collider other) {
        //Debug.Log(other.transform.tag);

        PanelMessage.SetActive(false);
        if(other.gameObject.tag.Equals("boat")) {
        //PanelMessage.SetActive(true);
        //PanelMessage.SetActive(false);
            boatInteract();
        }else if(other.gameObject.tag.Equals("food")){
            other.gameObject.GetComponent<Food>().Consume();
            gameControl.hamEated();    
            Destroy(other.gameObject);

        }else if(other.gameObject.tag.Equals("enemy")){
            
            gameControl.respawnPlayer(); 
            CharacterController controller = this.GetComponent<CharacterController>();
            
            if (controller != null) controller.enabled = false; // 1. Desliga as físicas
            
            this.transform.position = respawn_point.position;   // 2. Move a raposa em segurança
            
            if (controller != null) controller.enabled = true;  // 3. Volta a ligar as físicas
            // ----------------------------------
            
        }else if(other.gameObject.tag.Equals("tent")){
          gameControl.tentFinishGame();
        }
    }
        

        void boatInteract(){
            if(isRightside){
            this.transform.position = afterBoat1.position;
            isRightside = false;
            Debug.Log("Left Now");
            }else{
            this.transform.position = afterBoat2.position;
            isRightside = true;
            Debug.Log("Right Now");
            }
            bm.boatMoving();

        }
        
        
        
    }



