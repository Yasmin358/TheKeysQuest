using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class GeradorMorcego : MonoBehaviour {  
  public GameObject Morcego;
  public GameObject batPosition;
  int maxBat = 2;

  void Start() {
    StartCoroutine(RotinaCriarMorcego());
  }

  IEnumerator RotinaCriarMorcego() {
    while(true) {
      CriaMorcego();
      yield return new WaitForSeconds(10);
    }
  }

  void CriaMorcego(){
    int qtdBat = GameObject.FindGameObjectsWithTag("Morcego").Length;
    if (qtdBat < maxBat) {         
      Instantiate(Morcego, new Vector3(batPosition.transform.position.x, batPosition.transform.position.y, batPosition.transform.position.z), Quaternion.identity);
    }
  }
}