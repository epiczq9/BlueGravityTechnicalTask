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

    public ClothesAnimation hatAnimationScript;
    public ClothesAnimation shirtAnimationScript;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hatAnimationScript = transform.GetChild(0).gameObject.GetComponent<ClothesAnimation>();
        shirtAnimationScript = transform.GetChild(1).gameObject.GetComponent<ClothesAnimation>();
    }

    private void Update() {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
        
    }

    void FixedUpdate() {

        hatAnimationScript.SetMovingAnimationParamaters(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        shirtAnimationScript.SetMovingAnimationParamaters(animator.GetFloat("moveX"), animator.GetFloat("moveY"));

        if (canMove && movementInput != Vector2.zero) {

            isMoving = true;

            rb.MovePosition(rb.position + (speed * Time.fixedDeltaTime * movementInput));

            animator.SetBool("isMoving", isMoving);
            hatAnimationScript.SetIsMovingAnimation(isMoving);
            shirtAnimationScript.SetIsMovingAnimation(isMoving);


            animator.SetFloat("moveX", movementInput.x);
            animator.SetFloat("moveY", movementInput.y);/*
            hatAnimationScript.SetMovingAnimationParamaters(movementInput.x, movementInput.y);
            shirtAnimationScript.SetMovingAnimationParamaters(movementInput.x, movementInput.y);*/

        } else {
            isMoving = false;
            animator.SetBool("isMoving", isMoving);
            hatAnimationScript.SetIsMovingAnimation(isMoving);
            shirtAnimationScript.SetIsMovingAnimation(isMoving);
        }
    }

    void EquipClothesItem() {
        hatAnimationScript.SetMovingAnimationParamaters(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        shirtAnimationScript.SetMovingAnimationParamaters(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
    }


}
