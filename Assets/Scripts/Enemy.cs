using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private int step;
    private int rangeAttack;
    private float movementSpeed = 2.5f;
    //private float rotationSpeed = 50f;
    //private bool rangeToFollow = false;
    private float detectDis = 20f;
    public Transform startMarker1;
    public Transform endMarker1;
    // Movement speed in units per second.
    public float speed = 1.0F;

    public Animator m_Animator;
    //bool walking = false;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;
    GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
      startTime = Time.time;
       m_Animator = gameObject.GetComponent<Animator>();
        m_Animator.SetBool("isWalking",false);
        Player = GameObject.FindWithTag("Player"); 
       
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        
        Vector3 direction = Player.transform.position - transform.position;
        //float distance= Vector3.Distance (transform.position, Player.transform.position);

        float angle = Vector3.Angle(direction, transform.forward);
        
        Debug.DrawRay(transform.position, direction, Color.red);
    
        if (angle < 35f && Physics.Raycast(transform.position,direction,out hit,detectDis)){
            Debug.Log("O raio bateu no objeto: " + hit.transform.name + " | Com a Tag: " + hit.transform.tag);
            if(hit.transform.tag=="Player"){
            //walking =true;
            m_Animator.SetBool("isWalking",true);
            transform.LookAt(Player.transform);
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, movementSpeed * Time.deltaTime);
           }
        }else{
            m_Animator.SetBool("isWalking",false);
        }
        }

        void enemyMoving(){
            //walking =true;
            float distCovered = (Time.time - startTime) * speed;
        // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;
             transform.position = Vector3.Lerp(startMarker1.position, endMarker1.position, fractionOfJourney);
            }
 
    
   
        
       
       
      
      

}
