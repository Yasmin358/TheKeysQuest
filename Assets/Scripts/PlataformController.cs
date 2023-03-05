using UnityEngine;

public class PlataformController : MonoBehaviour {
  
  //Codigo das Plataformas Fastamas - Desaparecem e Aparecem em um periodo de tempo especifico  
  public float timer = 0;
  float VisibleTimer = 5f;
  float InvisibleTimer = 10f;
  bool platform = true;
  public GameObject plataforma;

  private void Update() {
    timer += Time.deltaTime;
    if(timer > VisibleTimer && platform == true){
      timer = timer - VisibleTimer;
      platform = false;
      plataforma.SetActive(false); 
    }

    if(timer > InvisibleTimer && platform == false){
      timer = timer - InvisibleTimer;
      platform = true;
      plataforma.SetActive(true);      
    }
  }
}