using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpAnimation : MonoBehaviour
{
    Renderer rend1;
    Renderer rend2;

    private void Start() {
        rend1 = transform.GetChild(0).GetComponent<Renderer>();
        rend2 = transform.GetChild(1).GetComponent<Renderer>();
    }

    public void TurnOffRenderer() {
        rend2.enabled = false;
    }
    public void TurnOnRenderer() {
        rend1.enabled = true;
        rend2.enabled = true;
    }
}
