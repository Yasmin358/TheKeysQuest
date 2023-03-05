using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Armadilha : MonoBehaviour {
  public GameObject player;

  void Start() {
    player = GameObject.FindWithTag("Player");
  }

  public void Dano(int dano) {
    player.GetComponent<PlayerController>().DanoPlayer(dano);
  }
}