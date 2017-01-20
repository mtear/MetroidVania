using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpHandlerScript : MonoBehaviour {

    PlayerJumpScript js;

    bool countingdown = false;

    int maxframes = 3, currentframes = 3;

	// Use this for initialization
	void Start () {
        js = this.transform.parent.GetComponent<PlayerJumpScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (countingdown)
        {
            currentframes--;
            if(currentframes == 0)
            {
                js.grounded = true;
                countingdown = false;
            }
        }
	}

    void OnTriggerStay(Collider other)
    {
        if(!countingdown && !js.grounded && !js.jumping && other.tag == "Ground")
        {
            Debug.Log("here");
            countingdown = true;
            currentframes = maxframes;
        }
    }
}
