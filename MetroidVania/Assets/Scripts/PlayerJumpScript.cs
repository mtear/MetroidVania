using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpScript : MonoBehaviour {

    public bool jumping = false;
    int maxjumpingframes = 12;
    public int jumpingframes = 12;
    float jumpspeed = 120;

    Rigidbody rigidBody;

    public bool grounded = false;

    // Use this for initialization
    void Start () {
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if (jumping)
        {
            jumpingframes--;
            if (Input.GetKeyUp(KeyCode.A))
            {
                jumpingframes = 0;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (jumpingframes > 0)
                {
                    rigidBody.velocity = rigidBody.velocity + Vector3.up * Time.deltaTime * jumpspeed * ((float)jumpingframes / (float)maxjumpingframes);
                }
            }
            if(jumpingframes == 0)
            {
                jumping = false;
                jumpingframes = maxjumpingframes;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A) && grounded)
            {
                Jump();
            }
        }
    }

    public void Jump()
    {
        jumping = true;
        grounded = false;
        jumpingframes = maxjumpingframes;

        var vel = rigidBody.velocity;
        vel.y = 0;
        rigidBody.velocity = vel;
    }
}
