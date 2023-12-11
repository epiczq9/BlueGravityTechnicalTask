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


    public void SelectedBuyOption() {
        print("BUY");
        //Here I'm disabling only the first menu, while the shopping canvas and the shoppingUIActive from ActivateShop script still remain active and true
        firstShopMenu.SetActive(false);
        buyMenu.SetActive(true);
    }

    public void SelectedSellOption() {
        print("SELL");
        //Here I'm disabling only the first menu, while the shopping canvas and the shoppingUIActive from ActivateShop script still remain active and true
        firstShopMenu.SetActive(false);
        sellMenu.SetActive(true);
    }

    public void SelectedChangeOption() {
        print("CHANGE");
        firstShopMenu.SetActive(false);
        changeMenu.SetActive(true);
    }

    public void ExitMenu() {
        //But here I am disabling the whole UI Shop Canvas, activating the player once more
        activateShopMenu.UpdateShoppingUI();
    }
}
