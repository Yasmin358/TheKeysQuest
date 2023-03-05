using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Codigo que controla o Painel da Cena Terminou
public class PainelController : MonoBehaviour {     
  public GameObject painelNivelFinalizado;
  public GameObject painelGameOver;
  public GameObject painelVitoria;
  
  public Image Key;
  public Image Key2;
  public Image Key3;
  public Text timeText;
  
  public float minutos;
  public float segundos;
  int nivelFinalizado;
  int statusNivel;
  
  private void Start() {
    statusNivel = PlayerPrefs.GetInt("StatusNivel");
  
    if (statusNivel == 2) {
      minutos = PlayerPrefs.GetFloat("Minutos");
      segundos = PlayerPrefs.GetFloat("Segundos");
      timeText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
      nivelFinalizado = PlayerPrefs.GetInt("FaseAtual");

      if(nivelFinalizado == 1) {
        Key.color = new Color(1,1,1,1);
        Key2.color = new Color(1,1,1, 0.5f);
        Key3.color = new Color(1,1,1, 0.5f);
      } else if (nivelFinalizado == 2) {
        Key.color = new Color(1,1,1,1);
        Key2.color = new Color(1,1,1,1);
        Key3.color = new Color(1,1,1, 0.5f);
      }
    
    painelNivelFinalizado.SetActive(true);
    
    } else if (statusNivel == 1) {
      painelGameOver.SetActive(true);
       
    } else if (statusNivel == 3) {
      painelVitoria.SetActive(true);
    }  
  }
  
  public void CarregarProximaCena() {
    SceneManager.LoadScene(nivelFinalizado + 1);      
  }
  
  void Update() {
    if (statusNivel == 2) {
      SoundController.PlaySound("completeLevel");  
      statusNivel = 0;
    } else if (statusNivel == 1) {
      SoundController.PlaySound("gameOver"); 
      statusNivel = 0;
    } else if (statusNivel == 3) {
      SoundController.PlaySound("Win");
      statusNivel = 0;
    } 
  }
}