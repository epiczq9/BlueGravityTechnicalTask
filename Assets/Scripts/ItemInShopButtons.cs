using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInShopButtons : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text itemDescription;
    public TMP_Text itemType;
    public TMP_Text price;
    public bool isOwned;
    public Image icon;

    public Item itemData;
    public ShoppingManager shoppingManager;
    public InventoryManager inventoryManager;
    public AudioManager audioManager;
    public Animator popUpAnimator;

    void Start() {
        SetupItemInShopButtons();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    public void SetupItemInShopButtons() {
        itemName.text = itemData.itemName;

        itemDescription.text = itemData.description;

        itemType.text = itemData.itemType.ToString();

        price.text = itemData.price.ToString();

        icon.sprite = itemData.icon;
    }

    public void BuyItem() {
        //print("You've bought " + itemName.text);
        isOwned = true;
        gameObject.SetActive(false);
        audioManager.PlaySelectSFX();
        shoppingManager.BuyItem(itemData);  //With this we call a function in the ShoppingManager script which does broader thing than this function for the button
        inventoryManager.UpdateInventory();
    }

    public void SellItem() {
        if (itemData.isEquipped) {
            print("Cant sell, have to unequip");
            audioManager.PlayErrorSFX();
            popUpAnimator.Play("PopUp");
        } else {
            isOwned = false;
            gameObject.SetActive(false);
            audioManager.PlaySelectSFX();
            shoppingManager.SellItem(itemData); //With this we call a function in the ShoppingManager script which does broader thing than this function for the button
            inventoryManager.UpdateInventory();
        }
        
    }
}
