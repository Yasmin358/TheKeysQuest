using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {
  public static AudioClip playerhit, spellSound, jumpSound, collectSound, spellColliderSound, powerUpSound, completeLevelSound, gameOverSound, bottomSound, victorieSound, bossSound;
  static AudioSource audioSrc;

  void Start() {
    playerhit = Resources.Load<AudioClip>("playerHit");
    spellSound = Resources.Load<AudioClip>("spell");
    jumpSound = Resources.Load<AudioClip>("jump");
    collectSound = Resources.Load<AudioClip>("collectCristal");
    spellColliderSound = Resources.Load<AudioClip>("spellCollider");
    powerUpSound = Resources.Load<AudioClip>("powerUp");
    completeLevelSound = Resources.Load<AudioClip>("completeLevel");
    gameOverSound = Resources.Load<AudioClip>("gameOver");
    victorieSound = Resources.Load<AudioClip>("Win");
    bossSound = Resources.Load<AudioClip>("boss");
    audioSrc = GetComponent<AudioSource>();
  }

  void Update() {
      
  }

  public static void PlaySound (string clip) {
    switch(clip) {
      case "spellSound" :
        audioSrc.PlayOneShot (spellSound);
      break;

      case "playerHit" :
        audioSrc.PlayOneShot (playerhit);
      break;

      case "jumpSound" :
        audioSrc.PlayOneShot (jumpSound);
      break;

      case "collectSound" :
        audioSrc.PlayOneShot (collectSound);
      break;

      case "powerUp":
        audioSrc.PlayOneShot (powerUpSound);
      break;

      case "spellCollider":
        audioSrc.PlayOneShot (spellColliderSound);
      break;

      case "completeLevel":
        audioSrc.PlayOneShot (completeLevelSound);
      break;

      case "gameOver":
        audioSrc.PlayOneShot (gameOverSound);
      break;

      case "Win":
        audioSrc.PlayOneShot (victorieSound);
      break;

      case "Boss":
        audioSrc.PlayOneShot (bossSound);
      break;
    }
  }
}
