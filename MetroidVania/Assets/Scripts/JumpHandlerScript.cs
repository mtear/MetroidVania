using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHandlerScript : MonoBehaviour {

    PlayerJumpScript js;
    Rigidbody rigidBody;
    BoxCollider bc;

    Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
        js = GetComponent<PlayerJumpScript>();
        rigidBody = GetComponent<Rigidbody>();
        bc = GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Ray ray = new Ray(transform.position, Vector3.down);
        float d = velocity.y;
        d = rigidBody.velocity.y;
        d = Mathf.Abs(d);
        RaycastHit info;

        int mask = LayerMask.NameToLayer("Ground");

        bool itembelow = Physics.Raycast(ray, out info, 5);

        Debug.Log(itembelow);

        if (itembelow)
        {
            Debug.Log(info.distance);
            if(info.distance <= bc.size.y / 2)
            {
                js.grounded = true;
            }
        }
	}

}
