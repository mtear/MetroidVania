using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDragScript : MonoBehaviour {

    Rigidbody rb;
    BoxCollider bc;
    int mask;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
        mask = LayerMask.GetMask("Ground");
    }
	
	// Update is called once per frame
	void Update () {
        bool itemside = false;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Ray ray;
            RaycastHit info;
            //Check right
            ray = new Ray(transform.position, Vector3.right);
            itemside = Physics.Raycast(ray, out info, bc.size.x / 2f + 0.001f, mask);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Ray ray;
            RaycastHit info;
            //Check left
            ray = new Ray(transform.position, Vector3.left);
            itemside = Physics.Raycast(ray, out info, bc.size.x / 2f + 0.001f, mask);
        }
        if (itemside)
        {
            rb.drag = 12;
        }else
        {
            rb.drag = 0;
        }
    }
}
