using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour {

    Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
	}

    Vector3 v = Vector3.zero;
    float speed = 60f;
	
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			v = Vector3.left * speed;
		}else if (Input.GetKey(KeyCode.RightArrow)) {
			v = Vector3.right * speed;
        }else
        {
            v = Vector3.zero;
        }

        var vel = rigidBody.velocity;
        vel.x *= 0.785f;
        rigidBody.velocity = vel + v*Time.deltaTime;
    }

}
