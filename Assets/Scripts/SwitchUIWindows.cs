using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchUIWindows : MonoBehaviour {

    public GameObject canvasToHide;
    public GameObject canvasToShow;
    public AudioManager audioManager;

    private void Start() {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }


    public void SwitchWindows() {
        audioManager.PlayBackSFX();
        canvasToHide.SetActive(false);
        canvasToShow.SetActive(true);
    }
}
