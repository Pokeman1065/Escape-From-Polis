using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cam;
    public float moveSpeed = 10f;
    public float turnSmoothTime = 0.2f;

    float turnSmoothVel;
    float forwardMove = 0;
    float sideMove = 0;
    float targetAngle = 0;
    Vector3 dir;
    bool canJump = false;

    void Start()
    {
    }

    void Update()
    {
        forwardMove = Input.GetAxisRaw("Vertical");
        sideMove = Input.GetAxisRaw("Horizontal");
        //check for jump allowed and jump
        if (!canJump && transform.position.y <= 1.1)
            canJump = true;
        if (Input.GetKeyDown("space") && canJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, 10f, rb.velocity.z);
            canJump = false;
        }

        dir = new Vector3(sideMove, 0f, forwardMove).normalized;
    }

    private void FixedUpdate()
    {
        //check for new dir
        if (forwardMove != 0 || sideMove != 0)
            targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
        //smooth rotation of player
        float transAngle  = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, transAngle, 0f);
        //move player
        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        if (forwardMove != 0 || sideMove != 0)
            rb.velocity = new Vector3(moveDir.x * moveSpeed, rb.velocity.y, moveDir.z * moveSpeed);

    }
}