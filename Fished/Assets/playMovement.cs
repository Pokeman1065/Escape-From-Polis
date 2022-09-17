using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 15;

    float forwardMove = 0;
    float sideMove = 0;

    void Start()
    {
        
    }

    void Update()
    {
        forwardMove = Input.GetAxisRaw("Vertical");
        sideMove = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(sideMove * moveSpeed * 0.4f, rb.velocity.y, forwardMove * moveSpeed);
    }
}
