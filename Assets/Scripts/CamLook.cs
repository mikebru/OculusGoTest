using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLook : MonoBehaviour {



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector2 mousePoint = Input.mousePosition;

		float xRotate = Mathf.Lerp (-1, 1, (mousePoint.x * 1.0f / Screen.width* 1.0f ));
		float yRotate = Mathf.Lerp (1, -1, (mousePoint.y * 1.0f / Screen.height* 1.0f ));

		transform.Rotate (new Vector3(yRotate,xRotate, 0));

		transform.rotation = Quaternion.Euler(new Vector3 (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0));
	}
}
