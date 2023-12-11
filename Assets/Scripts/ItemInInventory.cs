using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemInInventory : MonoBehaviour
{
    public TMP_Text itemName;
    public TMP_Text itemType;
    public Image icon;
    public bool isOwned;
    public bool isEquipped;

    public Item itemData;
    public ShoppingManager shoppingManager;
    public GameObject unequipButton;
    public AudioManager audioManager;

    public PlayerMovement playerScript;

    public GameObject itemObject;

    public GameObject[] hatButtons;
    public GameObject[] shirtButtons;

    

    void Start() {
        SetupItemInShopButtons();
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    public void SetupItemInShopButtons() {
        itemName.text = itemData.itemName;

        itemType.text = itemData.itemType.ToString();

        icon.sprite = itemData.icon;
    }


    public void ItemSelected() {
        if(itemType.text == "hat") {
            foreach (GameObject hatButton in hatButtons) {
                hatButton.GetComponent<Button>().interactable = false;
            }
            EquipItem();
            unequipButton.SetActive(true);
        }

        if(itemType.text == "shirt") {
            foreach (GameObject shirtButton in shirtButtons) {
                shirtButton.GetComponent<Button>().interactable = false;
            }
            EquipItem();
            unequipButton.SetActive(true);
        }
        /*if (isEquipped) {
            UnequipItem();
        } else {
            EquipItem();
        }*/
    }

    public void EquipItem() {
        if (itemType.text == "hat") {

            if (playerScript.equippedHat != null && playerScript.equippedHat != itemObject) {
                playerScript.equippedHat.SetActive(false);
                playerScript.equippedHat.GetComponent<ItemWithAnimationData>().itemData.isEquipped = false;
                playerScript.equippedHat = null;

            }

            print("HAT EQUIP");
            itemObject.SetActive(true);
            audioManager.PlayEquipSFX();
            playerScript.EquipHatOnPlayer(itemObject);
            itemObject.GetComponent<ItemWithAnimationData>().itemData.isEquipped = true;
            isEquipped = true;
        } else if (itemType.text == "shirt" && playerScript.equippedShirt == null) {

            print("SHIRT EQUIP");
            itemObject.SetActive(true);
            audioManager.PlayEquipSFX();
            playerScript.EquipShirtOnPlayer(itemObject);
            itemObject.GetComponent<ItemWithAnimationData>().itemData.isEquipped = true;
            isEquipped = true;
        }
    }

    public void UnequipItem() {
        if (itemType.text == "hat") {
            foreach (GameObject hatButton in hatButtons) {
                hatButton.GetComponent<Button>().interactable = true;
            }
        }

        if (itemType.text == "shirt") {
            foreach (GameObject shirtButton in shirtButtons) {
                shirtButton.GetComponent<Button>().interactable = true;
            }
        }

        if (itemType.text == "hat") {

            print("HAT UNEQUIP");
            itemObject.SetActive(false);
            audioManager.PlayUnequipSFX();
            playerScript.UnequipHatFromPlayer();
            itemObject.GetComponent<ItemWithAnimationData>().itemData.isEquipped = false;
            isEquipped = false;
            gameObject.GetComponent<Button>().interactable = true;
            unequipButton.SetActive(false);

        } else if (itemType.text == "shirt") {

            print("SHIRT UNEQUIP");
            itemObject.SetActive(false);
            audioManager.PlayUnequipSFX();
            playerScript.UnequipShirtFromPlayer();
            itemObject.GetComponent<ItemWithAnimationData>().itemData.isEquipped = false;
            isEquipped = false;
            gameObject.GetComponent<Button>().interactable = true;
            unequipButton.SetActive(false);
        }
    }
}
