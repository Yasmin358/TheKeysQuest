using UnityEngine;

public class PowerUpTime : MonoBehaviour {
  private GameObject canvas;

  private void Start() {
      canvas = GameObject.Find("Canvas");
  }
  
  //Codigo da Poção Verde - Jogador ganha uma vida
  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Player")) {
      SoundController.PlaySound("powerUp");
      canvas.GetComponent<CanvaController>().SetPowerTime(true);
      Destroy(gameObject);
    }
  }
}