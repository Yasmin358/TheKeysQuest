using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeMovement : MonoBehaviour {
  public Transform Spike;
  public Transform pontA;
  public Transform pontB;
   
  float Speed = 3;
  float timer = 0;
  float waitTimer = 10;
  float openTimer = 5;
  bool moving = false;   
  Vector3 nextPont;
  
  void Start() {
      nextPont = pontA.position;
  }
  
  // Update is called once per frame
  void Update() {
    if (moving == false) {
      timer += Time.deltaTime;
    }

    if (transform.position == pontA.position) { 
      if (timer > waitTimer) {   
        timer = timer - waitTimer;
        nextPont = pontB.position;
        moving = true;
      }  
    }
    
    if (transform.position == pontB.position) {
      if (timer > openTimer) {
        timer = timer - openTimer;;
        nextPont = pontA.position;
        moving = true;
      }
    }
    
    transform.position = Vector3.MoveTowards(transform.position, nextPont, Speed* Time.deltaTime);
    
    if (transform.position == nextPont) {
      moving = false; 
    }   
  }
}