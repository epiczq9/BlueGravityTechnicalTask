using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody2D rb;
    Vector2 movementInput;

    public float speed = 1f;

    private Animator animator;

    public bool canMove = true;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        movementInput.x = Input.GetAxisRaw("Horizontal");
        movementInput.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
        if (canMove && movementInput != Vector2.zero) {

            rb.MovePosition(rb.position + (speed * Time.fixedDeltaTime * movementInput));

            animator.SetBool("isMoving", true);

            animator.SetFloat("moveX", movementInput.x);
            animator.SetFloat("moveY", movementInput.y);

        } else {
            animator.SetBool("isMoving", false);
        }
    }
}
