using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInShop : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text itemDescription;
    public TMP_Text price;
    public bool isOwned;
    public Image icon;

    public Item itemData;
    void Start() {
        SetupItemInShop();
    }

    void Update() {
        
    }

    public void SetupItemInShop() {
        itemName.text = itemData.itemName.ToString();

        itemDescription.text = itemData.description.ToString();

        price.text = itemData.price.ToString();

        icon.sprite = itemData.icon;
    }
}
