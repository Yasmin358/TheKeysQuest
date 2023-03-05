using UnityEngine;
//Codigo para o Movimento da Camera
public class CameraController : MonoBehaviour {
  private Transform cam;
  public Transform player;
  //Limites da Camera 
  public Transform LimiteLeft;
  public Transform LimiteRight;
  public Transform LimiteTop;
  public Transform LimiteBottom;
  
  float cameraSpeed = 3f;

  void Start() {
    cam = Camera.main.transform;    
  }

  private void FixedUpdate() {
    float camX = player.position.x;
    float camY = player.position.y;
    
    if (cam.position.x < LimiteLeft.position.x && player.position.x < LimiteLeft.position.x) {
      camX = LimiteLeft.position.x;
    } else if (cam.position.x > LimiteRight.position.x && player.position.x > LimiteRight.position.x) {
      camX = LimiteRight.position.x;
    }

    if (cam.position.y < LimiteBottom.position.y && player.position.y < LimiteBottom.position.y) {
      camY = LimiteBottom.position.y;
    } else if (cam.position.y > LimiteTop.position.y && player.position.y > LimiteTop.position.y) {
      camY = LimiteTop.position.y;
    }

    cam.position = Vector3.Lerp(cam.position, new Vector3(camX, camY, -10), cameraSpeed * Time.fixedDeltaTime);
  }
}