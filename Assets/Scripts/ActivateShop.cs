using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateShop : MonoBehaviour
{

    public bool isInShopTrigger = false;
    public GameObject shopPopup;

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        //print(isInShopTrigger);
        if (Input.GetButtonDown("Interact")) {
            StartShopping();
        }
        
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

    void StartShopping() {
        shopPopup.SetActive(true);
    }
}
