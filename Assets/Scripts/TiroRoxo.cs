using UnityEngine;

public class TiroRoxo : Tiro {  
  //TiroRoxo tambem herda a classe tiro que é responsavel pelo movimento do tiro
  //TiroRoxo faz o controle de dano ao colidir com um inimigo
  //A diferença é o tamanho do dano, que é dobrado.

  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.CompareTag("Morcego")) {
      spell();
      other.gameObject.GetComponent<MorcegoController>().SetEnemyLife(100);
      Destroy(gameObject, 0.5f);
    }

    if (other.gameObject.CompareTag("Bat")) {   
      spell();
      other.gameObject.GetComponent<BatController>().SetEnemyLife(50);           
      Destroy(gameObject, 0.5f);             
    }

    if (other.gameObject.CompareTag("Cacador")) {
      spell();
      other.gameObject.GetComponent<CacadorController>().SetEnemyLife(50);
      Destroy(gameObject, 0.5f);
    }

    if (other.gameObject.CompareTag("Chao")) {
      spell();          
      Destroy(gameObject, 0.5f);                                            
    }

    if (other.gameObject.CompareTag("Arrow")) {
      spell();
      Destroy(gameObject, 0.5f);
    }
  }
}
