using UnityEngine;

public class PowerUpLife : MonoBehaviour { 
  //Codigo da Poção Verde - Jogador ganha uma vida
  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Player")) {
      SoundController.PlaySound("powerUp");
      other.GetComponent<PlayerController>().SetPowerVida(1);
      Destroy(gameObject);
    }
  }
}