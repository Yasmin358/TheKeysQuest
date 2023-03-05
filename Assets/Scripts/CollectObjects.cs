using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectObjects : MonoBehaviour {
    //Coleta de Cristais
    //Fase 1 - 30 cristais verdes.
    //Fase 2 - 50 cristais azuis.

  private int cristais;
  public GameObject ChaveVerde;
  public GameObject ChaveAzul;
  public Transform ChavePosicao;
  private GameObject canvas;
  int faseAtual;
  private bool chaveColetada = false;

  private void Start() {
    canvas = GameObject.Find("Canvas");
    faseAtual = canvas.GetComponent<CanvaController2>().getNivelAtual();
    if (faseAtual == 1) {
      cristais = 30;
    } else if (faseAtual == 2) {
      cristais = 50;
    }
  }
  //Ao coletar o numero X de cristais em cada fase uma chave da mesma cor é instanciada em algum lugar da fase
  private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.CompareTag("Cristal")) {
      SoundController.PlaySound("collectSound");
      cristais--;
      Destroy(other.gameObject);
      if (cristais == 0 && faseAtual == 1) {
        Instantiate(ChaveVerde, ChavePosicao.position, Quaternion.identity);
      } else if (cristais == 0 && faseAtual == 2) {
        Instantiate(ChaveAzul, new Vector2(ChavePosicao.position.x, ChavePosicao.position.y), Quaternion.identity);
      }
    }
  }

  public int GetCristal() {
    return cristais;
  }

  public void SetChave(bool chave) {
    chaveColetada = chave;
  }

  public bool GetChave() {
    return chaveColetada;
  }
}