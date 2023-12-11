using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMenu : MonoBehaviour
{
    public GameObject firstShopMenu;
    public GameObject buyMenu;
    public GameObject sellMenu;
    public GameObject changeMenu;

    public ActivateShop activateShopMenu;
    public AudioManager audioManager;

    private void Start() {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }


    public void SelectedBuyOption() {
        print("BUY");
        audioManager.PlaySelectSFX();
        //Here I'm disabling only the first menu, while the shopping canvas and the shoppingUIActive from ActivateShop script still remain active and true
        firstShopMenu.SetActive(false);
        buyMenu.SetActive(true);
    }

    public void SelectedSellOption() {
        print("SELL");
        audioManager.PlaySelectSFX();
        //Here I'm disabling only the first menu, while the shopping canvas and the shoppingUIActive from ActivateShop script still remain active and true
        firstShopMenu.SetActive(false);
        sellMenu.SetActive(true);
    }

    public void SelectedChangeOption() {
        print("CHANGE");
        audioManager.PlaySelectSFX();
        firstShopMenu.SetActive(false);
        changeMenu.SetActive(true);
    }

    public void ExitMenu() {
        //But here I am disabling the whole UI Shop Canvas, activating the player once more
        audioManager.PlayBackSFX();
        activateShopMenu.UpdateShoppingUI();
    }
}
