using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShoppingManager : MonoBehaviour
{
    public List<Item> listOfItemsInShop = new();
    public List<Item> listOfItemsOwned = new();

    public List<GameObject> listOfItemsInShopButtons = new();
    public List<GameObject> listOfItemsOwnedButtons = new();

    public float playerMoney = 1000;
    public TMP_Text playerMoneyUI;

    void Start() {
        UpdateShop();
    }

    void Update() {
        
    }

    void UpdateShop() {
        playerMoneyUI.text = playerMoney.ToString();

        foreach (GameObject itemButton in listOfItemsInShopButtons) {
            if (itemButton.GetComponent<ItemInShopButtons>().itemData.isOwned) {
                itemButton.SetActive(false);
            } else {
                itemButton.SetActive(true);
            }
        }

        foreach (GameObject itemButton in listOfItemsOwnedButtons) {
            if (itemButton.GetComponent<ItemInShopButtons>().itemData.isOwned) {
                itemButton.SetActive(true);
            } else {
                itemButton.SetActive(false);
            }
        }

    }

    public void BuyItem(Item itemData) {
        print("You've bought " + itemData.itemName);
        playerMoney -= itemData.price;
        itemData.isOwned = true;
        /*listOfItemsInShop.Remove(itemData);
        listOfItemsOwned.Add(itemData);*/
        UpdateShop();
    }

    public void SellItem(Item itemData) {
        print("You've sold " + itemData.itemName);
        playerMoney += itemData.price;
        itemData.isOwned = false;
        /*listOfItemsOwned.Remove(itemData);
        listOfItemsInShop.Add(itemData);*/
        UpdateShop();
    }
}
