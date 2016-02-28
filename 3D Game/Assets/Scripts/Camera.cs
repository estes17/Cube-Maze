using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public float RotationSpeed = 10;

	public GameObject camera;

	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButton (1)) {
			transform.Rotate ((Input.GetAxis ("Mouse Y") * RotationSpeed * Time.deltaTime),
				-(Input.GetAxis ("Mouse X") * RotationSpeed * Time.deltaTime), 0, Space.World);
		} else {
			transform.Rotate ((Input.GetAxis ("Mouse Y") * RotationSpeed * Time.deltaTime), 0,
				-(Input.GetAxis ("Mouse X") * RotationSpeed * Time.deltaTime), Space.World);
		}

		if (Input.GetAxis ("Mouse ScrollWheel") > 0 && camera.transform.localScale.z > 25) {
			camera.transform.localScale += new Vector3 (0.0f, 0.0f, -Input.GetAxis ("Mouse ScrollWheel") * 4);
		} else if (Input.GetAxis ("Mouse ScrollWheel") < 0 && camera.transform.localScale.z < 40) {
			camera.transform.localScale += new Vector3 (0.0f, 0.0f, -Input.GetAxis ("Mouse ScrollWheel") * 4);
		}
	}

}
