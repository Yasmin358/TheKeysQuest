using UnityEngine;

public class TiroAzul :Tiro {
  //TiroAzul herda a classe tiro que é responsavel pelo movimento do tiro
  //TiroAzul faz o controle de dano ao colidir com um inimigo
  
  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.CompareTag("Morcego")) {   
      spell();
      other.gameObject.GetComponent<MorcegoController>().SetEnemyLife(50);           
      Destroy(gameObject, 0.5f);             
    }

    if (other.gameObject.CompareTag("Bat")) {   
      spell();
      other.gameObject.GetComponent<BatController>().SetEnemyLife(50);           
      Destroy(gameObject, 0.5f);             
    }

    if (other.gameObject.CompareTag("Cacador")) {
      spell();
      other.gameObject.GetComponent<CacadorController>().SetEnemyLife(25);                       
      Destroy(gameObject, 0.5f);
    }

    if (other.gameObject.CompareTag("Chao")) {
      spell();         
      Destroy(gameObject, 0.5f);                                  
    }

    if(other.gameObject.CompareTag("Feiticeira")) {
      spell();
      other.gameObject.GetComponent<EnemyController>().SetEnemyLife(12.5f);
      Destroy(gameObject, 0.5f);
    }

    if(other.gameObject.CompareTag("Fire")) {
      spell();
      Destroy(gameObject, 0.5f);
    }

    if(other.gameObject.CompareTag("Arrow")) {
      spell();
      Destroy(gameObject, 0.5f);
    }
  } 
}
