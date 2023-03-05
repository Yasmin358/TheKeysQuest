using UnityEngine;

public class KeyCollect : MonoBehaviour {  
  //Codigo das Chaves - ao coletar a chave, a fase termina
  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Player")) {
      other.gameObject.GetComponent<CollectObjects>().SetChave(true);
      Destroy(gameObject);
    }
  }
}