using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform cam;
    public float moveSpeed = 15f;
    public float turnSmoothTime = 0.5f;

    float turnSmoothVel;
    float forwardMove = 0;
    float sideMove = 0;
    Vector3 dir;
    bool canJump = false;

    void Start()
    {
    }

    void Update()
    {
        forwardMove = Input.GetAxisRaw("Vertical");
        sideMove = Input.GetAxisRaw("Horizontal");
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
        float targetAngle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
        float angle  = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        rb.velocity = new Vector3(forwardMove * moveDir.x * moveSpeed, rb.velocity.y, forwardMove * moveDir.y * moveSpeed);

        print(canJump);
    }
}
