using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesAnimation : MonoBehaviour
{
    float moveX;
    float moveY;
    bool isMoving = false;

    Animator clothesAnimator;
    Animator playerAnimator;

    Vector2 movementInput;

    private void Start() {
        clothesAnimator = GetComponent<Animator>();
        //playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }
    /*
    private void Update() {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");

        if(movementInput != Vector2.zero) {
            clothesAnimator.SetFloat("moveX", movementInput.x);
            clothesAnimator.SetFloat("moveY", movementInput.y);
            clothesAnimator.SetBool("isMoving", true);
        } else {
            clothesAnimator.SetBool("isMoving", false);
        }
        

    }*/

    public void SetMovingAnimationParamaters(float moveX, float moveY) {
        clothesAnimator.SetFloat("moveX", moveX);
        clothesAnimator.SetFloat("moveY", moveY);
    }

    public void SetIsMovingAnimation(bool isPlayerMoving) {
        clothesAnimator.SetBool("isMoving", isPlayerMoving);
    }
}
