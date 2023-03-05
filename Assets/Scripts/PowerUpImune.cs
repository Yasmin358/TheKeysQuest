using UnityEngine;

public class PowerUpImune : MonoBehaviour {
  //Codigo da poção Laranja - Jogador fica Imune 
  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Player")) {
      SoundController.PlaySound("powerUp");
      other.GetComponent<PlayerController>().SetImune(true);
      Destroy(gameObject);
    }
  }
}