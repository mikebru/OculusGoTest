using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCam : MonoBehaviour {

	private Rigidbody camRigidbody;

	[Range(.1f, 10)]
	public float Speed = 3;

	// Use this for initialization
	void Start () {
		camRigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		float xInput = Input.GetAxis ("Horizontal");
		float yInput = Input.GetAxis ("Vertical");

		Vector3 currentInput = new Vector3(xInput, 0, yInput);

		camRigidbody.AddForce (currentInput);


	}
}
