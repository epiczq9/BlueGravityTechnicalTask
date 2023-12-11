using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSourceSFX;
    public AudioClip clickSFX;
    public AudioClip selectButtonSFX;
    public AudioClip errorSFX;
    public AudioClip backSFX;
    public AudioClip equipSFX;
    public AudioClip unequipSFX;

    public void PlayClickSFX() {
        audioSourceSFX.PlayOneShot(clickSFX);
    }

    public void PlaySelectSFX() {
        audioSourceSFX.PlayOneShot(selectButtonSFX);
    }

    public void PlayErrorSFX() {
        audioSourceSFX.PlayOneShot(errorSFX);
    }

    public void PlayBackSFX() {
        audioSourceSFX.PlayOneShot(backSFX);
    }

    public void PlayEquipSFX() {
        audioSourceSFX.PlayOneShot(equipSFX);
    }

    public void PlayUnequipSFX() {
        audioSourceSFX.PlayOneShot(unequipSFX);
    }
}
