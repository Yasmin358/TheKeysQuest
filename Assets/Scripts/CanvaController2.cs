using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvaController2 : MonoBehaviour
{
  //Elementos do Canva
  public Text vidaText;
  public GameObject player;
  public Image Heart;
  public Image Heart2;
  public Image Heart3;

  //Variaveis auxiliares 
  int vida = 0;
  float energia = 0;
  public bool chave = false;

  Scene scene;
  private int nivelAtual;
  private int vidaAtual;
  public GameObject position; 
  public GameObject ChaveRed;
  bool vitoria = false;

  //Contador de tempo
  public float Timer;
  public float minutos;
  public float segundos;
  public float minutosI;
  public float segundosI; 

  void Awake() {
    if (Time.timeScale == 0f) {
      Time.timeScale = 1f;
    }
    player = GameObject.FindWithTag("Player");
    vida = PlayerPrefs.GetInt("Vida");
    player.GetComponent<PlayerController>().SetAtualizaVida(vida);
    controleVida();
    controleCena();  
  }

  void FixedUpdate() {
    controleEnergia();
    controleSaveGame();
    controleVida2();

    if(vitoria == true) {
      ControleVitória();    
    }
  }

  public void controleVida() {
    vida = PlayerPrefs.GetInt("Vida");
    if (vida == 0) {
      vida = 3;
      player.GetComponent<PlayerController>().SetPowerVida(3);
    } else {
      player.GetComponent<PlayerController>().SetAtualizaVida(vida);
    }
    vidaText.text = "x " + vida.ToString();
  }

  public void controleVida2() {
    vida = player.GetComponent<PlayerController>().GetVidaAtual();
    vidaText.text = "x " + vida.ToString();
  }


  public void controleEnergia() {
    energia = player.GetComponent<PlayerController>().GetEnergia();
    if (energia == 100) {
      Heart.enabled = true;
      Heart2.enabled = true;
      Heart3.enabled = true;
    }

    if (energia == 75) {
      Heart.enabled = false;
    }

    if (energia == 50) {
      Heart2.enabled = false;
    }

    if (energia == 25) {
      Heart3.enabled = false;
    }

    if (energia == 0) {
      player.GetComponent<PlayerController>().SetVidaAtual(1);
      vidaAtual = player.GetComponent<PlayerController>().GetVidaAtual();
      if (vidaAtual != 0) {
        PlayerPrefs.SetInt("Vida", vidaAtual);
        PlayerPrefs.Save();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name); 
      } else {
        gameOver();
      }
    }
  }

  public void controleCena() {
    scene = SceneManager.GetActiveScene();

    if (scene.name == "Fase1") {
      nivelAtual = 1;
    } else if (scene.name == "Fase2") {
      nivelAtual = 2;
    } else {
      nivelAtual = 3;
      vitoria = true;
    }
  }

  public void controleSaveGame()
  {
    chave = player.GetComponent<CollectObjects>().GetChave();
    vidaAtual = player.GetComponent<PlayerController>().GetVidaAtual();

    if (chave == true) {
      if (getNivelAtual() == 1 || getNivelAtual() == 2) {
        PlayerPrefs.SetInt("FaseAtual", nivelAtual);
        minutos = minutosI - minutos;
        segundos = segundosI - segundos;
        PlayerPrefs.SetFloat("Minutos", minutos);
        PlayerPrefs.SetFloat("Segundos", segundosI - segundos);
        PlayerPrefs.SetInt("StatusNivel", 2);
        PlayerPrefs.SetInt("Vida", vidaAtual);
        PlayerPrefs.Save(); 
      } else if(getNivelAtual() == 3) {
        PlayerPrefs.SetInt("FaseAtual", nivelAtual);
        PlayerPrefs.SetInt("StatusNivel", 3);
        PlayerPrefs.DeleteKey("Vida");
        PlayerPrefs.Save(); 
      }    
      SceneManager.LoadScene(4);
    }
  }

  public void gameOver() {
    PlayerPrefs.DeleteKey("Vida");
    PlayerPrefs.SetInt("StatusNivel", 1);
    PlayerPrefs.Save();
    SceneManager.LoadScene(4);
  }

  public int getNivelAtual() {
    return nivelAtual;
  }

  public void ControleVitória() {
    int enemy = GameObject.FindGameObjectsWithTag("Feiticeira").Length;

    if (enemy == 0) {
      Instantiate(ChaveRed, new Vector2(position.transform.position.x, position.transform.position.y), Quaternion.identity);
      vitoria = false;
    }
  }
}