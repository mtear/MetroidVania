using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminalVelocityHandler : MonoBehaviour {

    public float terminalVelocity = -20f;
    Rigidbody rb;

    void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate () {
        if(rb.velocity.y < terminalVelocity)
        {
            var velocity = rb.velocity;
            velocity.y = terminalVelocity;
            rb.velocity = velocity;
        }
	}
}
