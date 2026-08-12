using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BoatMove : MonoBehaviour
{
    //private float boat_speed = 1f;
    private bool isRightPositioned = true;
    public Transform left_pos;
    public Transform right_pos;
      public GameObject boat;
    // Start is called before the first frame update

    public void boatMoving(){
           
             //float step = boat_speed * Time.deltaTime;
             if(isRightPositioned){
                
                Debug.Log("ola");
                boat.transform.position = left_pos.position;
                isRightPositioned=false;
                
             }else{
                
                Debug.Log("adeus");
                boat.transform.position = right_pos.position;
                isRightPositioned=true;
                 
             }

    }
}

