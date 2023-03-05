using UnityEngine;

public class Tiro : MonoBehaviour {
  //Codigo que movimenta o tiro
  private float Speed = 100;
  private GameObject player;
  private bool flip;
  [HideInInspector] public Animator anim;
  
  void Start() {
    Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    player = GameObject.Find("Evelyn");
    flip = player.GetComponent<PlayerController>().viradoDireita;
 
    if (flip == false) {       
      rb2d.AddForce(new Vector2(-Speed * Time.deltaTime, 0) , ForceMode2D.Impulse);
    } else {
      rb2d.AddForce(new Vector2(Speed * Time.deltaTime, 0) , ForceMode2D.Impulse);
    }
    Destroy(gameObject, 3);
  } 
  
  public void spell() {
    SoundController.PlaySound("spellCollider");
    anim.SetTrigger("Spell");
  } 
}