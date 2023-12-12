using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    //Well not just movement, more like PlayerBehaviour


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

        //The idea of this function is to equip clothes on startup that were still equipped when the player exited the game
        //but I was thinking it's better to reset everything, but I will leave this here, if I wanted to save the progress

        //CheckEquippedClothes();

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        SetupEquipedClothesAnimation();
    }

    private void Update() {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
        
    }


    void FixedUpdate() {

        SetHatAnimationFloats();
        SetShirtAnimationFloats();

        if (canMove && movementInput != Vector2.zero) {

            isMoving = true;

            rb.MovePosition(rb.position + (speed * Time.fixedDeltaTime * movementInput.normalized));

            animator.SetBool("isMoving", isMoving);
            SetHatIsMoving();
            SetShirtIsMoving();


            animator.SetFloat("moveX", movementInput.x);
            animator.SetFloat("moveY", movementInput.y);

        } else {
            isMoving = false;
            animator.SetBool("isMoving", isMoving);
            SetHatIsMoving();
            SetShirtIsMoving();
        }
    }


    //The idea of this function is to equip clothes that were equipped when the player exited the game
    //but I was thinking it's better to reset everything, but I will leave this here, if I wanted to save the progress
    void CheckEquippedClothes() {
        foreach(GameObject clothesItem in clothesList) {
            Item clothesData = clothesItem.GetComponent<ItemWithAnimationData>().itemData;
            if (clothesData.isEquipped) {
                clothesItem.SetActive(true);
                if (clothesData.itemType == Item.ItemType.hat) {
                    EquipHatOnPlayer(clothesItem);
                } else if (clothesData.itemType == Item.ItemType.shirt) {
                    EquipShirtOnPlayer(clothesItem);
                }
                SetupEquipedClothesAnimation();
            } else {
                clothesItem.SetActive(false);
            }
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

    public void SetupEquipedClothesAnimation() {
        if(equippedHat != null) {
            hatAnimationScript = equippedHat.GetComponent<ClothesAnimation>();
        }
        
        if(equippedShirt != null) {
            shirtAnimationScript = equippedShirt.GetComponent<ClothesAnimation>();
        }
    }


}
