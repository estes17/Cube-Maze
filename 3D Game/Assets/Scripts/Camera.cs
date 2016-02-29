using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour {

	public float RotationSpeed = 10;

	public GameObject camera;
	public Player player;

	// Update is called once per frame
	void Update () {

		if (player.win == false) {

			if (Input.GetMouseButton (1)) {
				transform.Rotate ((Input.GetAxis ("Mouse Y") * RotationSpeed * Time.deltaTime),
					-(Input.GetAxis ("Mouse X") * RotationSpeed * Time.deltaTime), 0, Space.World);
			} else {
				transform.Rotate ((Input.GetAxis ("Mouse Y") * RotationSpeed * Time.deltaTime), 0,
					-(Input.GetAxis ("Mouse X") * RotationSpeed * Time.deltaTime), Space.World);
			}

			if (Input.GetAxis ("Mouse ScrollWheel") > 0 && camera.transform.localScale.z > 20) {
				camera.transform.localScale += new Vector3 (0.0f, 0.0f, -Input.GetAxis ("Mouse ScrollWheel") * 6);
			} else if (Input.GetAxis ("Mouse ScrollWheel") < 0 && camera.transform.localScale.z < 50) {
				camera.transform.localScale += new Vector3 (0.0f, 0.0f, -Input.GetAxis ("Mouse ScrollWheel") * 6);
			}

			//Allows user to rotate the cube with the W and Q  keys. This is a failsafe feature just in case the mouse functionality stops working.
			//Rotates the cube along one axis while W is pressed
			if (Input.GetKey (KeyCode.W)) {
				transform.Rotate (Vector3.up * RotationSpeed * Time.deltaTime);
			}
			//Rotates the cube along the other axis while Q is pressed
			if (Input.GetKey (KeyCode.Q)) {
				transform.Rotate (Vector3.left * RotationSpeed * Time.deltaTime);
			}


		}
	}

}
