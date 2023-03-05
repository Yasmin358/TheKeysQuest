using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {
  public void bottomJogar() {
    SceneManager.LoadScene(1);
  }

  public void bottomMenu() {
    if (PlayerPrefs.GetInt("Vida") != 0) {
      PlayerPrefs.DeleteKey("Vida");   
    }        
    SceneManager.LoadScene(0);
  }

  public void bottomExit() {
    Application.Quit();       
  }
}