using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvaController : CanvaController2
{
  //Elementos do Canva
  public Text cristalText;
  public Text timeText;
  
  //Variaveis auxiliares 
  int cristais = 0;
  bool powerTime = false;
  
  void Start() {
    if (getNivelAtual() == 1) {
      Timer = 240f;
    } else if(getNivelAtual() == 2) {
      Timer = 300f;
    } 
  }
  
  void Update() {
    controleTempo();
    controleCristais();
    controleEnergia();
    controleSaveGame();
    controleVida2();
  }
  
  void controleCristais() {
    cristais = player.GetComponent<CollectObjects>().GetCristal();
    cristalText.text = "x " + cristais.ToString();
  }
  
  void controleTempo() {
    if (chave == false) {
      Timer -= Time.deltaTime;

      if (powerTime == true) {
        Timer += 10f;
        powerTime = false;
      }

      minutos = (int)(Timer / 60);
      segundos = (Timer % 60);

      minutosI = minutos;
      segundosI = segundos;

      timeText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
      if (Timer <= 0) {
        gameOver();
      }
    }
  }
  
  public void SetPowerTime(bool time) {
    powerTime = time;
  }
}