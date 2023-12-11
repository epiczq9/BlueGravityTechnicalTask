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
    void Start() {
        SetupItemInShopButtons();
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
        shoppingManager.BuyItem(itemData);
        inventoryManager.UpdateInventory();
    }

    public void SellItem() {
        if (itemData.isEquipped) {
            print("Cant sell");
        } else {
            isOwned = false;
            gameObject.SetActive(false);
            shoppingManager.SellItem(itemData);
            inventoryManager.UpdateInventory();
        }
        
    }
}
