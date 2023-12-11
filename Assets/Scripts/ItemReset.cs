using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReset : MonoBehaviour
{
    public Item[] itemSO;
    private void OnApplicationQuit() {
        foreach(Item item in itemSO) {
            item.isEquipped = false;
            item.isOwned = false;
        }
    }
}
