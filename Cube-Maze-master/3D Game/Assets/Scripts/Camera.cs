using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public float RotationSpeed = 10;

	// Update is called once per frame
	void Update () {
		transform.Rotate ( (Input.GetAxis ("Mouse Y") * RotationSpeed * Time.deltaTime),
			-(Input.GetAxis ("Mouse X") * RotationSpeed * Time.deltaTime),
			0,
			Space.World);
		
	}

}
