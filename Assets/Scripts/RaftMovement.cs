using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftMovement : MonoBehaviour {

	public Camera rigCam;
	private Rigidbody camRigidbody;

	public GameObject WaterRipple;

	[Range(10, 1000)]
	public float Force = 3;

	private bool PaddleIn;

	// Use this for initialization
	void Start () {
		camRigidbody = GetComponent<Rigidbody> ();

		rigCam = GetComponentInChildren<Camera> ();
	}

	// Update is called once per frame
	void Update () {

		Paddle ();

		CameraRotation ();
	}


	void Paddle()
	{
		float xInput = Input.GetAxis ("Horizontal");
		float yInput = Input.GetAxis ("Vertical");

		if ((xInput != 0 || yInput != 0)) {

			Vector3 currentInput = ((transform.forward * yInput) + (transform.right * xInput)) * Force;

			Vector3 currentVelocity = camRigidbody.velocity;

			Vector3 heading = currentInput.normalized - currentVelocity.normalized;

			camRigidbody.AddForce (currentInput + (Vector3.Scale (currentVelocity, heading)));

			if (PaddleIn == false) {
				//StartCoroutine (RippleGenerate ());

				PaddleIn = true;
			}
		} else if(PaddleIn == true){
			PaddleIn = false;
		}
	}

	void CameraRotation()
	{
		Vector2 mousePoint = Input.mousePosition;

		float xRotate = Mathf.Lerp (-1, 1, (mousePoint.x * 1.0f / Screen.width* 1.0f ));
		float yRotate = Mathf.Lerp (1, -1, (mousePoint.y * 1.0f / Screen.height* 1.0f ));

		//Rotate Raft to set forward direction
		transform.Rotate (new Vector3(0,xRotate, 0));

		//lock raft values
		transform.rotation = Quaternion.Euler(new Vector3 (0, transform.rotation.eulerAngles.y, 0));

		//Rotate cam up and own for viewing
		rigCam.transform.Rotate(new Vector3(yRotate,0, 0));

		//lock cam values
		rigCam.transform.localRotation = Quaternion.Euler(new Vector3 (rigCam.transform.localRotation.eulerAngles.x, 0, 0));

	}


	IEnumerator RippleGenerate()
	{
		Instantiate (WaterRipple, new Vector3(transform.position.x, 0, transform.position.z), Quaternion.identity);

		yield return new WaitForSeconds (.5f);

		if (PaddleIn == true) {
			StartCoroutine (RippleGenerate ());
		}
	}


}
