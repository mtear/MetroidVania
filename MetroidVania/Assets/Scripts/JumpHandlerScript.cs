using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHandlerScript : MonoBehaviour {

    PlayerJumpScript js;
    BoxCollider bc;
    int mask;

    void Start () {
        js = GetComponent<PlayerJumpScript>();
        bc = GetComponent<BoxCollider>();
        mask = LayerMask.GetMask("Ground");
    }
	
	void FixedUpdate () {
        if (js.jumping && js.jumpingframes > 6) return;

        Ray ray1 = new Ray(transform.position, Vector3.down);
        Ray ray2 = new Ray(transform.position + new Vector3(bc.size.x/2f-0.01f,0,0), Vector3.down);
        Ray ray3 = new Ray(transform.position - new Vector3(bc.size.x /2f-0.01f, 0, 0), Vector3.down);
        RaycastHit info1, info2, info3;

        bool itembelow = Physics.Raycast(ray1, out info1, bc.size.y/2f, mask);
        itembelow = itembelow || Physics.Raycast(ray2, out info2, bc.size.y / 2f, mask);
        itembelow = itembelow || Physics.Raycast(ray3, out info3, bc.size.y / 2f, mask);

        js.grounded = itembelow;
	}

}
