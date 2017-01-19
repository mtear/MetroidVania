using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.LeftArrow)) {
			transform.Translate( Vector3.left * Time.deltaTime * 3.0f);
		}else if (Input.GetKey(KeyCode.RightArrow)) {
			transform.Translate(Vector3.right * Time.deltaTime * 3.0f);
		}

	}
}
