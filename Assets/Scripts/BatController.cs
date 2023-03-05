using UnityEngine;

public class BatController : MonoBehaviour {   
  [HideInInspector] public Animator anim;
  public Transform pontA;
  public Transform pontB;
  public Rigidbody2D rb2d;
  public bool viradoDireita = false;
  public float Speed = 3;
  Vector3 nextPont;
  
  private float life = 100;

  void Start() {
    anim = GetComponent<Animator>();
    rb2d = GetComponent<Rigidbody2D>();
    nextPont.x = pontA.position.x;
    nextPont.y = pontA.position.y; 
  }

  void Update() {
    movimento();
  }

  public void movimento() { 
    if (transform.position.x == pontA.position.x) {
      nextPont.x = pontB.position.x;           
      Flip();
    }

    if (transform.position.x == pontB.position.x) {
      nextPont.x = pontA.position.x;
      Flip();        
    }

    transform.position = Vector2.MoveTowards(transform.position, new Vector3(nextPont.x, transform.position.y),  Speed* Time.deltaTime);
  }

  public void Flip() {
    viradoDireita = !viradoDireita;

    Vector2 escala = transform.localScale;
    escala.x *= -1;
    transform.localScale = escala;
  }
   
  void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.CompareTag("Player")) {
      other.gameObject.GetComponent<PlayerController>().DanoPlayer(25);
    }
  }

  public void SetEnemyLife(float vida) {
    life = life - vida;
    if (life == 0) {  
      rb2d.isKinematic = false;
      Destroy(gameObject, 1);
    }
  }
}