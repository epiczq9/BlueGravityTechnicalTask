using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchUIWindows : MonoBehaviour {

    public GameObject canvasToHide;
    public GameObject canvasToShow;


    public void SwitchWindows() {
        canvasToHide.SetActive(false);
        canvasToShow.SetActive(true);
    }
}
