using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    //public List<GameObject> listOfItemsOwned = new();
    public List<GameObject> listOfItemsOwnedButtons = new();


    void Start() {
        UpdateInventory();
    }

    void Update() {

    }

    public void UpdateInventory() {
        foreach (GameObject itemButton in listOfItemsOwnedButtons) {
            if (itemButton.GetComponent<ItemInInventory>().itemData.isOwned) {
                itemButton.SetActive(true);
            } else {
                itemButton.SetActive(false);
            }
        }
    }

    public void ResetIsEquipped() {
        foreach(GameObject itemInInv in listOfItemsOwnedButtons) {
            itemInInv.GetComponent<ItemInInventory>().isEquipped = false;
        }
    }
}
