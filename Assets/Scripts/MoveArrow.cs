using UnityEngine;

public class moveArrow : MonoBehaviour {
  private Rigidbody2D rb2d;
  float Speed = 50.0f;
  private GameObject player;
  private bool flip;

  private void Start() {
    rb2d = GetComponent<Rigidbody2D>();
    player = GameObject.Find("Evelyn");
    flip = player.GetComponent<PlayerController>().viradoDireita;

    if (flip == false) { 
      Flip();      
      rb2d.AddForce(new Vector2(5, 0)* Speed);
    } else {
      rb2d.AddForce(new Vector2(-5, 0)* Speed);
    }

    Destroy(gameObject, 3);
  }

  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.CompareTag("Player")) {           
      other.gameObject.GetComponent<PlayerController>().DanoPlayer(25);           
      Destroy(gameObject);             
    }
  }

  public void Flip() {
    Vector2 escala = transform.localScale;
    escala.x *= -1;
    transform.localScale = escala;
  }
}