using UnityEngine;

public class CacadorController : MonoBehaviour {
  public float laserLength;
  private bool moving = true;
  public GameObject arrow;
  public Transform flecha;
  float timer = 0;
  float waitTimer = 2;
  float waitTimerArrow = 0.5f;
  bool attackAtive = false;

  [HideInInspector] public Animator anim;
  public Transform pontA;
  public Transform pontB;
  [HideInInspector] public bool viradoDireita = true;
  Vector3 nextPont;
  float Speed = 3;
  public Rigidbody2D rb2d;
  private float life = 100;

  void Start() {
    anim = GetComponent<Animator>();
    rb2d = GetComponent<Rigidbody2D>();
    nextPont.x = pontA.position.x;
  }
  
  void Update() {
    if (moving == true) {
      movimento();
      anim.SetTrigger("run");
    }
  }

  private void FixedUpdate() {
    //Visão do inimigo - Se o inimigo "vê" o jogador, ele para de correr e começa a atirar
    Vector2 startPosition = (Vector2)transform.position + new Vector2(0.5f, 0.2f);
    int layerMask = LayerMask.GetMask("Player");

    if (viradoDireita == true) {
      RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right, laserLength, layerMask, 0);
      //Debug.DrawRay(transform.position, -Vector2.right * laserLength, Color.red);
      if (hit.collider != null) {
        cacadorAtaque();
      } else {
        moving = true;
      }
    } else {
      RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, laserLength, layerMask, 0);
      //Debug.DrawRay(transform.position, Vector2.right * laserLength, Color.red);
      if (hit.collider != null) {
        cacadorAtaque();
      } else {
        moving = true;
      }
    }
  }

  void cacadorAtaque() {
    moving = false;
    timer += Time.deltaTime;

    if (timer > waitTimer) {
      timer = timer - waitTimer;
      anim.SetTrigger("attack");
      attackAtive = true;
    } else {
      anim.SetTrigger("indle");
    }

    if (timer > waitTimerArrow && attackAtive == true) {
      timer = timer - waitTimerArrow;
      Instantiate(arrow, new Vector2(flecha.transform.position.x, flecha.transform.position.y), Quaternion.identity);
      attackAtive = false;
    }
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

    transform.position = Vector3.MoveTowards(transform.position, new Vector3(nextPont.x, transform.position.y, transform.position.z),  Speed* Time.deltaTime);
  }

  void Flip() {
    viradoDireita = !viradoDireita;
    Vector3 escala = transform.localScale;
    escala.x *= -1;
    transform.localScale = escala;
  }

  public void SetEnemyLife(float vida) {
    life = life - vida;
    if (life == 0) {
      Destroy(gameObject, 1);
    }
  }
}