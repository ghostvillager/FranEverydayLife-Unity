using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcotorController : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    public float moveSpeed = 2.0f;
    public float Odds = 2.0f;
    Vector2 lastDirection = Vector2.zero;
    bool isMoving = false;
    bool isIdle = true; // Flag to track whether the character is currently idle.
    string state="OK";

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(state == "OK"){

        float x = Input.GetAxisRaw("Horizontal");
        float y = (x == 0) ? Input.GetAxisRaw("Vertical") : 0.0f;

        if (x != 0 || y != 0)
        {
            animator.SetFloat("x", x);
            animator.SetFloat("y", y);
            isMoving = true;
            isIdle = false;
            lastDirection = new Vector2(x, y).normalized;

            // Play the walk animation.
            animator.SetBool("Walk", true);
            animator.SetBool("Idle", false);
        }
        else
        {
            isMoving = false;
            isIdle = true;

            // Stop walking animation when there is no input.
            animator.SetBool("Walk", false);
            animator.SetBool("Idle", true);
        }

        // Move the character.
        if (Input.GetKey(KeyCode.Space)) {
            transform.position += new Vector3(x, y) * Time.deltaTime * moveSpeed * Odds;
        } else {
            transform.position += new Vector3(x, y) * Time.deltaTime * moveSpeed;
        }

        }else{
            animator.SetBool("Walk", false);
            animator.SetBool("Idle", true);
        }
    }

    // LateUpdate is called once per frame after other Update functions.
    private void LateUpdate()
    {
        // Handle animation playback based on the current state.
        if (isIdle)
        {
            animator.speed = 1f;
        }
        else
        {
            animator.enabled = true;
            animator.SetFloat("x", lastDirection.x);
            animator.SetFloat("y", lastDirection.y);
            animator.speed = 1f;
        }
    }
}