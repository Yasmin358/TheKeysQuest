using UnityEngine;

public class EnemyController : MonoBehaviour {
    
  [HideInInspector] public Animator anim;
  private Transform player;
  public bool viradoDireita = false;
  public float Speed = 3;
  public Rigidbody2D rb2d;
  private float life = 100;
  float minDist = 8;
  int state = 0;
  float timer = 0;
  float waitTimerBall = 1f;
  bool attackAtive = false;
      
  public GameObject MyAudioSource;
  public GameObject tiroPosition;
  public GameObject FireBall;

  void Start() {
    anim = GetComponent<Animator>();
    rb2d = GetComponent<Rigidbody2D>();
  }

  void Update() {
    player = GameObject.FindWithTag("Player").transform;
    
    if (state == 0) {
        anim.SetTrigger("Walk");
        perseguir();
           
    } else if (state == 1) {
        attackAtive = true;
        attack();
    }
             
    if (Vector2.Distance(transform.position, player.position) >= minDist) {   
        state = 0;
    } else if (Vector2.Distance(transform.position, player.position) <= minDist) {
        state = 1;
    }
    
    if (attackAtive == true) {
    timer += Time.deltaTime;
    }
  }
      
  void perseguir() {
    Flip2();
    transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, player.transform.position.y),  Speed* Time.deltaTime);                   
  }

  void pular() {
    rb2d.AddForce(new Vector2(0f, 30f),ForceMode2D.Impulse);
    anim.SetTrigger("Jump");
  }

  public void Flip2() {
    if (transform.position.x > player.transform.position.x && viradoDireita == true) {
      Flip();
    } else if (transform.position.x < player.transform.position.x && viradoDireita == false) {
      Flip();
    }            
  }  
    
  public void Flip() {
    viradoDireita = !viradoDireita;
    Vector2 escala = transform.localScale;
    escala.x *= -1;
    transform.localScale = escala;
  }

  public void SetEnemyLife(float vida) {
    anim.SetTrigger("Damage");
    life = life - vida;
    if (life == 0) {  
      MyAudioSource.GetComponent<AudioSource>().enabled = false; 
      SoundController.PlaySound("Boss");
      anim.SetTrigger("Died");
      Destroy(gameObject,2);              
    }
  }

  void attack() {
    Flip2();
      if (timer > waitTimerBall && attackAtive == true) {
        timer = timer - waitTimerBall;
        SoundController.PlaySound("spellSound");
        anim.SetTrigger("Attack");
        Instantiate(FireBall, new Vector3(tiroPosition.transform.position.x, tiroPosition.transform.position.y, tiroPosition.transform.position.z), Quaternion.identity);   
        attackAtive = false;  
      }
    }

  void OnCollisionEnter2D(Collision2D other) {
    if (other.gameObject.CompareTag("Player")) {
      other.gameObject.GetComponent<PlayerController>().DanoPlayer(25);
    }
  }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Tiro")) {
      pular();
    }
  }
}