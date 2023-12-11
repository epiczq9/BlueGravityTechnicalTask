using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Item")]
public class Item : ScriptableObject
{
    public enum ItemType {
        hat, shirt
    }

    public string itemName;
    public string description;
    public ItemType itemType;
    public int price;
    public bool isOwned = false;
    public bool isEquipped = false;
    public Sprite icon;


}
