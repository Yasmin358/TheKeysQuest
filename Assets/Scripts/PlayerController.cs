using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
  private Animator anim;
  private Rigidbody2D rb2d;

  //Movimento
  public Transform posPe;
  public float Velocidade = 0.3f;
  public float ForcaPulo = 45f;
  [HideInInspector] public bool tocaChao;
  [HideInInspector] public bool tocaEspinho;
  public bool viradoDireita = true;

  //Vida
  private bool powerUpImune = false; 
  private int vidaAtual = 0;
  private float energia = 100;
  float timerI = 0;
  float timerP = 0;

  //Ataque
  private bool powerUpPower = false;
  public GameObject tiroRoxo;
  public GameObject tiroAzul;
  public GameObject tiroPosition;

  void Start() {
      anim = GetComponent<Animator>();
      rb2d = GetComponent<Rigidbody2D>();  
  }

  void Update() {
    //O gameObject posPe pega a posição atual do pé do Player. 
    //TocaChao verefica se o Player está tocando no Chao
    tocaChao = Physics2D.Linecast(transform.position, posPe.position, 1 << LayerMask.NameToLayer("Chao"));
    tocaEspinho = Physics2D.Linecast(transform.position, posPe.position, 1 << LayerMask.NameToLayer("Spike"));
    
    pulo(tocaChao, tocaEspinho);
    PlayerAttack();

    //Cronometro do PowerUpImune
    if(powerUpImune == true){           
      timerI += Time.deltaTime;
      PlayerImune();
    }

    //Cronometro do PowerUpPower
    if(powerUpPower == true){
      timerP += Time.deltaTime;
      TimerAttack();
    }
  }

  void FixedUpdate() {
    movimento(tocaChao);   
  }

  void pulo(bool tocaChao, bool tocaEspinho) {
    //O Jogador só pode pular se estiver tocando o chão
    if (Input.GetKeyDown(KeyCode.Space) && tocaChao) {    
      SoundController.PlaySound("jumpSound");
      rb2d.AddForce(new Vector2(0f, ForcaPulo),ForceMode2D.Impulse);
      anim.SetTrigger("Jump");
    }

    if (tocaEspinho) {
      rb2d.AddForce(new Vector2(0f, 15f),ForceMode2D.Impulse);
      anim.SetTrigger("Jump");
    }
  }

  void movimento(bool tocaChao){
    //O Jogador só pode se mover na horizontal se estiver tocando o chão
    float translationX = Input.GetAxis("Horizontal");
    rb2d.velocity = new Vector2(Velocidade * translationX , rb2d.velocity.y);
    
    if (translationX != 0 && tocaChao) {
      anim.SetTrigger("Walk");
    } else {
      anim.SetTrigger("Indle");
    }

    if (translationX > 0 && !viradoDireita) {
      Flip();
    } else if (translationX < 0 && viradoDireita) {
      Flip();
    }
  }

  void Flip() {
    viradoDireita = !viradoDireita;

    Vector3 escala = transform.localScale;
    escala.x *= -1;
    transform.localScale = escala;
  }

  public void SetPowerVida(int life) {
    vidaAtual = vidaAtual + life;
  }

  public void SetAtualizaVida(int vida) {
    vidaAtual = vida;
  }

  public void SetEnergia(int energy) {
    energia = energy;
  }

  //Metodo de Dano é chamado ao colidir com armadilhas e inimigos  
  //A fase reinicia sempre que o jogador perde uma vida
  public void DanoPlayer(float dano) { 
    if (powerUpImune == false) {
      anim.SetTrigger("Damage");
      SoundController.PlaySound("playerHit");             
      energia = energia - dano;
    }
  }

  public void PlayerImune() {
    //A poção Imune fica ativa por 15 segundos
    if (timerI <= 15.00) {
      gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1, 0.5f);
    } else {
      gameObject.GetComponent<SpriteRenderer>().color = new Color(1,1,1,1);
      powerUpImune = false;
    }
  }

  public void SetImune(bool imune) {
    powerUpImune = imune;
  }

  public void SetPower(bool power) {
    powerUpPower = power;
  }

  public void TimerAttack() {
    //A poção Power fica ativa por 20 segundos
    if (timerP >= 20.00) {
      powerUpPower = false;
    }
  }

  public void PlayerAttack() {
    //Jogador possui dois Ataques, Simples(Azul) e Duplo(Roxo)
    //Para ativar o ataque Duplo é preciso coletar a poção Roxa(PowerUpPower)
    if (Input.GetKeyDown("x") && powerUpPower == false) {
      SoundController.PlaySound("spellSound"); 
      anim.SetTrigger("Attack");
      Instantiate(tiroAzul, new Vector3(tiroPosition.transform.position.x, tiroPosition.transform.position.y, tiroPosition.transform.position.z), Quaternion.identity);
    } else if (Input.GetKeyDown("x") && powerUpPower == true) {
      SoundController.PlaySound("spellSound");
      anim.SetTrigger("Attack");
      Instantiate(tiroRoxo, new Vector3(tiroPosition.transform.position.x, tiroPosition.transform.position.y, tiroPosition.transform.position.z), Quaternion.identity);
    }
  }

  public int GetVidaAtual() {
    return vidaAtual;
  }

  public void SetVidaAtual(int life) {
    if (vidaAtual > 0) {
      vidaAtual = vidaAtual - life; 
    } else if(vidaAtual == 0) {
      print("Game Over!");
    }
  }

  public float GetEnergia() {
    return energia;
  }
}