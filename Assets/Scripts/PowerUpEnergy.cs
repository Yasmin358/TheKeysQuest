using UnityEngine;

public class PowerUpEnergy : MonoBehaviour {  
  //Codigo da Poção Azul - Energia do Jogador é restaurada 
  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Player")) {
      SoundController.PlaySound("powerUp");
      other.GetComponent<PlayerController>().SetEnergia(100);
      Destroy(gameObject);
    }
  }
}