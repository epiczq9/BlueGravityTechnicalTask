using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateShop : MonoBehaviour
{

    public bool isInShopTrigger = false;
    public GameObject shopPopup;
    private bool shoppingUIActive = false;

    public bool isShopping = false;

    PlayerMovement playerMovementScript;

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
        shopPopup.SetActive(shoppingUIActive);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("ShopTrigger")) {
            isInShopTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("ShopTrigger")) {
            isInShopTrigger = false;
        }
    }
}
