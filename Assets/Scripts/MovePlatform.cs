using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovePlatform : MonoBehaviour {  
  //Codigo para mover as Plataformas deslizantes 
  public SliderJoint2D slider;
  public JointMotor2D joint;
  
  void Start() {
    joint = slider.motor;
  }
  
  void Update() {
    if(slider.limitState == JointLimitState2D.LowerLimit){
      joint.motorSpeed = 2;
      slider.motor = joint;
    }

    if(slider.limitState == JointLimitState2D.UpperLimit){
      joint.motorSpeed = -2;
      slider.motor = joint;
    }
  }
}