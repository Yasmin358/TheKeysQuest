using UnityEngine;
using System.Collections;

public class RotateCristal : MonoBehaviour {
  //Codigo para girar os cristais no eixo z
  int Speed = 30;
  
  void Start() {
      
  }
  
  void Update() {
      transform.Rotate (0,0,Speed * Time.deltaTime);
  }
}