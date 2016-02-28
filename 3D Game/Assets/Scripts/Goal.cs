using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	public GameObject parentObject;

	private float parentScaleX;
	private float parentScaleY;
	private float parentScaleZ;

	// Use this for initialization
	void Start () {
		parentScaleX = parentObject.transform.localScale.x;
		parentScaleY = parentObject.transform.localScale.y;
		parentScaleZ = parentObject.transform.localScale.z;
		gameObject.transform.position = new Vector3 (0.0f, -parentScaleY/2 - transform.localScale.y, 0.0f);

		float randomX = (float)((int)(RandomFromDistribution.RandomRangeNormalDistribution (-parentScaleX/2, parentScaleX/2, RandomFromDistribution.ConfidenceLevel_e._90)));
		float randomZ = (float)((int)(RandomFromDistribution.RandomRangeNormalDistribution (-parentScaleZ/2, parentScaleZ/2, RandomFromDistribution.ConfidenceLevel_e._90)));

		if (randomX > 0)
			randomX -= 0.5f;
		else
			randomX += 0.5f;
		if (randomZ > 0)
			randomZ -= 0.5f;
		else
			randomZ += 0.5f;

		gameObject.transform.position += new Vector3 (randomX, 0, randomZ);

		gameObject.transform.parent = parentObject.transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
