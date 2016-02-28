using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject parentObject;

	private float parentScaleX;
	private float parentScaleY;
	private float parentScaleZ;

	public bool win;

	// Use this for initialization
	void Start () {
		win = false;

		parentScaleX = parentObject.transform.localScale.x;
		parentScaleY = parentObject.transform.localScale.y;
		parentScaleZ = parentObject.transform.localScale.z;

		gameObject.transform.position = new Vector3 (0.5f, parentScaleY/2 + transform.localScale.y/2, 0.5f);
		gameObject.transform.parent = parentObject.transform;
	}
		
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Finish")
		{
			win = true;
		}
	}

}