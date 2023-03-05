using UnityEngine;

public class PowerUpPower : MonoBehaviour {
  //Codigo da Poção Roxa - Tiro roxo é ativado
  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Player")) {
      SoundController.PlaySound("powerUp");
      other.GetComponent<PlayerController>().SetPower(true);
      Destroy(gameObject);
    }
  }
}