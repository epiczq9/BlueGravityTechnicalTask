using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rb;
    Vector2 movementInput;

    public float speed = 1f;

    private Animator animator;

    public bool canMove = true;
    bool isMoving = false;

    public GameObject equippedHat;
    public GameObject equippedShirt;

    public ClothesAnimation hatAnimationScript;
    public ClothesAnimation shirtAnimationScript;

    public List<GameObject> clothesList = new();

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //hatAnimationScript = transform.GetChild(0).gameObject.GetComponent<ClothesAnimation>();
        //shirtAnimationScript = transform.GetChild(1).gameObject.GetComponent<ClothesAnimation>();
        SetupEquipedClothesAnimation();
    }

    private void Update() {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
        
    }

    void FixedUpdate() {
        SetHatAnimationFloats();
        SetShirtAnimationFloats();

        /*if (hatAnimationScript != null && shirtAnimationScript != null) {
            hatAnimationScript.SetMovingAnimationParamaters(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
            shirtAnimationScript.SetMovingAnimationParamaters(animator.GetFloat("moveX"), animator.GetFloat("moveY"));

        }*/

        if (canMove && movementInput != Vector2.zero) {

            isMoving = true;

            rb.MovePosition(rb.position + (speed * Time.fixedDeltaTime * movementInput));

            animator.SetBool("isMoving", isMoving);
            SetHatIsMoving();
            SetShirtIsMoving();
            /*hatAnimationScript.SetIsMovingAnimation(isMoving);
            shirtAnimationScript.SetIsMovingAnimation(isMoving);*/


            animator.SetFloat("moveX", movementInput.x);
            animator.SetFloat("moveY", movementInput.y);/*
            hatAnimationScript.SetMovingAnimationParamaters(movementInput.x, movementInput.y);
            shirtAnimationScript.SetMovingAnimationParamaters(movementInput.x, movementInput.y);*/

        } else {
            isMoving = false;
            animator.SetBool("isMoving", isMoving);
            SetHatIsMoving();
            SetShirtIsMoving();
            /*hatAnimationScript.SetIsMovingAnimation(isMoving);
            shirtAnimationScript.SetIsMovingAnimation(isMoving);*/
        }
    }

    void SetHatAnimationFloats() {
        if (hatAnimationScript != null) {
            hatAnimationScript.SetMovingAnimationParamaters(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        }
    }

    void SetShirtAnimationFloats() {
        if (shirtAnimationScript != null) {
            shirtAnimationScript.SetMovingAnimationParamaters(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        }
    }

    void SetHatIsMoving() {
        if (hatAnimationScript != null) {
            hatAnimationScript.SetIsMovingAnimation(isMoving);
        }
    }

    void SetShirtIsMoving() {
        if (shirtAnimationScript != null) {
            shirtAnimationScript.SetIsMovingAnimation(isMoving);
        }
    }

    public void EquipHatOnPlayer(GameObject itemObject) {
        equippedHat = itemObject;
        SetupEquipedClothesAnimation();
    }

    public void EquipShirtOnPlayer(GameObject itemObject) {
        equippedShirt = itemObject;
        SetupEquipedClothesAnimation();
    }

    public void UnequipHatFromPlayer() {
        equippedHat = null;
        hatAnimationScript = null;
    }

    public void UnequipShirtFromPlayer() {
        equippedShirt = null;
        shirtAnimationScript = null;
    }



    //This function is called AFTER we check if the item is already equipped in ItemInInventory script
    /*public void EquipHat(Item itemData) {
        if (equippedHat != null) {
            UnequipHat(equippedHat.GetComponent<ItemWithAnimationData>().itemData);
        }

        foreach (GameObject clothesItem in clothesList) {
            if (clothesItem.GetComponent<ItemWithAnimationData>().itemData.itemName == itemData.itemName) {
                equippedHat = clothesItem;
                SetupEquipedClothesAnimation();
                clothesItem.SetActive(true);
                break;
            }

        }
    }

    public void UnequipHat(Item itemData) {
        if (equippedHat != null) {
            foreach (GameObject clothesItem in clothesList) {
                if (clothesItem.GetComponent<ItemWithAnimationData>().itemData.itemName == itemData.itemName) {
                    equippedHat = null;
                    hatAnimationScript = null;
                    clothesItem.SetActive(false);
                    break;
                }
            }
        }
    }

    public void EquipShirt(Item itemData) {
        if (equippedShirt != null) {
            UnequipHat(equippedShirt.GetComponent<ItemWithAnimationData>().itemData);
        }

        foreach (GameObject clothesItem in clothesList) {
            if (clothesItem.GetComponent<ItemWithAnimationData>().itemData.itemName == itemData.itemName) {
                equippedShirt = clothesItem;
                SetupEquipedClothesAnimation();
                clothesItem.SetActive(true);
                break;
            }
        }
    }

    public void UnequipShirt(Item itemData) {
        if (equippedShirt != null) {
            foreach (GameObject clothesItem in clothesList) {
                if (clothesItem.GetComponent<ItemWithAnimationData>().itemData.itemName == itemData.itemName) {
                    equippedShirt = null;
                    shirtAnimationScript = null;
                    clothesItem.SetActive(false);
                    break;
                }
            }
        }
    }*/

    public void SetupEquipedClothesAnimation() {
        if(equippedHat != null) {
            hatAnimationScript = equippedHat.GetComponent<ClothesAnimation>();
        }
        
        if(equippedShirt != null) {
            shirtAnimationScript = equippedShirt.GetComponent<ClothesAnimation>();
        }
    }

    void EquipClothesItem() {
        hatAnimationScript.SetMovingAnimationParamaters(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        shirtAnimationScript.SetMovingAnimationParamaters(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
    }


}
