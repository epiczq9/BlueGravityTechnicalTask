using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateShop : MonoBehaviour
{

    public bool isInShopTrigger = false;
    public GameObject shopPopupUI;
    private bool shoppingUIActive = false;

    public bool isShopping = false;

    PlayerMovement playerMovementScript;

    public GameObject shopInteractInstruction;

    void Start() {
        playerMovementScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update() {
        //print(isInShopTrigger);
        if (Input.GetButtonDown("Interact") && !shoppingUIActive) {

            if (isInShopTrigger) {
                UpdateShoppingUI();

            }
        }
    }

    public void UpdateShoppingUI() {
        shoppingUIActive = !shoppingUIActive;

        //Disable movement while shopping, so if shopping is active, movement is the opposite
        playerMovementScript.canMove = !shoppingUIActive;

        //shopPopup and shoppingUIActive are flags for the whole shopping menu
        shopPopupUI.SetActive(shoppingUIActive);

        shopInteractInstruction.SetActive(!shoppingUIActive);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("ShopTrigger")) {
            isInShopTrigger = true;
            shopInteractInstruction.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("ShopTrigger")) {
            isInShopTrigger = false;
            shopInteractInstruction.SetActive(false);
        }
    }
}
