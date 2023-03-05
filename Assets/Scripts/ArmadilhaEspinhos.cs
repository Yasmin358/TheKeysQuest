using UnityEngine;

public class ArmadilhaEspinhos : Armadilha {
  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.CompareTag("Player")) {
      Dano(25);
    }
  }
}