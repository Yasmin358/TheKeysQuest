using UnityEngine;

public class tiroFireBall : MonoBehaviour {
  //Codigo que movimenta o tiro
  private float Speed = 100;
  private GameObject enemy;
  private bool flip;
  [HideInInspector] public Animator anim;
  
  void Start() {
    Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    enemy = GameObject.Find("Feiticeira");
    flip = enemy.GetComponent<EnemyController>().viradoDireita;

    if (flip == false) {     
      rb2d.AddForce(new Vector2(-Speed * Time.deltaTime, 0) , ForceMode2D.Impulse);
    } else {
      Flip(); 
      rb2d.AddForce(new Vector2(Speed * Time.deltaTime, 0) , ForceMode2D.Impulse);
    }
    Destroy(gameObject, 3);
  } 
  
  public void spell() {
    SoundController.PlaySound("spellCollider");
  }
  
  private void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.CompareTag("Player")) {
      spell();
      other.gameObject.GetComponent<PlayerController>().DanoPlayer(25);
      Destroy(gameObject);
    }
    if (other.gameObject.CompareTag("Tiro")) {
      spell();
      Destroy(gameObject);
    }
  }
  
  void Flip() {
    Vector3 escala = transform.localScale;
    escala.x *= -1;
    transform.localScale = escala;
  }
}