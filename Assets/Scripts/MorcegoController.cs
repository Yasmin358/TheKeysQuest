using UnityEngine;

public class MorcegoController : BatController {
  private Transform player;
  int layerMask;
  int status = 0;
  float laserLength = 5;
  RaycastHit2D hit;
  float minDist = 5;

  void Awake() { 
    layerMask = LayerMask.GetMask("Player");   
    pontA = GameObject.FindWithTag("PointA").transform;
    pontB = GameObject.FindWithTag("PointB").transform;   
  }

  void Update() {
    player = GameObject.FindWithTag("Player").transform;

    if (viradoDireita == true) {
      hit = Physics2D.Raycast(transform.position, Vector2.right, laserLength, layerMask, 0);
      Debug.DrawRay(transform.position, Vector2.right * laserLength, Color.blue);

      if (hit.collider != null) {
        status = 1;
      }
    } else {
      RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.right, laserLength, layerMask, 0);
      Debug.DrawRay(transform.position, -Vector2.right * laserLength, Color.blue);
      if (hit.collider != null) {
        status = 1;
      }
    }

    if (status == 0) {
      movimento();
    } else if (status == 1){
      perseguir();
    } else if(status == 2) {
      if(viradoDireita == true) {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(pontB.transform.position.x, pontB.transform.position.y),  Speed* Time.deltaTime);            
        if (transform.position.x == pontB.transform.position.x) {
        status = 0; 
        } 
      } else if(viradoDireita == false) {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(pontA.transform.position.x, pontA.transform.position.y),  Speed* Time.deltaTime);            
        if (transform.position.x == pontA.transform.position.x) {
        status = 0; 
        }
      }
    }
  }

  void perseguir() {
    if (transform.position.x > player.transform.position.x && viradoDireita == true) {
      Flip();
    } else if (transform.position.x < player.transform.position.x && viradoDireita == false) {
      Flip();
    }
    
    transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, player.transform.position.y),  Speed* Time.deltaTime);            

    if (Vector2.Distance(transform.position, player.position) > minDist) {   
      status = 2;
    }
  }
}