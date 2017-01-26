using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJumpScript : MonoBehaviour {

    PlayerJumpScript js;
    Rigidbody rb;
    BoxCollider bc;
    int mask;

    float thrustpower = 30f;

    // Use this for initialization
    void Start () {
        js = GetComponent<PlayerJumpScript>();
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        mask = LayerMask.GetMask("Ground");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A) && !js.grounded)
        { //TODO can jump
            Ray ray;
            RaycastHit info;
            bool itemside = false;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                //Check right
                ray = new Ray(transform.position, Vector3.right);
                itemside = Physics.Raycast(ray, out info, bc.size.x/2f + 0.001f, mask);
                if(itemside)rb.velocity += Vector3.left * thrustpower;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                //Check left
                ray = new Ray(transform.position, Vector3.left);
                itemside = Physics.Raycast(ray, out info, bc.size.x / 2f + 0.001f, mask);
                if(itemside)rb.velocity += Vector3.right * thrustpower;
            }
            if(itemside)
            {
                //Wall jump!
                js.Jump();
            }
        }
    }
}
