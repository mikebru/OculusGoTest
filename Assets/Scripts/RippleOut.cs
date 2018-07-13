using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RippleOut : MonoBehaviour {

	public float ExpandTime = 3;

	public float ScaleIncrease = 10;



	// Use this for initialization
	void Start () {
		StartCoroutine (RippleFunction ());
	}

	IEnumerator RippleFunction()
	{

		float t = 0;

		Vector3 startScale = this.transform.localScale;

		Vector3 endScale = new Vector3 (startScale.x * ScaleIncrease, startScale.y, startScale.z * ScaleIncrease);

		while (t < ExpandTime) {

			t += Time.smoothDeltaTime;

			this.transform.localScale = Vector3.Lerp (startScale, endScale, t / ExpandTime);
			GetComponent<SkinnedMeshRenderer> ().SetBlendShapeWeight (0, Mathf.Lerp (100, 0, t / ExpandTime));


			yield return null;
		}


		Destroy (this.gameObject);

	}
	

}
