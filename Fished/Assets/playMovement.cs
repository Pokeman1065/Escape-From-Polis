using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playMovement : MonoBehaviour
{
    public Rigidbody rb;

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
        rb.velocity = new Vector3(sideMove, rb.velocity.y, forwardMove);
    }
}
